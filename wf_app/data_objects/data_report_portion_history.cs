
//=============================================================================
// data_report_portion_history - данные строки результата запроса выборки
//                               истории движения доли при реорганизации 
//                               пользователей ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         15-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using cfmc.utils;

namespace cfmc.quotas.db_objects
{
    /// <summary>
    /// public class data_report_portion_history : IComparable, IDataRow
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
        /// поле запроса - fish
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
        void initialize( object[] data_row )
        {
            if( data_row == null )
            {
                return;
            }
            //init fields
            this.init_id_portion( data_row );
            this.init_basin( data_row );
            this.init_regime( data_row );
            this.init_WBR( data_row );
            this.init_region( data_row );
            this.init_portion( data_row );
            this.init_date_open( data_row );
            this.init_date_close( data_row );
            this.init_report_number( data_row );
            this.init_report_date( data_row );
            this.init_declarant( data_row );
            this.init_INN( data_row );
            this.init_contract_number( data_row );
            this.init_contract_date( data_row );
        }

        private void init_id_portion( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.id_portion ) &&
                ( data_row[(int)field_report_portion_history.id_portion] != null )
              )
            {
                try
                {
                    this.id_portion = Convert.ToInt32( data_row[(int)field_report_portion_history.id_portion] );
                }
                catch
                {
                }
            }
        }

        private void init_basin( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.basin ) &&
                ( data_row[(int)field_report_portion_history.basin] != null )
              )
            {
                try
                {
                    this.basin = Convert.ToString( data_row[(int)field_report_portion_history.basin] );
                }
                catch
                {
                }
            }
        }

        private void init_regime( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.regime ) &&
                ( data_row[(int)field_report_portion_history.regime] != null )
              )
            {
                try
                {
                    this.regime = Convert.ToString( data_row[(int)field_report_portion_history.regime] );
                }
                catch
                {
                }
            }
        }

        private void init_WBR( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.WBR ) &&
                ( data_row[(int)field_report_portion_history.WBR] != null )
              )
            {
                try
                {
                    this.WBR = Convert.ToString( data_row[(int)field_report_portion_history.WBR] );
                }
                catch
                {
                }
            }
        }

        private void init_region( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.region ) &&
                ( data_row[(int)field_report_portion_history.region] != null )
              )
            {
                try
                {
                    this.region = Convert.ToString( data_row[(int)field_report_portion_history.region] );
                }
                catch
                {
                }
            }
        }

        private void init_portion( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.portion ) &&
                ( data_row[(int)field_report_portion_history.portion] != null )
              )
            {
                try
                {
                    this.portion = Convert.ToDecimal( data_row[(int)field_report_portion_history.portion] );
                }
                catch
                {
                }
            }
        }

        private void init_date_open( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.date_open ) &&
                ( data_row[(int)field_report_portion_history.date_open] != null )
              )
            {
                try
                {
                    this.date_open = Convert.ToString( data_row[(int)field_report_portion_history.date_open] );
                }
                catch
                {
                }
            }
        }

        private void init_date_close( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.date_close ) &&
                ( data_row[(int)field_report_portion_history.date_close] != null )
              )
            {
                try
                {
                    this.date_close = Convert.ToString( data_row[(int)field_report_portion_history.date_close] );
                }
                catch
                {
                }
            }
        }

        private void init_report_number( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.report_number ) &&
                ( data_row[(int)field_report_portion_history.report_number] != null )
              )
            {
                try
                {
                    this.report_number = Convert.ToString( data_row[(int)field_report_portion_history.report_number] );
                }
                catch
                {
                }
            }
        }

        private void init_report_date( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.report_date ) &&
                ( data_row[(int)field_report_portion_history.report_date] != null )
              )
            {
                try
                {
                    this.report_date = Convert.ToString( data_row[(int)field_report_portion_history.report_date] );
                }
                catch
                {
                }
            }
        }

        private void init_declarant( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.declarant ) &&
                ( data_row[(int)field_report_portion_history.declarant] != null )
              )
            {
                try
                {
                    this.declarant = Convert.ToString( data_row[(int)field_report_portion_history.declarant] );
                }
                catch
                {
                }
            }
        }

        private void init_INN( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.INN ) &&
                ( data_row[(int)field_report_portion_history.INN] != null )
              )
            {
                try
                {
                    this.INN = Convert.ToString( data_row[(int)field_report_portion_history.INN] );
                }
                catch
                {
                }
            }
        }

        private void init_contract_number( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.contract_number ) &&
                ( data_row[(int)field_report_portion_history.contract_number] != null )
              )
            {
                try
                {
                    this.contract_number = Convert.ToString( data_row[(int)field_report_portion_history.contract_number] );
                }
                catch
                {
                }
            }
        }

        private void init_contract_date( object[] data_row )
        {
            if(
                ( data_row.Length > (int)field_report_portion_history.contract_date ) &&
                ( data_row[(int)field_report_portion_history.contract_date] != null )
              )
            {
                try
                {
                    this.contract_date = Convert.ToString( data_row[(int)field_report_portion_history.contract_date] );
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

            