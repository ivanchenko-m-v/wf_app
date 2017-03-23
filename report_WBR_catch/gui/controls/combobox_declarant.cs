//=============================================================================
// REPORT_WBR_CATCH
// combobox_declarant - список выбора пользователя ВБР
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
    using System;
    using list_declarant = List<data_declarant>;
    /// <summary>
    /// public class combobox_declarant : ComboBox
    /// - список выбора пользователя ВБР
    /// </summary>
    public class combobox_declarant : ComboBox
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public combobox_declarant( )
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
        /// id_declarant
        /// </summary>
        public int id_declarant
        {
            get
            {
                if( this.SelectedItem == null )
                {
                    return 0;
                }
                data_declarant d = this.SelectedItem as data_declarant;

                return d.id_declarant;
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
            this.KeyDown += combobox_declarant_KeyDown;
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
            list_declarant data = this.DataSource as list_declarant;
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
        /// <summary>
        /// bind_data_source( )
        /// - присоединяет источник данных
        /// </summary>
        private void bind_data_source( )
        {
            data_model_store.select_declarant( this.Text );
            if( data_model_store.declarants != null )
            {
                this.DataSource = data_model_store.declarants;
            }
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        /// <summary>
        /// combobox_declarant_KeyDown( object sender, KeyEventArgs e )
        /// </summary>
        /// <param name="sender">инициатор события</param>
        /// <param name="e">параметры</param>
        private void combobox_declarant_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyData != Keys.Enter && e.KeyData != Keys.Return )
            {
                return;
            }
            this.DataSource = null;

            //присоединить источник данных
            this.bind_data_source( );

            if( !( this.DataSource is list_declarant ) )
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

    }//class combobox_declarant

}//namespace cfmc.quotas.controls

            