
//=============================================================================
// data_basin - данные записи таблицы basin БАССЕЙН ПРОМЫСЛА
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         13-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Text;

namespace cfmc.quotas.db_objects
{

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
            this.id_basin = 0;
            this.basin = "";
            this.basin_abbr = "";
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
            this.init_id_basin(data_row);
            this.init_basin(data_row);
            this.init_basin_abbr(data_row);
        }
        /// <summary>
        /// init_id_basin(object[] data_row) - 
        /// инициализация значения id_basin
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        void init_id_basin( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_basin.id_basin ) &&
                ( data_row[(int)field_basin.id_basin] != null )
              )
            {
                try
                {
                    this.id_basin = Convert.ToInt32( data_row[(int)field_basin.id_basin] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_basin(object[] data_row) - 
        /// инициализация значения basin
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        void init_basin(object[] data_row)
        {
            if (
                (data_row.Length > (int)field_basin.basin) &&
                (data_row[(int)field_basin.basin] != null)
              )
            {
                try
                {
                    this.basin = Convert.ToString(data_row[(int)field_basin.basin]);
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_basin_abbr(object[] data_row) - 
        /// инициализация значения basin_abbr
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        void init_basin_abbr(object[] data_row)
        {
            if (
                (data_row.Length > (int)field_basin.basin_abbr) &&
                (data_row[(int)field_basin.basin_abbr] != null)
              )
            {
                try
                {
                    this.basin_abbr = Convert.ToString(data_row[(int)field_basin.basin_abbr]);
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
        public override string ToString()
        {
            if(this.id_basin==0)
            {
                return "";
            }
            return String.Format("{0}. \t{1} \t{2}", id_basin, basin, basin_abbr);
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

            