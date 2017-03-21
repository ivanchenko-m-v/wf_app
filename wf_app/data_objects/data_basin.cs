//=============================================================================
// data_basin - данные записи таблицы [basin] БАССЕЙН ПРОМЫСЛА
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
    /// public class data_basin
    /// - данные записи таблицы [basin] БАССЕЙН ПРОМЫСЛА
    /// </summary>
    public class data_basin
    {
        /// <summary>
        /// field_basin - сопоставление полей с полями запроса
        /// </summary>
        enum field_basin : int
        {
            id_basin = 0,
            basin = 1,
            basin_abbr = 2,
            fields_count = 3
        }

        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_basin()
        {
            this.initialize( );
        }
        public data_basin( object[] data_row )
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
        /// id_basin
        /// поле запроса - id_basin
        /// Идентификатор бассейна промысла
        /// </summary>
        public int id_basin { get; set; }
        /// <summary>
        /// basin
        /// поле запроса - basin
        /// Бассейн промысла
        /// </summary>
        public string basin { get; set; }
        /// <summary>
        /// basin_abbr
        /// поле запроса - basin_abbr
        /// Аббревиатура бассейна промысла
        /// </summary>
        public string basin_abbr { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        /// <summary>
        /// initialize( )
        /// - инициализация свойств по умолчанию
        /// </summary>
        private void initialize( )
        {
            this.id_basin = 0;
            this.basin = "";
            this.basin_abbr = "";
        }
        /// <summary>
        /// initialize(object[] data) - 
        /// инициализация свойств из массива значений
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void initialize(object[] data_row)
        {
            if( data_row == null )
            {
                return;
            }
            //init fields
            this.id_basin = helper.cvt_field_int( data_row, (int)field_basin.id_basin );
            this.basin = helper.cvt_field_string( data_row, (int)field_basin.basin );
            this.basin_abbr = helper.cvt_field_string( data_row, (int)field_basin.basin_abbr );
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
            if( this.id_basin == 0 )
            {
                return "";
            }
            return String.Format( "{0,3}. {1} {2,6}", id_basin, basin, basin_abbr );
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

    }//class data_basin

}//namespace cfmc.quotas.db_objects

            