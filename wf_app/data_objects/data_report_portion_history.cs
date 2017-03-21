//=============================================================================
// data_report_portion_history - данные строки результата запроса выборки
//                               истории движения доли при реорганизации 
//                               пользователей ВБР [sp_portion_history]
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
    /// public class data_report_portion_history : IComparable, IDataRow
    /// - данные строки результата запроса выборки
    //    истории движения доли при реорганизации 
    //    пользователей ВБР [sp_portion_history]
    /// </summary>
    public class data_report_portion_history : IComparable, IDataRow
    {
        /// <summary>
        /// field_report_portion_history - 
        /// сопоставление полей с полями запроса
        /// </summary>
        public enum field_report_portion_history : int
        {
            id_portion = 0,
            basin = 1,
            regime = 2,
            WBR = 3,
            region = 4,
            portion = 5,
            date_open = 6,
            date_close = 7,
            report_number = 8,
            report_date = 9,
            declarant = 10,
            INN = 11,
            contract_number = 12,
            contract_date = 13,
            fields_count = 14
        }
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_report_portion_history()
        {
            this.initialize();
        }
        public data_report_portion_history( object[] data_row )
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
        /// id_portion
        /// поле запроса - id_portion
        /// Идентификатор доли
        /// </summary>
        public int id_portion { get; set; }
        /// <summary>
        /// basin
        /// поле запроса - basin
        /// Бассейн промысла
        /// </summary>
        public string basin { get; set; }
        /// <summary>
        /// regime
        /// поле запроса - regime
        /// Вид промысла
        /// </summary>
        public string regime { get; set; }
        /// <summary>
        /// WBR
        /// поле запроса - WBR
        /// ВБР
        /// </summary>
        public string WBR { get; set; }
        /// <summary>
        /// region
        /// поле запроса - region
        /// Район(зона) промысла
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// portion
        /// поле запроса - portion
        /// Доля(размер доли пользователя ВБР в процентах)
        /// </summary>
        public decimal portion { get; set; }
        /// <summary>
        /// date_open
        /// поле запроса - date_open
        /// Дата начала действия
        /// </summary>
        public string date_open { get; set; }
        /// <summary>
        /// date_close
        /// поле запроса - date_close
        /// Дата окончания действия
        /// </summary>
        public string date_close { get; set; }
        /// <summary>
        /// report_number
        /// поле запроса - report_number
        /// Номер протокола утверждения
        /// </summary>
        public string report_number { get; set; }
        /// <summary>
        /// report_date
        /// поле запроса - report_date
        /// Дата протокола утверждения
        /// </summary>
        public string report_date { get; set; }
        /// <summary>
        /// declarant
        /// поле запроса - declarant
        /// Пользователь ВБР
        /// </summary>
        public string declarant { get; set; }
        /// <summary>
        /// INN
        /// поле запроса - INN
        /// ИНН пользователя ВБР
        /// </summary>
        public string INN { get; set; }
        /// <summary>
        /// contract_number
        /// поле запроса - contract_number
        /// Номер договора
        /// </summary>
        public string contract_number { get; set; }
        /// <summary>
        /// contract_date
        /// поле запроса - contract_date
        /// Дата договора
        /// </summary>
        public string contract_date { get; set; }
        /// <summary>
        /// record_fields_count - 
        /// количество полей в записи результатов запроса
        /// </summary>
        public int record_fields_count
        {
            get
            {
                return (int)field_report_portion_history.fields_count;
            }
        }
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
            this.id_portion = 0;
            this.basin = "";
            this.regime = "";
            this.WBR = "";
            this.region = "";
            this.portion = 0.0M;
            this.date_open = "";
            this.date_close = "";
            this.report_number = "";
            this.report_date = "";
            this.declarant = "";
            this.INN = "";
            this.contract_number = "";
            this.contract_date = "";
        }
        /// <summary>
        /// initialize(object[] data) - 
        /// инициализация свойств из массива значений
        /// </summary>
        /// <param name="data_row">массив значений полей строки результатов запроса</param>
        void initialize( object[] data_row )
        {
            if( data_row == null )
            {
                return;
            }
            //init fields
            this.id_portion = helper.cvt_field_int( data_row, (int)field_report_portion_history.id_portion );
            this.basin = helper.cvt_field_string( data_row, (int)field_report_portion_history.basin );
            this.regime = helper.cvt_field_string( data_row, (int)field_report_portion_history.regime );
            this.WBR = helper.cvt_field_string( data_row, (int)field_report_portion_history.WBR );
            this.region = helper.cvt_field_string( data_row, (int)field_report_portion_history.region );
            this.portion = helper.cvt_field_decimal( data_row, (int)field_report_portion_history.portion );
            this.date_open = helper.cvt_field_string( data_row, (int)field_report_portion_history.date_open );
            this.date_close = helper.cvt_field_string( data_row, (int)field_report_portion_history.date_close );
            this.report_number = helper.cvt_field_string( data_row, (int)field_report_portion_history.report_number );
            this.report_date = helper.cvt_field_string( data_row, (int)field_report_portion_history.report_date );
            this.declarant = helper.cvt_field_string( data_row, (int)field_report_portion_history.declarant );
            this.INN = helper.cvt_field_string( data_row, (int)field_report_portion_history.INN );
            this.contract_number = helper.cvt_field_string( data_row, (int)field_report_portion_history.contract_number );
            this.contract_date = helper.cvt_field_string( data_row, (int)field_report_portion_history.contract_date );
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        public string to_compare_string( )
        {
            return String.Format( "{0}_{1}", this.id_portion, this.date_open );
        }
        /// <summary>
        /// CompareTo( object obj ) - 
        /// реализация интерфейса IComparable
        /// </summary>
        /// <param name="obj">объект для сравнения с this</param>
        /// <returns></returns>
        public int CompareTo( object obj )
        {
            if( obj == null )
            {
                return 1;
            }
            data_report_portion_history data = obj as data_report_portion_history;
            if( this.id_portion == data.id_portion )
            {
                return this.date_open.CompareTo( data.date_open );
            }
            return this.id_portion < data.id_portion ? -1 : 1;
        }
        /// <summary>
        /// Fields( ) -
        /// реализация интерфейса IDataRow
        /// </summary>
        /// <returns>массив значений ячеек для строки листа Excel</returns>
        public object[] Fields( )
        {
            object[] obj = new object[]
            {
                this.id_portion,
                this.basin,
                this.regime,
                this.WBR,
                this.region,
                this.portion,
                this.date_open,
                this.date_close,
                this.report_number,
                this.report_date,
                this.declarant,
                this.INN,
                this.contract_number,
                this.contract_date
            };

            return obj;
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

    }//class data_report_portion_history

}//namespace cfmc.quotas.db_objects

            