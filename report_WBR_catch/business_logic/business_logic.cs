
//=============================================================================
// REPORT_WBR_CATCH
// business_logic - класс бизнес-логики приложения
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         22-03-2017
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
            /*
        /// <summary>
        /// export_portions_history( ) - 
        /// экспортирует выбанные данные движения долей в книгу Excel
        /// </summary>
        public static void export_portions_history( )
        {
            //init export object header
            business_logic.excel_producer.header = new string[]
            {
                resource_portions_history.column_id,
                resource_portions_history.column_basin,
                resource_portions_history.column_regime,
                resource_portions_history.column_WBR,
                resource_portions_history.column_region,
                resource_portions_history.column_portion,
                resource_portions_history.column_date_open,
                resource_portions_history.column_date_close,
                resource_portions_history.column_report_number,
                resource_portions_history.column_report_date,
                resource_portions_history.column_declarant,
                resource_portions_history.column_INN,
                resource_portions_history.column_contract_number,
                resource_portions_history.column_contract_date
            };
            //init excelworksheet columns width
            business_logic.excel_producer.column_widths = new int[]
            {
                30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30
            };

            //init export object data
            business_logic.excel_producer.data = data_model_store.portions;

            business_logic.excel_producer.export_excel_book( );
        }
        */
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

            