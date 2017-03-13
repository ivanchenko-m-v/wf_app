//=============================================================================
// Program - класс программы с функцией Main( )
// Автор: Иванченко М.В.
// Дата начала разработки:  17-02-2017
// Дата обновления:         13-03-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cfmc.quotas
{
    static class Program
    {
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
            //init database connection
            Program.init_db_connection( );
            //init data store
            business_logic.init_data_store( );
            //open main program form
            Program.show_main_form( );
        }
        /// <summary>
        /// init_db_connection( )
        /// </summary>
        private static void init_db_connection( )
        {
            System.Data.SqlClient.SqlConnectionStringBuilder
                builder = new System.Data.SqlClient.SqlConnectionStringBuilder( );
            builder["Data Source"] = "172.16.1.230";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "limits_2009c";

            Program.db_connection_sting = builder.ConnectionString;
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
    }
}
