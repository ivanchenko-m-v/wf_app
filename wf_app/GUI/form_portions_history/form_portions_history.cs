//=============================================================================
// form_portions_history - форма отчётов о вылове ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  09-03-2017
// Дата обновления:         14-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Drawing;
using System.Windows.Forms;

namespace cfmc.quotas.forms
{
    public class form_portions_history : Form
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public form_portions_history( )
        {
            this.MinimumSize = new Size(
                                        form_portions_history._MIN_WIDTH_,
                                        form_portions_history._MIN_HEIGHT_
                                       );
            this.Text = resources.resource_portions_history.form_title;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.create_form_elements( );

            this.init_form_elements( );

            this.subscribe_events( );
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
            //layout
            this._layout_table = new System.Windows.Forms.TableLayoutPanel( );
            //
            this._pn_criteria = new panel_portions_history_criteria( );
            this._pn_info = new panel_portion_history_info( );
            this._lv_result = new controls.listview_portions_history( );
            this._pb_process = new System.Windows.Forms.ProgressBar();
            this._pn_buttons = new panel_portions_history_buttons( );
        }

        /// <summary> 
        /// init_form_elements( )
        /// </summary>
        private void init_form_elements()
        {
            this._layout_table.SuspendLayout();
            this.SuspendLayout();
            //
            //_layout_table
            //
            this.init_layout();
            //
            //_row_criteria
            //
            this.init_layout_row_criteria( );
            //
            //_row_info
            //
            this.init_layout_row_info();
            //
            //_row_result
            //
            this.init_layout_row_result( );
            //
            //_row_progress
            //
            this.init_layout_row_progress();
            //
            //_row_buttons
            //
            this.init_layout_row_buttons( );
            //--
            this._layout_table.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// init_layout( )
        /// </summary>
        private void init_layout()
        {
            this._layout_table.Name = "_layout_table";
            this._layout_table.ColumnCount = form_portions_history._LAYOUT_COLS_;
            for (int i = 0; i < form_portions_history._LAYOUT_COLS_; ++i)
            {
                this._layout_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            }
            this._layout_table.RowCount = form_portions_history._LAYOUT_ROWS_;
            for (int i = 0; i < form_portions_history._LAYOUT_ROWS_; ++i)
            {
                System.Windows.Forms.RowStyle row_style = new System.Windows.Forms.RowStyle();
                row_style.SizeType = SizeType.Percent;
                row_style.Height = this._ROW_HEIGHT_[i];
                this._layout_table.RowStyles.Add(row_style);
            }
            this._layout_table.Dock = DockStyle.Fill;
            this._layout_table.TabIndex = 0;

            this.Controls.Add(this._layout_table);
        }

        /// <summary>
        /// init_layout_row_criteria( )
        /// </summary>
        private void init_layout_row_criteria( )
        {
            this._pn_criteria.AutoSize = true;
            this._pn_criteria.Anchor = AnchorStyles.Bottom;
            this._pn_criteria.Dock = DockStyle.Fill;
            this._layout_table.Controls.Add(
                                            this._pn_criteria,
                                            form_portions_history._COL_CONTROL_,
                                            form_portions_history._ROW_CRITERIA_
                                           );
        }
        /// <summary>
        /// init_layout_row_info( )
        /// </summary>
        private void init_layout_row_info( )
        {
            this._pn_info.AutoSize = true;
            this._pn_info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            this._pn_info.Dock = DockStyle.Fill;
            this._layout_table.Controls.Add(
                                            this._pn_info,
                                            form_portions_history._COL_CONTROL_,
                                            form_portions_history._ROW_INFO_
                                           );
        }
        /// <summary>
        /// init_layout_row_result( )
        /// </summary>
        private void init_layout_row_result()
        {
            this._lv_result.AutoSize = true;
            this._lv_result.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            this._lv_result.Dock = DockStyle.Fill;
            this._layout_table.Controls.Add(
                                            this._lv_result,
                                            form_portions_history._COL_CONTROL_,
                                            form_portions_history._ROW_RESULT_
                                           );
        }
        /// <summary>
        /// init_layout_row_progress( )
        /// </summary>
        private void init_layout_row_progress()
        {
            this._pb_process.Minimum = form_portions_history._MIN_PROGRESS_;
            this._pb_process.Maximum = form_portions_history._MAX_PROGRESS_;

            this._pb_process.AutoSize = true;
            this._pb_process.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            this._pb_process.Dock = DockStyle.Top;
            this._layout_table.Controls.Add(
                                            this._pb_process,
                                            form_portions_history._COL_CONTROL_,
                                            form_portions_history._ROW_PROCESS_
                                           );
        }
        /// <summary>
        /// init_layout_row_buttons( )
        /// </summary>
        private void init_layout_row_buttons()
        {
            this._pn_buttons.AutoSize = true;
            this._pn_buttons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this._pn_buttons.Dock = DockStyle.Fill;
            this._layout_table.Controls.Add(
                                            this._pn_buttons,
                                            form_portions_history._COL_CONTROL_,
                                            form_portions_history._ROW_BUTTONS_
                                           );
        }
        /// <summary>
        /// subscribe_events( )
        /// </summary>
        private void subscribe_events( )
        {
            business_logic.PortionsSelected += Business_logic_PortionsSelected;
            this._lv_result.RefreshPercentChanged += lv_result_RefreshPercentChanged;

            this._pn_buttons.SelectPortions += pn_buttons_SelectPortions;
            this._pn_buttons.Exit += pn_buttons_Exit;
        }
        #endregion //__INITIALIZE__

        /*
         * --------------------------------------------------------------------
         *                          FUNCTIONS
         * --------------------------------------------------------------------
         */
        #region __FUNCTIONS__
        /// <summary>
        /// select_portion_history( )
        /// </summary>
        private void select_portion_history( )
        {
            business_logic.select_portions_history(
                                                   this._pn_criteria.id_basin,
                                                   this._pn_criteria.id_regime,
                                                   this._pn_criteria.id_WBR,
                                                   this._pn_criteria.id_region
                                                  );
            this._pb_process.Value = 0;
        }
        #endregion//__FUNCTIONS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        /// <summary>
        /// Business_logic_PortionsSelected( object sender, EventArgs e )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Business_logic_PortionsSelected( object sender, EventArgs e )
        {
            //считаем, что выполнение запроса - полдела
            this._pb_process.Value = form_portions_history._MAX_PROGRESS_ / 2;
            //заполняем список
            this._lv_result.refresh_data( );
        }
        /// <summary>
        /// lv_result_RefreshPercentChanged( object sender, utils.PercentChangedEventArgs e )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_result_RefreshPercentChanged( object sender, utils.PercentChangedEventArgs e )
        {
            int progress = form_portions_history._MAX_PROGRESS_ / 2 + e.Percent;
            if( progress > form_portions_history._MAX_PROGRESS_ )
            {
                progress = form_portions_history._MAX_PROGRESS_;
            }
            this._pb_process.Value = progress;
        }
        /// <summary>
        /// pn_buttons_SelectPortions( object sender, EventArgs e )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pn_buttons_SelectPortions( object sender, EventArgs e )
        {
            this._pb_process.Value = form_portions_history._MIN_PROGRESS_;

            this.select_portion_history( );
        }

        private void pn_buttons_Exit( object sender, EventArgs e )
        {
            this.Close( );
        }
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        private const int _MIN_WIDTH_ = 936;
        private const int _MIN_HEIGHT_ = 702;

        private const int _MIN_PROGRESS_ = 0;
        private const int _MAX_PROGRESS_ = 200;

        private const int _LAYOUT_COLS_ = 1;
        private const int _LAYOUT_ROWS_ = 5;

        private const int _ROW_CRITERIA_ = 0;
        private const int _ROW_INFO_ = 1;
        private const int _ROW_RESULT_ = 2;
        private const int _ROW_PROCESS_ = 3;
        private const int _ROW_BUTTONS_ = 4;

        private const int _COL_CONTROL_ = 0;

        //высота строк в процентах
        private int[] _ROW_HEIGHT_ = { 10, 16, 65, 2, 7 };

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private System.Windows.Forms.TableLayoutPanel _layout_table;
        private cfmc.quotas.forms.panel_portions_history_criteria _pn_criteria;
        private cfmc.quotas.forms.panel_portion_history_info _pn_info;
        private cfmc.quotas.controls.listview_portions_history _lv_result;
        private System.Windows.Forms.ProgressBar _pb_process;
        private cfmc.quotas.forms.panel_portions_history_buttons _pn_buttons;
        //
        #endregion//__FIELDS__

    }//public class form_portions_history : Form

}//namespace cfmc.quotas.forms
