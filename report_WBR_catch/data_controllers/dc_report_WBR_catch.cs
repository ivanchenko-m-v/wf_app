//=============================================================================
// REPORT_WBR_CATCH
// dc_report_WBR_catch - класс взаимодействия с БД для объектов данных data_report_WBR_catch
// Автор: Иванченко М.В.
// Дата начала разработки:  23-03-2017
// Дата обновления:         23-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using cfmc.quotas.db_objects;
using cfmc.utils;

namespace cfmc.quotas.db_controllers
{
    using list_report_WBR_catch = List<IDataRow>;
    /// <summary>
    /// public class dc_report_WBR_catch
    /// - класс взаимодействия с БД для объектов данных data_report_WBR_catch
    /// </summary>
    public class dc_report_WBR_catch
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public dc_report_WBR_catch( )
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
        public list_report_WBR_catch data { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize( )
        {
            this.data = new list_report_WBR_catch( );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// select( params_report_WBR_catch prm )
        /// </summary>
        /// <param name="prm">
        /// заполненная структура параметров вызова хранимой процедуры сервера
        /// </param>
        public void select( params_report_WBR_catch prm )
        {
            if(
                prm.year_1st == 0 || prm.year_2nd == 0 ||
                prm.percent == 0 || prm.stat_type.Length == 0
              )
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
                cmd.CommandText = "[sp_fishing_2years_v3]";
                cmd.Parameters.AddRange( 
                                        new SqlParameter[]
                                        {
                                            new SqlParameter( "@nYear1", prm.year_1st ),
                                            new SqlParameter( "@nYear2", prm.year_2nd ),
                                            new SqlParameter( "@nPercent", prm.percent ),
                                            new SqlParameter( "@StatType", prm.stat_type ),
                                            new SqlParameter( "@id_subject", prm.id_subject ),
                                            new SqlParameter( "@id_regime", prm.id_regime ),
                                            new SqlParameter( "@id_region", prm.id_region ),
                                            new SqlParameter( "@id_WBR", prm.id_WBR ),
                                            new SqlParameter( "@id_declarant", prm.id_declarant ),
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
                        this.data.Add( new data_report_WBR_catch( data_row ) );
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

    }//class dc_report_WBR_catch

}//namespace cfmc.quotas.db_controllers

            