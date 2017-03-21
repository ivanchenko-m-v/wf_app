//=============================================================================
// REPORT_WBR_CATCH
// combobox_year - список годов, для которых ведётся подсчёт статистики
// Автор: Иванченко М.В.
// Дата начала разработки:  21-02-2017
// Дата обновления:         21-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;

namespace cfmc.quotas.controls
{
    public class combobox_year : ComboBox
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public combobox_year()
        {
            this.create_control_elements();

            this.init_control();
        }
        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion //__CONSTRUCTION__

        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        public int current_year
        {
            get
            {
                int cur_year = 0;
                try
                {
                    cur_year = System.Convert.ToInt32(this.SelectedItem);
                }
                catch
                {
                    cur_year = 0;
                }

                return cur_year;
            }
        }
        #endregion

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        /// <summary>
        /// create_control_elements( )
        /// </summary>
        private void create_control_elements()
        {
        }

        /// <summary> 
        /// init_control( )
        /// </summary>
        private void init_control( )
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SuspendLayout();
            //
            //_layout
            //
            this.init_data( );
            //--
            this.ResumeLayout(false);
        }
        /// <summary>
        /// init_columns( )
        /// </summary>
        private void init_data( )
        {
            const int _YEAR_PERIOD_ = 16;
            int cur_year = DateTime.Today.Year;
            for( int i = 0; i < _YEAR_PERIOD_; ++i )
            {
                this.Items.Add(cur_year - i);
            }
            this.SelectedIndex = 0;
        }

        #endregion //__INITIALIZE__

        /*
         * --------------------------------------------------------------------
         *                          FUNCTIONS
         * --------------------------------------------------------------------
         */
        #region __FUNCTIONS__
        #endregion//__FUNCTIONS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        #endregion //__EVENTS__
        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        #endregion//__FIELDS__

    }//public class combobox_year : ComboBox

}//namespace cfmc.quotas.controls
