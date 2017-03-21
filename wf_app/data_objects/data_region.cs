//=============================================================================
// data_region - данные записи таблицы [region] РАЙОН(ЗОНА) ПРОМЫСЛА
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
    /// public class data_region
    /// - данные записи таблицы [region] РАЙОН(ЗОНА) ПРОМЫСЛА
    /// </summary>
    public class data_region
    {
        /// <summary>
        /// field_region - сопоставление полей с полями запроса
        /// </summary>
        enum field_region : int
        {
            id_region = 0,
            region = 1,
            note = 2,
            id_region_osm = 3,
            region_order = 4,
            sorting = 5,
            fields_count = 6
        }

        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_region( )
        {
            this.initialize( );
        }
        public data_region( object[] data_row )
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
        /// id_region
        /// поле запроса - id_region
        /// Идентификатор района промысла
        /// </summary>
        public int id_region { get; set; }
        /// <summary>
        /// region
        /// поле запроса - region
        /// Район промысла
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// note
        /// поле запроса - note
        /// Примечание
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// region_order
        /// поле запроса - region_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string region_order { get; set; }
        /// <summary>
        /// id_region_osm
        /// поле запроса - id_region_osm
        /// Код в ОСМ
        /// </summary>
        public int id_region_osm { get; set; }
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
            this.id_region = 0;
            this.region = "";
            this.note = "";
            this.id_region_osm = 0;
            this.region_order = "";
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
            this.id_region = helper.cvt_field_int( data_row, (int)field_region.id_region );
            this.region = helper.cvt_field_string( data_row, (int)field_region.region );
            this.note = helper.cvt_field_string( data_row, (int)field_region.note );
            this.id_region_osm = helper.cvt_field_int( data_row, (int)field_region.id_region_osm );
            this.region_order = helper.cvt_field_string( data_row, (int)field_region.region_order );
            this.sorting = helper.cvt_field_int( data_row, (int)field_region.sorting );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        public override string ToString( )
        {
            if( this.id_region == 0 )
            {
                return "";
            }
            return String.Format( "{0}. \t{1}", id_region, region );
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

    }//class data_region

}//namespace cfmc.quotas.db_objects

            