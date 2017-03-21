//=============================================================================
// data_regime - данные записи таблицы [regime] ВИД ПРОМЫСЛА
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
    /// public class data_regime
    /// </summary>
    public class data_regime
    {
        /// <summary>
        /// field_regime - сопоставление полей с полями запроса
        /// - данные записи таблицы [regime] ВИД ПРОМЫСЛА
        /// </summary>
        enum field_regime : int
        {
            id_regime = 0,
            regime = 1,
            mode = 2,
            regime_order = 3,
            fields_count = 4
        }

        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__
        public data_regime( )
        {
            this.initialize( );
        }
        public data_regime( object[] data_row )
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
        /// id_regime
        /// поле запроса - id_regime
        /// Идентификатор вида промысла
        /// </summary>
        public int id_regime { get; set; }
        /// <summary>
        /// regime
        /// поле запроса - regime
        /// Вид промысла
        /// </summary>
        public string regime { get; set; }
        /// <summary>
        /// mode
        /// поле запроса - mode
        /// Признак разделения между субъектами РФ
        /// </summary>
        public int mode { get; set; }
        /// <summary>
        /// regime
        /// поле запроса - regime_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string regime_order { get; set; }
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
        void initialize( )
        {
            this.id_regime = 0;
            this.regime = "";
            this.mode = -1;
            this.regime_order = "";
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
            this.id_regime = helper.cvt_field_int( data_row, (int)field_regime.id_regime );
            this.regime = helper.cvt_field_string( data_row, (int)field_regime.regime );
            this.mode = helper.cvt_field_int( data_row, (int)field_regime.mode );
            this.regime_order = helper.cvt_field_string( data_row, (int)field_regime.regime_order );
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
            if( this.id_regime == 0 )
            {
                return "";
            }
            return regime;
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

    }//class data_regime

}//namespace cfmc.quotas.db_objects

            