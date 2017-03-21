//=============================================================================
// REPORT_WBR_CATCH
// data_subject - данные записи таблицы [subject] СУБЪЕКТ РФ
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
    /// public class data_subject
    /// - данные записи таблицы [subject] СУБЪЕКТ РФ
    /// </summary>
    public class data_subject
    {
        /// <summary>
        /// field_subject - сопоставление полей с полями запроса
        /// </summary>
        enum field_subject : int
        {
            id_subject = 0,
            subject = 1,
            subject_order = 2,
            id_subject_osm = 3,
            sorting = 4,
            fields_count = 5
        }       
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_subject( )
        {
            this.initialize( );
        }
        public data_subject( object[] data_row )
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
        /// id_subject
        /// поле запроса - id_subject
        /// Идентификатор субъекта РФ
        /// </summary>
        public int id_subject { get; set; }
        /// <summary>
        /// subject
        /// поле запроса - subject
        /// субъект РФ
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// subject_order
        /// поле запроса - subject_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string subject_order { get; set; }
        /// <summary>
        /// id_subject_osm
        /// поле запроса - id_subject_osm
        /// Код в ОСМ
        /// </summary>
        public int id_subject_osm { get; set; }
        /// <summary>
        /// sorting
        /// поле запроса - sorting
        /// Порядок сортировки
        /// </summary>
        public int sorting { get; set; }
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
            this.id_subject = 0;
            this.subject = "";
            this.id_subject_osm = 0;
            this.subject_order = "";
            this.sorting = 0x7FFFFFFF;
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
            this.id_subject = helper.cvt_field_int( data_row, (int)field_subject.id_subject );
            this.subject = helper.cvt_field_string( data_row, (int)field_subject.subject );
            this.subject_order = helper.cvt_field_string( data_row, (int)field_subject.subject_order );
            this.id_subject_osm = helper.cvt_field_int( data_row, (int)field_subject.id_subject_osm );
            this.sorting = helper.cvt_field_int( data_row, (int)field_subject.sorting );
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
            if( this.id_subject == 0 )
            {
                return "";
            }
            return String.Format( "{0,3}. {1}", id_subject, subject );
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

    }//class data_subject

}//namespace cfmc.quotas.db_objects

            