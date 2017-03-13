
//=============================================================================
// data_WBR - данные записи таблицы fish ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         13-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas.db_objects
{
    public class data_WBR
    {
        /// <summary>
        /// field_WBR - сопоставление полей с полями запроса
        /// </summary>
        enum field_WBR : int
        {
            id_fish = 0,
            fish = 1,
            note =2,
            id_fish_osm = 3,
            fish_order = 4,
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
        /// id_fish
        /// поле запроса - id_fish
        /// Идентификатор ВБР
        /// </summary>
        public int id_fish { get; set; }
        /// <summary>
        /// fish
        /// поле запроса - fish
        /// ВБР
        /// </summary>
        public string fish { get; set; }
        /// <summary>
        /// note
        /// поле запроса - note
        /// Примечание
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// fish_order
        /// поле запроса - fish_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string fish_order { get; set; }
        /// <summary>
        /// id_fish_osm
        /// поле запроса - id_fish_osm
        /// Код в ОСМ
        /// </summary>
        public int id_fish_osm { get; set; }
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
            this.id_fish = 0;
            this.fish = "";
            this.note = "";
            this.id_fish_osm = 0;
            this.fish_order = "";
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
            this.init_id_fish( data_row );
            this.init_fish( data_row );
            this.init_note( data_row );
            this.init_fish_order( data_row );
            this.init_id_fish_osm( data_row );
            this.init_sorting( data_row );
        }
        /// <summary>
        /// init_id_fish( object[] data_row ) - 
        /// инициализация значения id_fish
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_id_fish( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_WBR.id_fish ) &&
                ( data_row[(int)field_WBR.id_fish] != null )
              )
            {
                try
                {
                    this.id_fish = Convert.ToInt32( data_row[(int)field_WBR.id_fish] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_fish( object[] data_row ) - 
        /// инициализация значения fish
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_fish( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_WBR.fish ) &&
                ( data_row[(int)field_WBR.fish] != null )
              )
            {
                try
                {
                    this.fish = Convert.ToString( data_row[(int)field_WBR.fish] );
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
                ( data_row.Length > (int)field_WBR.note ) &&
                ( data_row[(int)field_WBR.note] != null )
              )
            {
                try
                {
                    this.note = Convert.ToString( data_row[(int)field_WBR.note] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_fish_order( object[] data_row ) - 
        /// инициализация значения fish_order
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_fish_order( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_WBR.fish_order ) &&
                ( data_row[(int)field_WBR.fish_order] != null )
              )
            {
                try
                {
                    this.fish_order = Convert.ToString( data_row[(int)field_WBR.fish_order] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_id_fish_osm( object[] data_row ) - 
        /// инициализация значения id_fish_osm
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_id_fish_osm( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_WBR.id_fish_osm ) &&
                ( data_row[(int)field_WBR.id_fish_osm] != null )
              )
            {
                try
                {
                    this.id_fish_osm = Convert.ToInt32( data_row[(int)field_WBR.id_fish_osm] );
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
                ( data_row.Length > (int)field_WBR.sorting ) &&
                ( data_row[(int)field_WBR.sorting] != null )
              )
            {
                try
                {
                    this.sorting = Convert.ToInt32( data_row[(int)field_WBR.sorting] );
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
            if( this.id_fish == 0 )
            {
                return "";
            }
            return String.Format( "{0}. \t{1}", id_fish, fish );
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

            