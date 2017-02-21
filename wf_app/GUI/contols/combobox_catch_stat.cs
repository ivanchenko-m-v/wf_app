//=============================================================================
// combobox_catch_stat - список типов данных, по которым подсчитывается 
//                       статистика
// Автор: Иванченко М.В.
// Дата начала разработки:  21-02-2017
// Дата обновления:         21-02-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;

using wf_app.resources;

namespace wf_app.GUI.controls
{
    class combobox_catch_stat_data : object
    {
        public combobox_catch_stat_data( string t, string d )
        {
            text = t;
            data = d;
        }
        public string text { get; set; }
        public string data { get; set; }

        public override string ToString()
        {
            return text;
        }
    }
    public class combobox_catch_stat : ComboBox
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public combobox_catch_stat()
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
        public string current_item_data
        {
            get
            {
                combobox_catch_stat_data st_data = 
                    this.SelectedItem as combobox_catch_stat_data;

                string s_data = st_data != null ? st_data.data : "";

                return s_data;
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
            //s
            combobox_catch_stat_data item = 
                new combobox_catch_stat_data(
                                    resources.resource_combobox_stat._item_s,
                                    resources.resource_combobox_stat._item_s_data
                                            );
            this.Items.Add(item);
            //o
            item =
                new combobox_catch_stat_data(
                                    resources.resource_combobox_stat._item_o,
                                    resources.resource_combobox_stat._item_o_data
                                            );
            this.Items.Add(item);
            //so
            item =
                new combobox_catch_stat_data(
                                    resources.resource_combobox_stat._item_so,
                                    resources.resource_combobox_stat._item_so_data
                                            );
            this.Items.Add(item);
            //
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

    }//public class panel_select_criteria : Panel

}//namespace wf_app.GUI.panels
