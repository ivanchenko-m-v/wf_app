
//=============================================================================
// business_logic - класс бизнес-логики приложения
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         17-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
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
        public static event EventHandler<EventArgs> PortionsSelected = null;
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
            //basins
            data_model_store.init_basins( );
            //regimes
            data_model_store.init_regimes( );
            //WBRs
            data_model_store.init_WBRs( );
            //regions
            data_model_store.init_regions( );
            //portions history
            data_model_store.PortionsSelected += Data_model_store_PortionsSelected;
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
        /// select_portions_history(...) - 
        /// выборка данных движения долей при реорганизации пользователей ВБР
        /// </summary>
        /// <param name="id_basin">идентификатор бассейна промысла</param>
        /// <param name="id_regime">идентификатор вида промысла</param>
        /// <param name="id_WBR">идентификатор ВБР</param>
        /// <param name="id_region">идентификатор района промысла</param>
        public static void select_portions_history( 
                                                    int id_basin, int id_regime,
                                                    int id_WBR, int id_region 
                                                  )
        {
            data_model_store.select_portions_history( 
                                                     id_basin, id_regime, 
                                                     id_WBR, id_region 
                                                    );
        }
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
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        /// <summary>
        /// Data_model_store_PortionsSelected - 
        /// Уведомление подписчиков об окончании выборки данных
        /// движения долей
        /// </summary>
        /// <param name="sender">null</param>
        /// <param name="e">empty</param>
        private static void Data_model_store_PortionsSelected( object sender, EventArgs e )
        {
            if( business_logic.PortionsSelected != null )
            {
                business_logic.PortionsSelected( sender, e );
            }
        }
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

            