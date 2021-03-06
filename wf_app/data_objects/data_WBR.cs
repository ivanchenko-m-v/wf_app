﻿//=============================================================================
// data_WBR - данные записи таблицы [WBR] ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         21-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;

using cfmc.utils;

namespace cfmc.quotas.db_objects
{
    /// <summary>
    /// public class data_WBR
    /// - данные записи таблицы [WBR] ВБР
    /// </summary>
    public class data_WBR
    {
        /// <summary>
        /// field_WBR - сопоставление полей с полями запроса
        /// </summary>
        enum field_WBR : int
        {
            id_WBR = 0,
            WBR = 1,
            note =2,
            id_WBR_osm = 3,
            WBR_order = 4,
            sorting = 5,
            fields_count = 6
        }

        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_WBR( )
        {
            this.initialize( );
        }
        public data_WBR( object[] data_row )
        {
            this.initialize( data_row );
        }
        #endregion //__CONSTRUCTION__	

        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// id_WBR
        /// поле запроса - id_WBR
        /// Идентификатор ВБР
        /// </summary>
        public int id_WBR { get; set; }
        /// <summary>
        /// WBR
        /// поле запроса - WBR
        /// ВБР
        /// </summary>
        public string WBR { get; set; }
        /// <summary>
        /// note
        /// поле запроса - note
        /// Примечание
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// WBR_order
        /// поле запроса - WBR_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string WBR_order { get; set; }
        /// <summary>
        /// id_WBR_osm
        /// поле запроса - id_WBR_osm
        /// Код в ОСМ
        /// </summary>
        public int id_WBR_osm { get; set; }
        /// <summary>
        /// sorting
        /// поле запроса - sorting
        /// Порядок сортировки
        /// </summary>
        public int sorting { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        /// <summary>
        /// initialize( ) - инициализация свойств по умолчанию
        /// </summary>
        void initialize( )
        {
            this.id_WBR = 0;
            this.WBR = "";
            this.note = "";
            this.id_WBR_osm = 0;
            this.WBR_order = "";
            this.sorting = 0x7FFFFFFF;
        }
        /// <summary>
        /// initialize(object[] data) - 
        /// инициализация свойств из массива значений
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void initialize( object[] data_row )
        {
            if( data_row == null )
            {
                return;
            }
            //init fields
            this.id_WBR = helper.cvt_field_int( data_row, (int)field_WBR.id_WBR );
            this.WBR = helper.cvt_field_string( data_row, (int)field_WBR.WBR );
            this.note = helper.cvt_field_string( data_row, (int)field_WBR.note );
            this.id_WBR_osm = helper.cvt_field_int( data_row, (int)field_WBR.id_WBR_osm );
            this.WBR_order = helper.cvt_field_string( data_row, (int)field_WBR.WBR_order );
            this.sorting = helper.cvt_field_int( data_row, (int)field_WBR.sorting );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// ToString( )
        /// </summary>
        /// <returns></returns>
        public override string ToString( )
        {
            if( this.id_WBR == 0 )
            {
                return "";
            }
            return String.Format( "{0}. \t{1}", id_WBR, WBR );
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

    }//class data_WBR

}//namespace cfmc.quotas.db_objects

            