//=============================================================================
// REPORT_WBR_CATCH
// data_report_WBR_catch - данные отчёта о вылове за 2 года подряд,
//                         где процент освоения менее заданного 
// Автор: Иванченко М.В.
// Дата начала разработки:  23-03-2017
// Дата обновления:         23-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================

using cfmc.utils;

namespace cfmc.quotas.db_objects
{
    /// <summary>
    /// data_report_WBR_catch 
    /// - данные отчёта о вылове за 2 года подряд,
    ///   где процент освоения менее заданного 
    /// </summary>
    public class data_report_WBR_catch : IDataRow
    {
        enum field_report_WBR_catch : int
        {
	        id_basin = 0,
            basin = 1,
            id_subject = 2,
            subject = 3,
            id_declarant = 4,
            declarant = 5,
            inn = 6,
            id_regime = 7,
            regime = 8,
            id_region = 9,
            region = 10,
            id_WBR = 11,
            WBR = 12,
            id_unit = 13,
            unit = 14,
            portion = 15,
            limits_1 = 16,
            catch_stat_1 = 17,
            percent_1 = 18,
            limits_2 = 19,
            catch_stat_2 = 20,
            percent_2 = 21,
            fields_count = 22
        }
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_report_WBR_catch( object[] data_row )
        {
            this.initialize( data_row );
        }

