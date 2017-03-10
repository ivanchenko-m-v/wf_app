//=============================================================================
// panel_portions_history_buttons - панель управляющих кнопок действий пользователя
//                                  в форме form_portions_history
// Автор: Иванченко М.В.
// Дата начала разработки:  09-03-2017
// Дата обновления:         10-03-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;

using cfmc.quotas.resources;

namespace cfmc.quotas.forms
{
    public class panel_portions_history_buttons : Panel
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public panel_portions_history_buttons()
        {
            this.create_form_elements();

            this.init_form_elements();
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
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        /// <summary>
        /// create_form_elements( )
        /// </summary>
        private void create_form_elements()
        {
            this._layout = new System.Windows.Forms.TableLayoutPanel();
            //buttons
            this._btn_select = new System.Windows.Forms.Button();
            this._btn_export = new System.Windows.Forms.Button();
            this._btn_exit = new System.Windows.Forms.Button();
        }

        /// <summary> 
        /// init_form_elements( )
        /// </summary>
        private void init_form_elements( )
        {
            this._layout.SuspendLayout();
            this.SuspendLayout();
            //
            //_layout
            //
            this.init_layout( );
            //
            //_btn_select
            //
            this.init_button_select( );
            //
            //_btn_export
            //
            this.init_button_export( );
            //
            //_btn_exit
            //
            this.init_button_exit( );
            //--
            this._layout.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        /// <summary>
        /// init_layout( )
        /// </summary>
        private void init_layout( )
        {
            this._layout.Name = "_layout";
            this._layout.Dock = DockStyle.Fill;
            this._layout.TabIndex = 0;

            this._layout.ColumnCount = panel_portions_history_buttons._COLS_;
            int col_percent = 100 / panel_portions_history_buttons._COLS_;
            for (int i = 0; i < panel_portions_history_buttons._COLS_; ++i)
            {
                System.Windows.Forms.ColumnStyle col_style = new ColumnStyle();
                col_style.SizeType = SizeType.Percent;
                col_style.Width = col_percent;
                this._layout.ColumnStyles.Add(col_style);
            }
            this._layout.RowCount = panel_portions_history_buttons._ROWS_;
            for (int i = 0; i < panel_portions_history_buttons._ROWS_; ++i)
            {
                this._layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            }

            this.Controls.Add( this._layout );
        }
        /// <summary>
        /// init_button_select( )
        /// </summary>
        private void init_button_select( )
        {
            this._btn_select.Text = resource_portions_history.btn_select;
            this._btn_select.Anchor = AnchorStyles.Right | AnchorStyles.Left |
                                        AnchorStyles.Top | AnchorStyles.Bottom;

            this._btn_select.Click += _btn_select_Click;

            this._layout.Controls.Add( 
                                        this._btn_select,
                                        panel_portions_history_buttons._COL_START_ +
                                        panel_portions_history_buttons._TABINDEX_SELECT_,
                                        panel_portions_history_buttons._ROW_START_
                                     );
            this._btn_select.TabIndex = panel_portions_history_buttons._TABINDEX_SELECT_;
        }
        /// <summary>
        /// init_button_export( )
        /// </summary>
        private void init_button_export( )
        {
            this._btn_export.Text = resource_portions_history.btn_export;
            this._btn_export.Anchor = AnchorStyles.Right | AnchorStyles.Left | 
                                        AnchorStyles.Top | AnchorStyles.Bottom;

            this._btn_export.Click += _btn_export_Click;

            this._layout.Controls.Add(
                                        this._btn_export,
                                        panel_portions_history_buttons._COL_START_ +
                                        panel_portions_history_buttons._TABINDEX_EXPORT_,
                                        panel_portions_history_buttons._ROW_START_
                                     );
            this._btn_export.TabIndex = panel_portions_history_buttons._TABINDEX_EXPORT_;
        }
        /// <summary>
        /// init_button_exit( )
        /// </summary>
        private void init_button_exit( )
        {
            this._btn_exit.Text = resource_portions_history.btn_exit;
            this._btn_exit.AutoSize = true;
            this._btn_exit.Anchor = AnchorStyles.Right | AnchorStyles.Left |
                                        AnchorStyles.Top | AnchorStyles.Bottom;

            this._btn_exit.Click += _btn_exit_Click;

            this._layout.Controls.Add(
                                        this._btn_exit,
                                        panel_portions_history_buttons._COL_START_ +
                                        panel_portions_history_buttons._TABINDEX_EXIT_,
                                        panel_portions_history_buttons._ROW_START_
                                     );
            this._btn_exit.TabIndex = panel_portions_history_buttons._TABINDEX_EXIT_;
        }

        #endregion //__INITIALIZE__

        /*
         * --------------------------------------------------------------------
         *                          FUNCTIONS
         * --------------------------------------------------------------------
         */
        #region __FUNCTIONS__
        /// <summary>
        /// _btn_select_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_select_Click(object sender, EventArgs e)
        {
            if (this.select_data == null)
            {
                return;
            }
            this.select_data(sender, e);
        }
        /// <summary>
        /// _btn_order_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_order_Click(object sender, EventArgs e)
        {
            if (this.change_report_columns == null)
            {
                return;
            }
            this.change_report_columns(sender, e);
        }
        /// <summary>
        /// _btn_export_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_export_Click(object sender, EventArgs e)
        {
            if (this.export_report_data == null)
            {
                return;
            }
            this.export_report_data(sender, e);
        }
        /// <summary>
        /// _btn_exit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_exit_Click(object sender, EventArgs e)
        {
            if( this.exit == null )
            {
                return;
            }
            this.exit( sender, e );
        }

        #endregion//__FUNCTIONS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        public event System.EventHandler select_data = null;
        public event System.EventHandler change_report_columns = null;
        public event System.EventHandler export_report_data = null;
        public event System.EventHandler exit = null;
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

        private const int _TABINDEX_SELECT_ = 0;
        private const int _TABINDEX_EXPORT_ = 1;
        private const int _TABINDEX_EXIT_ = 2;

        //параметры сетки расположения элементов управления
        private const int _COLS_ = 12;
        private const int _ROWS_ = 1;
        //стартовая позиция первой кнопки
        private const int _COL_START_ = 9;
        private const int _ROW_START_ = 0;

        //
        private System.Windows.Forms.TableLayoutPanel _layout;
        private System.Windows.Forms.Button _btn_select;
        private System.Windows.Forms.Button _btn_export;
        private System.Windows.Forms.Button _btn_exit;
        //
        #endregion//__FIELDS__

    }//public class panel_portions_history_buttons : Panel

}//namespace cfmc.quotas.forms
