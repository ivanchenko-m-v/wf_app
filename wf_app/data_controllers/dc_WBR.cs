
//=============================================================================
// dc_WBR - класс взаимодействия с БД для объектов данных data_WBR
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         13-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace cfmc.quotas.db_controllers
{
    using list_WBR = List<cfmc.quotas.db_objects.data_WBR>;

    public class dc_WBR
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public dc_WBR( )
        {
            this.initialize( );
        }
        #endregion //__CONSTRUCTION__	

        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// data - список результатов запроса выборки данных
        /// </summary>
        public list_WBR data { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize( )
        {
            this.data = new list_WBR( );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        public void select( )
        {
            this.data.Clear( );

            using(
                    SqlConnection cnn =
                        new SqlConnection( Program.db_connection_sting )
                 )
            {
                //
                SqlCommand cmd = cnn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_WBR]";

                cnn.Open( );

                SqlDataReader reader = cmd.ExecuteReader( );
                try
                {
                    while( reader.Read( ) )
                    {
                        object[] data_row = new object[reader.FieldCount];
                        reader.GetValues( data_row );
                        this.data.Add( new db_objects.data_WBR( data_row ) );
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close( );
                }

            }//using( cnn )
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        #endregion//__FIELDS__

    }//class dc_WBR

}//namespace cfmc.quotas.db_controllers

            