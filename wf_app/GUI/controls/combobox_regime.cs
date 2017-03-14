
//=============================================================================
// combobox_regime - список выбора вида(режима) промысла
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
    using list_regime = List<data_regime>;

    public class combobox_regime : ComboBox
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public combobox_regime()
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
        /// id_regime
        /// </summary>
        public int id_regime
        {
            get
            {
                if( this.SelectedItem == null )
                {
                    return 0;
                }
                data_regime regime = this.SelectedItem as data_regime;

                return regime.id_regime;
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
            this.DataSource = data_model_store.regimes;
            this.AutoCompleteMode = AutoCompleteMode.Append;

            this.KeyDown += Combobox_regime_KeyDown;
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
            list_regime data = this.DataSource as list_regime;
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
        private void Combobox_regime_KeyDown( object sender, KeyEventArgs e )
        {
            if( !( this.DataSource is list_regime ) )
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

    }//class combobox_regime

}//namespace cfmc.quotas.controls