        public data_report_WBR_catch( )
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
        /// id_basin
        /// поле запроса - id_basin
        /// Идентификатор промыслового бассейна
        /// </summary>
        public int id_basin { get; set; }
        /// <summary>
        /// basin
        /// поле запроса - basin
        /// Промысловый бассейн
        /// </summary>
        public string basin { get; set; }
        /// <summary>
        /// id_subject
        /// поле запроса - id_subject
        /// Идентификатор субъекта РФ
        /// </summary>
        public int id_subject { get; set; }
        /// <summary>
        /// subject
        /// поле запроса - subject
        /// Субъект РФ
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// id_declarant
        /// поле запроса - id_declarant
        /// Идентификатор пользователя ВБР
        /// </summary>
        public int id_declarant { get; set; }
        /// <summary>
        /// declarant
        /// поле запроса - declarant
        /// Пользователь ВБР
        /// </summary>
        public string declarant { get; set; }
        /// <summary>
        /// inn
        /// поле запроса - inn
        /// ИНН пользователя ВБР
        /// </summary>
        public string inn { get; set; }
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
        /// id_region
        /// поле запроса - id_region
        /// Идентификатор района промысла
        /// </summary>
        public int id_region { get; set; }
        /// <summary>
        /// region
        /// поле запроса - region
        /// Район промысла
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// id_WBR
        /// поле запроса - id_WBR
        /// Идентификатор ВБР
        /// </summary>
        public int id_WBR { get; set; }
        /// <summary>
        /// WBR
        /// поле запроса - WBR
        /// ВБР
        /// </summary>
        public string WBR { get; set; }
        /// <summary>
        /// id_unit
        /// поле запроса - id_unit
        /// Идентификатор единицы измерения
        /// </summary>
        public int id_unit { get; set; }
        /// <summary>
        /// unit
        /// поле запроса - unit
        /// Единица измерения
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// portion
        /// поле запроса - portion
        /// Доля пользователя ВБР
        /// </summary>
        public decimal portion { get; set; }
        /// <summary>
        /// limits_1
        /// поле запроса - limits_1
        /// Квота пользователя ВБР за 1й год
        /// </summary>
        public decimal limits_1 { get; set; }
        /// <summary>
        /// catch_stat_1
        /// поле запроса - catch_stat_1
        /// Вылов пользователя ВБР за 1й год
        /// </summary>
        public decimal catch_stat_1 { get; set; }
        /// <summary>
        /// percent_1
        /// поле запроса - percent_1
        /// Процент освоения квоты пользователя ВБР за 1й год
        /// </summary>
        public decimal percent_1 { get; set; }
        /// <summary>
        /// limits_2
        /// поле запроса - limits_2
        /// Квота пользователя ВБР за 2й год
        /// </summary>
        public decimal limits_2 { get; set; }
        /// <summary>
        /// catch_stat_2
        /// поле запроса - catch_stat_2
        /// Вылов пользователя ВБР за 2й год
        /// </summary>
        public decimal catch_stat_2 { get; set; }
        /// <summary>
        /// percent_2
        /// поле запроса - percent_2
        /// Процент освоения квоты пользователя ВБР за 2й год
        /// </summary>
        public decimal percent_2 { get; set; }
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
            this.id_basin = 0;
            this.basin = "";
            this.id_subject = 0;
            this.subject = "";
            this.id_declarant = 0;
            this.declarant = "";
            this.inn = "";
            this.id_regime = 0;
            this.regime = "";
            this.id_region = 0;
            this.region = "";
            this.id_WBR = 0;
            this.WBR = "";
            this.id_unit = 0;
            this.unit = "";
            this.portion = 0;
            this.limits_1 = 0;
            this.catch_stat_1 = 0;
            this.percent_1 = 0;
            this.limits_2 = 0;
            this.catch_stat_2 = 0;
            this.percent_2 = 0;
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
            //
            this.id_basin = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_basin
                                                );
            //
            this.basin = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.basin
                                                );
            //
            this.id_subject = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_subject
                                                  );
            //
            this.subject = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.subject
                                                  );
            //
            this.id_declarant = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_declarant
                                                    );
            //
            this.declarant = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.declarant
                                                    );
            //
            this.inn = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.inn
                                              );
            //
            this.id_regime = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_regime
                                                 );
            //
            this.regime = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.regime
                                                 );
            //
            this.id_region = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_region
                                                 );
            //
            this.region = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.region
                                                 );
            //
            this.id_WBR = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_WBR
                                              );
            //
            this.WBR = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.WBR
                                              );
            //
            this.id_unit = helper.cvt_field_int(
                                                     data_row,
                                                     (int)field_report_WBR_catch.id_unit
                                               );
            //
            this.unit = helper.cvt_field_string(
                                                     data_row,
                                                     (int)field_report_WBR_catch.unit
                                               );
            //
            this.portion = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.portion
                                                   );
            //
            this.limits_1 = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.limits_1
                                                   );
            //
            this.catch_stat_1 = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.catch_stat_1
                                                   );
            //
            this.percent_1 = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.percent_1
                                                   );
            //
            this.limits_2 = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.limits_2
                                                   );
            //
            this.catch_stat_2 = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.catch_stat_2
                                                   );
            //
            this.percent_2 = helper.cvt_field_decimal(
                                                     data_row,
                                                     (int)field_report_WBR_catch.percent_2
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
        /// Fields( )
        /// - реализация интерфейса IDataRow
        /// </summary>
        /// <returns>массив полей записи</returns>
        public object[] Fields( )
        {
            object[] fields = new object[]
                              {
                                this.basin,
                                this.subject,
                                this.declarant,
                                this.inn,
                                this.regime,
                                this.region,
                                this.WBR,
                                this.unit,
                                this.portion,
                                this.limits_1,
                                this.catch_stat_1,
                                this.percent_1,
                                this.limits_2,
                                this.catch_stat_2,
                                this.percent_2
                              };
            return fields;
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

    }//class data_report_WBR_catch

    /// <summary>
    /// public class params_report_WBR_catch
    /// - параметры вызова процедуры выборки данных
    /// </summary>
    public class params_report_WBR_catch
    {
        public int year_1st { get; set; } = 0;
        public int year_2nd { get; set; } = 0;
        public int percent { get; set; } = 0;
        public string stat_type { get; set; } = "";
        public int id_subject { get; set; } = 0;
        public int id_regime { get; set; } = 0;
        public int id_region { get; set; } = 0;
        public int id_WBR { get; set; } = 0;
        public int id_declarant { get; set; } = 0;
    }//public class params_report_WBR_catch

}//namespace cfmc.quotas.db_objects

            