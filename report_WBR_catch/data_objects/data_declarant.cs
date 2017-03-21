//=============================================================================
// REPORT_WBR_CATCH
// data_declarant - данные записи таблицы [declarant] ПОЛЬЗОВАТЕЛЬ ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  21-03-2017
// Дата обновления:         21-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;

using cfmc.utils;

namespace cfmc.quotas.db_objects
{
    /// <summary>
    /// public class data_declarant
    /// - данные записи таблицы [declarant] ПОЛЬЗОВАТЕЛЬ ВБР
    /// </summary>
    public class data_declarant
    {
        /// <summary>
        /// field_declarant - сопоставление полей с полями запроса
        /// </summary>
        enum field_declarant : int
        {
            id_declarant_history = 0,       // int
            id_declarant = 1,               // int
            date_registration = 2,          // datetime
            declarant = 3,                  // varchar(250)
            work_number = 4,                // varchar(20)
            declarant_type = 5,             // varchar(20) Checked
            address = 6,                    // varchar(255)    Checked
            postal_address = 7,             // varchar(200)    Checked
            director = 8,                   // varchar(80) Checked
            phone = 9,                      // varchar(40) Checked
            fax = 10,                       // varchar(20) Checked
            telex = 11,                     // varchar(20) Checked
            e_mail  = 12,                   // varchar(50) Checked
            declarant_full = 13,            // varchar(150)    Checked
            inn = 14,                       // varchar(20) Checked
            kpp = 15,                       // varchar(9)  Checked
            reg_number = 16,                // varchar(50) Checked
            OKPO = 17,                      // varchar(50) Checked
            OKATO = 18,                     // varchar(5)  Checked
            OKVED = 19,                     // varchar(10) Checked
            KOPF = 20,                      // varchar(2)  Checked
            KFS = 21,                       // varchar(2)  Checked
            id_own = 22,                    // int Checked
            own = 23,                       // varchar(250)    Checked
            note = 24,                      // varchar(255)    Checked
            juridical = 25,                 // tinyint Checked
            id_declarant_history_was = 26,  // int Checked
            fields_count = 27
        }

        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_declarant( )
        {
            this.initialize( );
        }
        #endregion //__CONSTRUCTION__	

        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// id_declarant_history
        /// поле запроса - id_declarant_history
        /// Идентификатор записи в таблице declarant_history
        /// </summary>
        int id_declarant_history { get; set; }
        /// <summary>
        /// id_declarant
        /// поле запроса - id_declarant
        /// Идентификатор записи в таблице declarant
        /// </summary>
        int id_declarant { get; set; }
        /// <summary>
        /// date_registration
        /// поле запроса - date_registration
        /// Дата регистрации пользователя ВБР
        /// </summary>
        string date_registration { get; set; }
        /// <summary>
        /// declarant
        /// поле запроса - declarant
        /// Название пользователя ВБР
        /// </summary>
        string declarant { get; set; }
        /// <summary>
        /// work_number
        /// поле запроса - work_number
        /// Номер дела пользователя ВБР
        /// </summary>
        string work_number { get; set; }
        /// <summary>
        /// declarant_type
        /// поле запроса - declarant_type
        /// Текстовая аббревиатура формы собственности
        /// </summary>
        string declarant_type { get; set; }
        /// <summary>
        /// address
        /// поле запроса - address
        /// Юридический адрес
        /// </summary>
        string address { get; set; }
        /// <summary>
        /// postal_address
        /// поле запроса - postal_address
        /// Почтовый адрес
        /// </summary>
        string postal_address { get; set; }
        /// <summary>
        /// director
        /// поле запроса - director
        /// ФИО руководителя и должность
        /// </summary>
        string director { get; set; }
        /// <summary>
        /// phone
        /// поле запроса - phone
        /// Телефон, включая междугородний код
        /// </summary>
        string phone { get; set; }
        /// <summary>
        /// fax
        /// поле запроса - fax
        /// Факс, включая междугородний код
        /// </summary>
        string fax { get; set; }
        /// <summary>
        /// telex
        /// поле запроса - telex
        /// Телекс
        /// </summary>
        string telex { get; set; }
        /// <summary>
        /// e_mail
        /// поле запроса - e_mail
        /// E-mail
        /// </summary>
        string e_mail { get; set; }
        /// <summary>
        /// declarant_full
        /// поле запроса - declarant_full
        /// Полное название пользователя ВБР/владельца доли
        /// </summary>
        string declarant_full { get; set; }
        /// <summary>
        /// inn
        /// поле запроса - inn
        /// ИНН пользователя ВБР/владельца доли
        /// </summary>
        string inn { get; set; }
        /// <summary>
        /// kpp
        /// поле запроса - kpp
        /// КПП пользователя ВБР/владельца доли
        /// </summary>
        string kpp { get; set; }
        /// <summary>
        /// reg_number
        /// поле запроса - reg_number
        /// ОГРН пользователя ВБР/владельца доли
        /// </summary>
        string reg_number { get; set; }
        /// <summary>
        /// OKPO
        /// поле запроса - OKPO
        /// Код ОКПО пользователя ВБР/владельца доли
        /// </summary>
        string OKPO { get; set; }
        /// <summary>
        /// OKATO
        /// поле запроса - OKATO
        /// Код ОКАТО пользователя ВБР/владельца доли
        /// </summary>
        string OKATO { get; set; }
        /// <summary>
        /// OKVED
        /// поле запроса - OKVED
        /// Код ОКВЭД пользователя ВБР/владельца доли
        /// </summary>
        string OKVED { get; set; }
        /// <summary>
        /// KOPF
        /// поле запроса - KOPF
        /// Код ОКОПФ пользователя ВБР/владельца доли
        /// </summary>
        string KOPF { get; set; }
        /// <summary>
        /// KFS
        /// поле запроса - KFS
        /// Код ОКФС пользователя ВБР/владельца доли
        /// </summary>
        string KFS { get; set; }
        /// <summary>
        /// id_own
        /// поле запроса - id_own
        /// Код пользователя ВБР/владельца доли в ОСМ
        /// </summary>
        int id_own { get; set; }
        /// <summary>
        /// own
        /// поле запроса - own
        /// Наименование судовладельца в ОСМ
        /// </summary>
        string own { get; set; }
        /// <summary>
        /// note
        /// поле запроса - note
        /// Примечание
        /// </summary>
        string note { get; set; }
        /// <summary>
        /// juridical
        /// поле запроса - juridical
        /// Признак юрлицо/предприниматель
        /// </summary>
        byte juridical { get; set; }
        /// <summary>
        /// id_declarant_history_was
        /// поле запроса - id_declarant_history_was
        /// Предыдущий идентиикатор id_declarant_history в таблице declarant
        /// </summary>
        int id_declarant_history_was { get; set; }
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
            this.id_declarant_history = 0;
            this.id_declarant = 0;
            this.date_registration = "";
            this.declarant = "";
            this.work_number = "";
            this.declarant_type = "";
            this.address = "";
            this.postal_address = "";
            this.director = "";
            this.phone = "";
            this.fax = "";
            this.telex = "";
            this.e_mail = "";
            this.declarant_full = "";
            this.inn = "";
            this.kpp = "";
            this.reg_number = "";
            this.OKPO = "";
            this.OKATO = "";
            this.OKVED = "";
            this.KOPF = "";
            this.KFS = "";
            this.id_own = 0;
            this.own = "";
            this.note = "";
            this.juridical = 0;
            this.id_declarant_history_was = 0;
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
            //
            this.id_declarant_history = helper.cvt_field_int( 
                                                     data_row, 
                                                     (int)field_declarant.id_declarant_history 
                                                            );
            //
            this.id_declarant = helper.cvt_field_int( 
                                                     data_row, 
                                                     (int)field_declarant.id_declarant 
                                                    );
            //
            this.date_registration = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.date_registration 
                                                            );
            //
            this.declarant = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.declarant 
                                                    );
            //
            this.work_number = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.work_number 
                                                      );
            //
            this.declarant_type = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.declarant_type 
                                                         );
            //
            this.address = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.address 
                                                  );
            //
            this.postal_address = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.postal_address 
                                                         );
            //
            this.director = helper.cvt_field_string( 
                                                     data_row, 
                                                     (int)field_declarant.director 
                                                   );
            //
            this.phone = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.phone 
                                                );
            //
            this.fax = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.fax 
                                              );
            //
            this.telex = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.telex 
                                                );
            //
            this.e_mail = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.e_mail 
                                                 );
            //
            this.declarant_full = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.declarant_full 
                                                         );
            //
            this.inn = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.inn 
                                              );
            //
            this.kpp = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.kpp 
                                              );
            //
            this.reg_number = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.reg_number 
                                                     );
            //
            this.OKPO = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.OKPO 
                                               );
            //
            this.OKATO = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.OKATO 
                                                );
            //
            this.OKVED = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.OKVED 
                                                );
            //
            this.KOPF = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.KOPF 
                                               );
            //
            this.KFS = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.KFS 
                                              );
            //
            this.id_own = helper.cvt_field_int( 
                                                    data_row, 
                                                    (int)field_declarant.id_own 
                                              );
            //
            this.own = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.own 
                                              );
            //
            this.note = helper.cvt_field_string( 
                                                    data_row, 
                                                    (int)field_declarant.note 
                                               );
            //
            this.juridical = helper.cvt_field_byte( 
                                                    data_row, 
                                                    (int)field_declarant.juridical 
                                                  );
            //
            this.id_declarant_history_was = helper.cvt_field_int( 
                                                    data_row, 
                                                    (int)field_declarant.id_declarant_history_was 
                                                                );
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
            if( this.id_declarant == 0 )
            {
                return "";
            }
            return String.Format( "{0,6}. {1}", id_declarant, declarant );
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

    }//class data_declarant

}//namespace cfmc.quotas.db_objects

            