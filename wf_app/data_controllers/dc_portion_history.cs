
//=============================================================================
// dc_portion_history - класс взаимодействия с БД для объектов данных 
//                      data_report_portion_history
// Автор: Иванченко М.В.
// Дата начала разработки:  14-03-2017
// Дата обновления:         14-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using cfmc.quotas.db_objects;

namespace cfmc.quotas.db_controllers
{
    using list_portion_history = List<data_report_portion_history>;
    public class dc_portion_history
    {
        /*
         * --------------------------------------------------------------------
         *                          DELEGATES
         * --------------------------------------------------------------------
         */
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public dc_portion_history( )
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
        public list_portion_history data { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize( )
        {
            this.data = new list_portion_history( );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        public void select( 
                            int id_basin, int id_regime, 
                            int id_WBR, int id_region
                          )
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
                cmd.CommandText = "[sp_portion_history]";
                cmd.Parameters.AddRange(
                                        new SqlParameter[]
                                        {
                                            new SqlParameter("@id_basin",id_basin),
                                            new SqlParameter("@id_regime",id_regime),
                                            new SqlParameter("@id_fish",id_WBR),
                                            new SqlParameter("@id_region",id_region)
                                        }
                                       );

                cnn.Open( );

                SqlDataReader reader = cmd.ExecuteReader( );
                try
                {
                    while( reader.Read( ) )
                    {
                        object[] data_row = new object[reader.FieldCount];
                        reader.GetValues( data_row );
                        this.data.Add( new data_report_portion_history( data_row ) );
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

    }//class dc_portion_history

}//namespace cfmc.quotas.db_controllers

            