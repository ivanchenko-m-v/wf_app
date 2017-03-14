
//=============================================================================
// data_model_store - хранилище данных списков в ОЗУ
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         14-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;

using cfmc.quotas.db_objects;

namespace cfmc.quotas
{
    using list_basin = List<data_basin>;
    using list_regime = List<data_regime>;
    using list_region = List<data_region>;
    using list_WBR = List<data_WBR>;
    using list_portion_history = List<data_report_portion_history>;

    public static class data_model_store
    {
        public static event EventHandler<EventArgs> PortionsSelected = null;
        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// basins - 
        /// список бассейнов промысла
        /// </summary>
        public static list_basin basins { get; set; }
        /// <summary>
        /// regimes - 
        /// список видов промысла
        /// </summary>
        public static list_regime regimes { get; set; }
        /// <summary>
        /// regions -
        /// список районов(зон) промысла
        /// </summary>
        public static list_region regions { get; set; }
        /// <summary>
        /// WBRs -
        /// список ВБР
        /// </summary>
        public static list_WBR WBRs { get; set; }
        /// <summary>
        /// portions - 
        /// результаты запроса [sp_portions_history]
        /// </summary>
        public static list_portion_history portions { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        /// <summary>
        /// init_basins( ) - инициализация списка бассейнов промысла
        /// </summary>
        public static void init_basins( )
        {
            db_controllers.dc_basin dc_basin = new db_controllers.dc_basin( );
            dc_basin.select( );
            if( data_model_store.basins == null )
            {
                data_model_store.basins = new list_basin( );
            }
            data_model_store.basins = dc_basin.data;
            //for empty string in the combobox_basin
            data_model_store.basins.Insert( 0, new db_objects.data_basin( ) );
        }
        /// <summary>
        /// init_regimes( ) - инициализация списка видов промысла
        /// </summary>
        public static void init_regimes( )
        {
            db_controllers.dc_regime dc_regime = new db_controllers.dc_regime( );
            dc_regime.select( );
            if( data_model_store.regimes == null )
            {
                data_model_store.regimes = new list_regime( );
            }
            data_model_store.regimes = dc_regime.data;
        }
        /// <summary>
        /// init_regions( ) - инициализация списка районов(зон) промысла
        /// </summary>
        public static void init_regions( )
        {
            db_controllers.dc_region dc_region = new db_controllers.dc_region( );
            dc_region.select( );
            if( data_model_store.regions == null )
            {
                data_model_store.regions = new list_region( );
            }
            data_model_store.regions = dc_region.data;
        }
        /// <summary>
        /// init_WBRs( ) - инициализация списка ВБР
        /// </summary>
        public static void init_WBRs( )
        {
            db_controllers.dc_WBR dc_WBR = new db_controllers.dc_WBR( );
            dc_WBR.select( );
            if( data_model_store.WBRs == null )
            {
                data_model_store.WBRs = new list_WBR( );
            }
            data_model_store.WBRs = dc_WBR.data;
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
            db_controllers.dc_portion_history dc_portions 
                                    = new db_controllers.dc_portion_history( );

            dc_portions.select( id_basin, id_regime, id_WBR, id_region );

            if( data_model_store.portions == null )
            {
                data_model_store.portions = new list_portion_history( );
            }
            data_model_store.portions = dc_portions.data;

            //notify subscribers about selection has finished
            data_model_store.on_portions_select_complete( );
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        private static void on_portions_select_complete( )
        {
            EventHandler<EventArgs> handler = PortionsSelected;
            if( handler != null )
            {
                handler( null, new EventArgs( ) );
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

    }//class data_model_store

}//namespace cfmc.quotas

            