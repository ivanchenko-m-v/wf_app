
//=============================================================================
// REPORT_WBR_CATCH
// business_logic - класс бизнес-логики приложения
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         24-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;

using cfmc.utils;
using cfmc.quotas.resources;

namespace cfmc.quotas
{
    /// <summary>
    /// public static class business_logic
    /// </summary>
    public static class business_logic
    {
        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// excel_producer - 
        /// объект для экспорта данных в Excel
        /// </summary>
        public static excel_producer excel_producer { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        /// <summary>
        /// init_data_store - инициализация хранилища данных
        /// </summary>
        public static void init_data_store( )
        {
            //regimes
            data_model_store.init_regimes( );
            //WBRs
            data_model_store.init_WBRs( );
            //regions
            data_model_store.init_regions( );
            //subjects
            data_model_store.init_subjects( );
        }
        /// <summary>
        /// init_excel_producer( ) - 
        /// инициализация объекта экспорта данных
        /// </summary>
        public static void init_excel_producer( )
        {
            business_logic.excel_producer = new excel_producer( );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// select_report_data( db_objects.params_report_WBR_catch prm )
        /// </summary>
        /// <param name="prm">параметры заданные пользователем</param>
        public static void select_report_data( db_objects.params_report_WBR_catch prm )
        {
            data_model_store.select_report_WBR_catch( prm );
        }
        /// <summary>
        /// export_report_catch( int y1, int y2 )
        /// </summary>
        /// <param name="y1">1й год вылова, за кот собраны данные</param>
        /// <param name="y2">2й год вылова, за кот собраны данные</param>
        public static void export_report_catch( int y1, int y2 )
        {
            //init export object header
            business_logic.excel_producer.header = new string[]
            {
                rc_report_catch.column_regime,
                rc_report_catch.column_declarant,
                rc_report_catch.column_inn,
                rc_report_catch.column_fish,
                rc_report_catch.column_region,
                rc_report_catch.column_subject,
                rc_report_catch.column_portion,
                String.Format("{0}, {1}", rc_report_catch.column_limit, y1.ToString()),
                String.Format("{0}, {1}", rc_report_catch.column_catch, y1.ToString()),
                String.Format("{0}, {1}", rc_report_catch.column_percent, y1.ToString()),
                String.Format("{0}, {1}", rc_report_catch.column_limit, y2.ToString()),
                String.Format("{0}, {1}", rc_report_catch.column_catch, y2.ToString()),
                String.Format("{0}, {1}", rc_report_catch.column_percent, y2.ToString())
            };
            //init excelworksheet columns width
            business_logic.excel_producer.column_widths = new int[]
            {
                30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30
            };

            //init export object data
            business_logic.excel_producer.data = data_model_store.report_catch_data;

            business_logic.excel_producer.export_excel_book( );
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

    }//class business_logic

}//namespace cfmc.quotas

            