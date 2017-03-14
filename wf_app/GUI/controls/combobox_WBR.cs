
//=============================================================================
// combobox_WBR - список выбора ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         14-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System.Collections.Generic;
using System.Windows.Forms;

using cfmc.quotas.db_objects;

namespace cfmc.quotas.controls
{
    using list_WBR = List<data_WBR>;

    public class combobox_WBR : ComboBox
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public combobox_WBR( )
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
        /// id_WBR
        /// </summary>
        public int id_WBR
        {
            get
            {
                if( this.SelectedItem == null )
                {
                    return 0;
                }
                data_WBR wbr = this.SelectedItem as data_WBR;

                return wbr.id_fish;
            }
        }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize()
        {
            this.DataSource = data_model_store.WBRs;
            this.AutoCompleteMode = AutoCompleteMode.Append;

            this.KeyDown += Combobox_WBR_KeyDown;
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        private int find_item( )
        {
            list_WBR data = this.DataSource as list_WBR;
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
        private void Combobox_WBR_KeyDown( object sender, KeyEventArgs e )
        {
            if( !( this.DataSource is list_WBR ) )
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

    }//class combobox_WBR

}//namespace cfmc.quotas.controls

