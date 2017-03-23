//=============================================================================
// REPORT_WBR_CATCH
// dc_declarant - класс взаимодействия с БД для объектов данных data_declarant
// Автор: Иванченко М.В.
// Дата начала разработки:  22-03-2017
// Дата обновления:         22-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using cfmc.quotas.db_objects;

namespace cfmc.quotas.db_controllers
{
    using list_declarant = List<data_declarant>;
    /// <summary>
    /// public class dc_declarant
    /// - класс взаимодействия с БД для объектов данных data_declarant
    /// </summary>
    public class dc_declarant
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public dc_declarant( )
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
        public list_declarant data { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize( )
        {
            this.data = new list_declarant( );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// select( string x_filter )
        /// получение данных, где имя пользователя ВБР или ИНН
        /// включают x_filter
        /// </summary>
        /// <param name="x_filter">фильтр выборки данных</param>
        public void select( string x_filter )
        {
            if( x_filter.Length == 0 )
            {
                return;
            }
            this.data.Clear( );

            using(
                    SqlConnection cnn =
                        new SqlConnection( Program.db_connection_sting )
                 )
            {
                //
                SqlCommand cmd = cnn.CreateCommand( );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_declarant]";
                cmd.Parameters.Add( new SqlParameter( "@x_declarant", x_filter ) );

                cnn.Open( );

                SqlDataReader reader = cmd.ExecuteReader( );
                try
                {
                    while( reader.Read( ) )
                    {
                        object[] data_row = new object[reader.FieldCount];
                        reader.GetValues( data_row );
                        this.data.Add( new data_declarant( data_row ) );
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

    }//class dc_declarant

}//namespace cfmc.quotas.db_controllers

            