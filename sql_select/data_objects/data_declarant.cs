//=============================================================================
// data_declarant - объект данных ПОЛЬЗОВАТЕЛЬ ВБР
// Автор:                   М.Иванченко
// Дата начала разработки:  02-03-2017
// Дата обновления:         02-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;

namespace cfmc.quotas.db_objects
{

    class data_declarant
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        data_declarant()
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
        /// id - идентификатор текущего пользователя ВБР
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// id_history - идентификатор пользователя ВБР 
        ///              при создании записи в БД
        /// </summary>
        public int id_history { get; set; }
        /// <summary>
        /// dt_registration - дата регистрации в реестре пользователей ВБР
        /// </summary>
        public DateTime dt_registration { get; set; }
        /// <summary>
        /// dt_expiry - дата прекращения существования/перерегистрации
        /// </summary>
        public DateTime dt_expiry { get; set; }
        /// <summary>
        /// short_title - краткое название
        /// </summary>
        public string short_title { get; set; }
        /// <summary>
        /// case_number - номер дела
        /// </summary>
        public string case_number { get; set; }
        /// <summary>
        /// ownership_form - форма собственности
        /// </summary>
        public string ownership_form { get; set; }
        /// <summary>
        /// address - юридический адрес
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// postal_address - почтовый адрес
        /// </summary>
        public string postal_address { get; set; }
        /// <summary>
        /// director - руководитель организации
        /// </summary>
        public string director { get; set; }
        /// <summary>
        /// phone
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// fax
        /// </summary>
        public string fax { get; set; }
        /// <summary>
        /// telex
        /// </summary>
        public string telex { get; set; }
        /// <summary>
        /// e-mail
        /// </summary>
        public string e_mail { get; set; }
        /// <summary>
        /// title - полное наименование пользователя ВБР
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// INN - индивидуальный номер налогоплательщика
        /// </summary>
        public string INN { get; set; }
        /// <summary>
        /// KPP - КПП (код причины постановки на налоговый учёт)
        /// </summary>
        public string KPP { get; set; }
        /// <summary>
        /// OGRN - код ОГРН
        ///      ((основной государственный регистрационный номер))
        /// </summary>
        public string OGRN { get; set; }
        /// <summary>
        /// OKPO - код ОКПО
        ///      (Общероссийский классификатор предприятий и организаций)
        /// </summary>
        public string OKPO { get; set; }
        /// <summary>
        /// OKATO - код ОКАТО
        ///       (Общероссийский классификатор объектов 
        ///        административно-территориального деления)
        /// </summary>
        public string OKATO { get; set; }
        /// <summary>
        /// OKVED - код ОКВЭД 
        ///       (Общероссийский классификатор видов 
        ///        экономической деятельности)
        /// </summary>
        public string OKVED { get; set; }
        /// <summary>
        /// KOPF - код ОКОПФ 
        ///      (Общероссийский классификатор организационно-правовых форм)
        /// </summary>
        public string KOPF { get; set; }
        /// <summary>
        /// KFS - код ОКФС (Общероссийский классификатор форм собственности)
        /// </summary>
        public string KFS { get; set; }
        /// <summary>
        /// id_CFMS - код пользователя ВБР в ОСМ
        /// </summary>
        public int id_CFMS { get; set; }
        /// <summary>
        /// title_CFMS - название пользователя ВБР в ОСМ
        /// </summary>
        public string title_CFMS { get; set; }
        /// <summary>
        /// note - примечание
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// dt_record_edit - дата редактирования записи
        /// </summary>
        public DateTime dt_record_edit { get; set; }
        /// <summary>
        /// record_editor - ответственный за корректировку записи
        /// </summary>
        public string record_editor { get; set; }
        /// <summary>
        /// is_juridical_entity - признак того, что пользователь ВБР
        ///                     является юр.лицом (иначе - инд.предприниматель)
        /// </summary>
        public bool is_juridical_entity { get; set; }
        /// <summary>
        /// id_declarant_history_was - идентификатор записи до реорганизации
        ///                            и добавления новой записи в БД
        /// </summary>
        public int id_declarant_history_was { get; set; }
        /// <summary>
        /// forerunners - предшественники (при наличии реорганизаций)
        /// </summary>
        public List<data_declarant> forerunners { get; set; }

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

    }//class data_declarant

}//namespace cfmc.quotas.db_objects


