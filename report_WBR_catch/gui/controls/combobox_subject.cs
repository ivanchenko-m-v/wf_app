//=============================================================================
// REPORT_WBR_CATCH
// combobox_subject - список выбора субъекта РФ
// Автор: Иванченко М.В.
// Дата начала разработки:  22-03-2017
// Дата обновления:         22-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System.Windows.Forms;
using System.Collections.Generic;

using cfmc.quotas.db_objects;

namespace cfmc.quotas.controls
{
    using list_subject = List<data_subject>;
    /// <summary>
    /// public class combobox_subject : ComboBox
    /// - список выбора субъекта РФ
    /// </summary>
    public class combobox_subject : ComboBox
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public combobox_subject( )
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
        /// id_subject
        /// </summary>
        public int id_subject
        {
            get
            {
                if( this.SelectedItem == null )
                {
                    return 0;
                }
                data_subject subject = this.SelectedItem as data_subject;

                return subject.id_subject;
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
            this.DataSource = data_model_store.subjects;
            this.AutoCompleteMode = AutoCompleteMode.Append;

            this.KeyDown += combobox_subject_KeyDown;
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// find_item( )
        /// - поиск элемента списка по тексту
        /// </summary>
        /// <returns>индекс найденного элемента списка</returns>
        private int find_item( )
        {
            list_subject data = this.DataSource as list_subject;
            int index = -1;
            for( int i = 0; i < data.Count; ++i )
            {
                if( data[i].ToString( ).ToUpper( ).Contains( this.Text.ToUpper( ) ) )
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        /// <summary>
        /// combobox_subject_KeyDown( object sender, KeyEventArgs e )
        /// </summary>
        /// <param name="sender">инициатор события</param>
        /// <param name="e">параметры</param>
        private void combobox_subject_KeyDown( object sender, KeyEventArgs e )
        {
            if( !( this.DataSource is list_subject ) )
            {
                return;
            }
            if( e.KeyData == Keys.Enter || e.KeyData == Keys.Return )
            {
                int index = this.find_item( );
                if( index > -1 )
                {
                    this.SelectedIndex = index;
                }
            }
        }
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        #endregion//__FIELDS__

    }//class combobox_subject

}//namespace cfmc.quotas.controls

            