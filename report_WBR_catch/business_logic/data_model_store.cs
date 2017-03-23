//=============================================================================
// REPORT_WBR_CATCH
// data_model_store - хранилище данных списков в ОЗУ
// Автор: Иванченко М.В.
// Дата начала разработки:  13-03-2017
// Дата обновления:         23-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;

using cfmc.quotas.db_objects;
using cfmc.quotas.db_controllers;
using cfmc.utils;

namespace cfmc.quotas
{
    using list_regime = List<data_regime>;
    using list_region = List<data_region>;
    using list_WBR = List<data_WBR>;
    using list_subject = List<data_subject>;
    using list_declarant = List<data_declarant>;
    using list_report_catch = List<IDataRow>;

    public static class data_model_store
    {
        public static event EventHandler<EventArgs> ReportDataComplete = null;
        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
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
        /// subjects -
        /// список субъектов РФ
        /// </summary>
        public static list_subject subjects { get; set; }
        /// <summary>
        /// declarants -
        /// список пользователей ВБР
        /// </summary>
        public static list_declarant declarants { get; set; }
        /// <summary>
        /// portions - 
        /// результаты запроса [sp_]
        /// </summary>
        public static list_report_catch report_catch_data { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
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
            dc_WBR.select_for_fishing( );
            if( data_model_store.WBRs == null )
            {
                data_model_store.WBRs = new list_WBR( );
            }
            data_model_store.WBRs = dc_WBR.data;
        }
        /// <summary>
        /// init_subjects( ) - инициализация списка субъектов РФ
        /// </summary>
        public static void init_subjects( )
        {
            db_controllers.dc_subject dc_subject = new db_controllers.dc_subject( );
            dc_subject.select( );
            if( data_model_store.subjects == null )
            {
                data_model_store.subjects = new list_subject( );
            }
            data_model_store.subjects = dc_subject.data;
        }

        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// select_declarant( string x_filter )
        /// - выборка пользователей ВБР по фильтру 
        ///   названия или ИНН
        /// </summary>
        /// <param name="x_filter"></param>
        public static void select_declarant( string x_filter )
        {
            dc_declarant dc_declarant = new dc_declarant( );

            dc_declarant.select( x_filter );

            if( data_model_store.declarants == null )
            {
                data_model_store.declarants = new list_declarant( );
            }
            data_model_store.declarants = dc_declarant.data;
        }
        /// <summary>
        /// select_report_WBR_catch( params_report_WBR_catch prm )
        /// - выборка данных отчёта о вылове за 2 года подряд,
        ///   где процент освоения менее заданного
        /// </summary>
        /// <param name="prm">параметры хранимой процедуры сервера</param>
        public static void select_report_WBR_catch( params_report_WBR_catch prm )
        {
            dc_report_WBR_catch dc = new dc_report_WBR_catch( );

            dc.select( prm );

            if( data_model_store.report_catch_data == null )
            {
                data_model_store.report_catch_data = new list_report_catch( );
            }
            data_model_store.report_catch_data = dc.data;
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        private static void on_report_data_complete( )
        {
            EventHandler<EventArgs> handler = ReportDataComplete;
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

            