
//=============================================================================
// data_regime - данные записи таблицы regime ВИД ПРОМЫСЛА
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         13-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas.db_objects
{

    public class data_regime
    {
        /// <summary>
        /// field_regime - сопоставление полей с полями запроса
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
            this.init_id_regime( data_row );
            this.init_regime( data_row );
            this.init_mode( data_row );
            this.init_regime_order( data_row );
        }
        /// <summary>
        /// init_id_regime( object[] data_row ) - 
        /// инициализация значения id_regime
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_id_regime( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_regime.id_regime ) &&
                ( data_row[(int)field_regime.id_regime] != null )
              )
            {
                try
                {
                    this.id_regime = Convert.ToInt32( data_row[(int)field_regime.id_regime] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_regime( object[] data_row ) - 
        /// инициализация значения regime
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_regime( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_regime.regime ) &&
                ( data_row[(int)field_regime.regime] != null )
              )
            {
                try
                {
                    this.regime = Convert.ToString( data_row[(int)field_regime.regime] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_mode( object[] data_row ) - 
        /// инициализация значения mode
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_mode( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_regime.mode ) &&
                ( data_row[(int)field_regime.mode] != null )
              )
            {
                try
                {
                    this.mode = Convert.ToInt32( data_row[(int)field_regime.mode] );
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// init_regime_order( object[] data_row ) - 
        /// инициализация значения regime_order
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        private void init_regime_order( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_regime.regime_order ) &&
                ( data_row[(int)field_regime.regime_order] != null )
              )
            {
                try
                {
                    this.regime_order = Convert.ToString( data_row[(int)field_regime.regime_order] );
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

            