
//=============================================================================
// data_report_portion_history - данные строки результата запроса выборки
//                               истории движения доли при реорганизации 
//                               пользователей ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         10-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas.db_objects
{

    public class data_report_portion_history
    {
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
        public DateTime date_open { get; set; }
        /// <summary>
        /// date_close
        /// поле запроса - date_close
        /// Дата окончания действия
        /// </summary>
        public DateTime date_close { get; set; }
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
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize()
        {
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
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

            