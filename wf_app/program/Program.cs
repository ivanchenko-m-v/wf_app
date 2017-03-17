//=============================================================================
// Program - класс программы с функцией Main( )
// Автор: Иванченко М.В.
// Дата начала разработки:  17-02-2017
// Дата обновления:         17-03-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace cfmc.quotas
{
    static class Program
    {
        [DllImport( "user32.dll" )]
        [return: MarshalAs( UnmanagedType.Bool )]
        static extern bool SetForegroundWindow( IntPtr hWnd );
        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// db_connection - объект подключения к базе данных
        /// </summary>
        public static string db_connection_sting
        { get; set; }
        #endregion//__PROPERTIES__

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using( Mutex mutex = new Mutex( true, "cfmc.quotas.forms.form_portions_history", out createdNew ) )
            {
                if( createdNew )
                {
                    //check config file
                    if( !Program.check_config( ) )
                    {
                        return;
                    }
                    //init database connection
                    Program.init_db_connection( );
                    //init data
                    if( Program.init_data_store( ) )
                    {
                        //init export object
                        business_logic.init_excel_producer( );

                        //open main program form
                        //in the case of successfull
                        //init of data store
                        Program.show_main_form( );
                    }
                }
                else
                {
                    Process current = Process.GetCurrentProcess( );
                    foreach( Process process in Process.GetProcessesByName( current.ProcessName ) )
                    {
                        if( process.Id != current.Id )
                        {
                            SetForegroundWindow( process.MainWindowHandle );
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// check_config( )
        /// </summary>
        private static bool check_config( )
        {
            bool b_success = false;
            try
            {
                if( !File.Exists( app_resources.settings_file_name ) )
                {
                    Program.create_config( );
                }
                Program.read_config( );

                b_success = true;
            }
            catch( Exception ex )
            {
                string s_msg = String.Format(
                                             "{0}\n{1} {2}\n{3}",
                                             app_resources.msgbox_config_message,
                                             app_resources.msgbox_exception_type,
                                             ex.GetType( ).ToString( ),
                                             ex.Message
                                            );
                MessageBox.Show(
                                s_msg,
                                app_resources.msgbox_exception_title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                               );
            }

            return b_success;
        }
        /// <summary>
        /// read_config( )
        /// </summary>
        private static void read_config( )
        {
            using(
                StreamReader srd = File.OpenText(
                                            app_resources.settings_file_name
                                                )
                 )
            {
                string[] delimeters = { "###" };
                while( !srd.EndOfStream )
                {
                    string s_line = srd.ReadLine( );
                    string[] s_params = s_line.Split( delimeters, StringSplitOptions.RemoveEmptyEntries );
                    //must be 2 strings
                    //1 - name, 2 - value
                    if( s_params.Length == 2 )
                    {
                        if( s_params[0] == app_resources.settings_server)
                        {
                            app_settings.Default.server = s_params[1];
                        }
                        if( s_params[0] == app_resources.settings_database )
                        {
                            app_settings.Default.database = s_params[1];
                        }
                    }
                }
                app_settings.Default.Save( );
            }
        }
        /// <summary>
        /// create_config( )
        /// </summary>
        private static void create_config( )
        {
            using(
                StreamWriter swr = File.CreateText(
                                            app_resources.settings_file_name
                                                  )
                 )
            {
                //app_settings.Default.Properties
                foreach( SettingsProperty sp in app_settings.Default.Properties )
                {
                    swr.WriteLine( "{0}###{1}", sp.Name, sp.DefaultValue );
                }
            }
        }
        /// <summary>
        /// init_db_connection( )
        /// </summary>
        private static void init_db_connection( )
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder( );
            builder["Data Source"] = app_settings.Default.server;
            builder["Integrated Security"] = true;
            builder["Initial Catalog"] = app_settings.Default.database;

            Program.db_connection_sting = builder.ConnectionString;
        }
        /// <summary>
        /// init_data_store( )
        /// </summary>
        private static bool init_data_store( )
        {
            bool b_success = false;
            try
            {
                //init data store
                business_logic.init_data_store( );

                b_success = true;
            }
            catch( Exception ex )
            {
                string s_msg = String.Format(
                                             "{0}\n{1} {2}\n{3}",
                                             app_resources.msgbox_init_message,
                                             app_resources.msgbox_exception_type,
                                             ex.GetType( ).ToString( ),
                                             ex.Message
                                            );
                MessageBox.Show(
                                s_msg,
                                app_resources.msgbox_exception_title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                               );
            }

            return b_success;
        }
        /// <summary>
        /// show_main_form( )
        /// </summary>
        private static void show_main_form( )
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new cfmc.quotas.forms.form_portions_history( ) );
        }

    }//static class Program

}//namespace cfmc.quotas
