
//=============================================================================
// business_logic - класс бизнес-логики приложения
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         14-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas
{

    public static class business_logic
    {
        public static event EventHandler<EventArgs> PortionsSelected = null;
        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
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
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
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

            