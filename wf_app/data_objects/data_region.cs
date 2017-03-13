
//=============================================================================
// data_region - данные записи таблицы region РАЙОН(ЗОНА) ПРОМЫСЛА
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         13-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas.db_objects
{

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
        void initialize( )
        {
            this.id_region = 0;
            this.region = "";
            this.note = "";
            this.id_region_osm = 0;
            this.region_order = "";
            this.sorting = 0x7FFFFFFF;
        }

        private void initialize( object[] data_row )
        {
            if( data_row == null )
            {
                return;
            }
            //init fields
            this.init_id_region( data_row );
            this.init_region( data_row );
            this.init_note( data_row );
            this.init_region_order( data_row );
            this.init_id_region_osm( data_row );
            this.init_sorting( data_row );
        }

        /// <summary>
        /// init_id_region( object[] data_row ) - 
        /// инициализация значения id_region
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_id_region( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_region.id_region ) &&
                ( data_row[(int)field_region.id_region] != null )
              )
            {
                try
                {
                    this.id_region = Convert.ToInt32( data_row[(int)field_region.id_region] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_region( object[] data_row ) - 
        /// инициализация значения region
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_region( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_region.region ) &&
                ( data_row[(int)field_region.region] != null )
              )
            {
                try
                {
                    this.region = Convert.ToString( data_row[(int)field_region.region] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_note( object[] data_row ) - 
        /// инициализация значения note
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_note( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_region.note ) &&
                ( data_row[(int)field_region.note] != null )
              )
            {
                try
                {
                    this.note = Convert.ToString( data_row[(int)field_region.note] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_region_order( object[] data_row ) - 
        /// инициализация значения region_order
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_region_order( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_region.region_order ) &&
                ( data_row[(int)field_region.region_order] != null )
              )
            {
                try
                {
                    this.region_order = Convert.ToString( data_row[(int)field_region.region_order] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_id_region_osm( object[] data_row ) - 
        /// инициализация значения id_region_osm
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_id_region_osm( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_region.id_region_osm ) &&
                ( data_row[(int)field_region.id_region_osm] != null )
              )
            {
                try
                {
                    this.id_region_osm = Convert.ToInt32( data_row[(int)field_region.id_region_osm] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_sorting( object[] data_row ) - 
        /// инициализация значения sorting
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_sorting( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_region.sorting ) &&
                ( data_row[(int)field_region.sorting] != null )
              )
            {
                try
                {
                    this.sorting = Convert.ToInt32( data_row[(int)field_region.sorting] );
                }
                catch
                {
                }
            }
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

            