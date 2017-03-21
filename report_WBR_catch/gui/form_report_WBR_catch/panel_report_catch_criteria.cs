//=============================================================================
// REPORT_WBR_CATCH
// panel_report_catch_criteria - панель выбора условий отбора в отчёте о
//                         пользователях ВБР, которые не выбрали квоту.
// Автор: Иванченко М.В.
// Дата начала разработки:  17-02-2017
// Дата обновления:         21-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;
using System.Drawing;
using System.Windows.Forms;

using cfmc.quotas.resources;
using cfmc.quotas.controls;

namespace cfmc.quotas.forms
{
    public class panel_report_catch_criteria : Panel
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public panel_report_catch_criteria()
        {
            this.calc_min_size();

            this.create_form_elements();

            this.init_form_elements();

            this.SizeChanged += panel_select_criteria_SizeChanged;
            this.FontChanged += panel_select_criteria_FontChanged;
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
        private Size min_label_size { get; set; }
        private Size min_button_size { get; set; }
        #endregion //__PROPERTIES__
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
            this._layout_table = new System.Windows.Forms.TableLayoutPanel();
            //first line controls
            this._cbx_year = new combobox_year();
            this._num_percent = new NumericUpDown();
            this._cbx_stat = new combobox_catch_stat();
            //textboxes
            this._x_subject = new System.Windows.Forms.TextBox();
            this._x_regime = new System.Windows.Forms.TextBox();
            this._x_region = new System.Windows.Forms.TextBox();
            this._x_fish = new System.Windows.Forms.TextBox();
            this._x_declarant = new System.Windows.Forms.TextBox();
            //buttons
            this._btn_subject = new System.Windows.Forms.Button();
            this._btn_subject_clear = new System.Windows.Forms.Button();
            this._btn_regime = new System.Windows.Forms.Button();
            this._btn_regime_clear = new System.Windows.Forms.Button();
            this._btn_region = new System.Windows.Forms.Button();
            this._btn_region_clear = new System.Windows.Forms.Button();
            this._btn_fish = new System.Windows.Forms.Button();
            this._btn_fish_clear = new System.Windows.Forms.Button();
            this._btn_declarant = new System.Windows.Forms.Button();
            this._btn_declarant_clear = new System.Windows.Forms.Button();
            //tooltip
            this._tooltip = new System.Windows.Forms.ToolTip();
        }

        /// <summary> 
        /// init_form_elements( )
        /// </summary>
        private void init_form_elements( )
        {
            this._layout_table.SuspendLayout();
            this.SuspendLayout();
            //
            //_layout_table
            //
            this.init_layout( );
            //
            //first row, common report criteria
            //
            this.init_layout_row_year();
            //
            //_x_subject
            //
            this.init_layout_row_subject( );
            //
            //_x_regime
            //
            this.init_layout_row_regime( );
            //
            //_x_region
            //
            this.init_layout_row_region( );
            //
            //_x_fish
            //
            this.init_layout_row_fish( );
            //
            //_x_declarant
            //
            this.init_layout_row_declarant( );
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
            this._layout_table.ColumnCount = panel_report_catch_criteria._LAYOUT_COLS_;
            for( int i = 0; i < panel_report_catch_criteria._LAYOUT_COLS_; ++i )
            {
                System.Windows.Forms.ColumnStyle col_style = new ColumnStyle();
                col_style.SizeType = SizeType.Percent;
                col_style.Width = _COL_WIDTH_[i];
                this._layout_table.ColumnStyles.Add(col_style);
            }
            this._layout_table.RowCount = panel_report_catch_criteria._LAYOUT_ROWS_;
            for (int i = 0; i < panel_report_catch_criteria._LAYOUT_ROWS_; ++i)
            {
                this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            }
            this._layout_table.Dock = DockStyle.Fill;
            this._layout_table.TabIndex = 0;

//            this.calc_layout_columns_width();

            this.Controls.Add(this._layout_table);
        }
        /// <summary>
        /// init_layout_row_year( )
        /// </summary>
        private void init_layout_row_year()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._cbx_year;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_LABEL_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            this._cbx_year.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_year,
                                            panel_report_catch_criteria._COL_TEXT_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._num_percent;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_PERCENT_LABEL_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            this._num_percent.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._num_percent.Value = panel_report_catch_criteria._PERCENT_DEFAULT_;
            this._layout_table.Controls.Add(
                                            this._num_percent,
                                            panel_report_catch_criteria._COL_PERCENT_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._cbx_stat;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_CATCH_LABEL_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            this._cbx_stat.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_stat,
                                            panel_report_catch_criteria._COL_CATCH_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            //for stretching to right border of the form
            lbl = new Label();
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_SPACE_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            this._layout_table.SetColumnSpan(lbl, panel_report_catch_criteria._SPAN_COLUMNS_SPACE_YEAR_);
        }
        /// <summary>
        /// init_layout_row_subject( )
        /// </summary>
        private void init_layout_row_subject( )
        {
            System.Windows.Forms.Label lbl = new Label( );
            lbl.Text = resource_panel_report_catch_criteria._x_subject;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl, 
                                            panel_report_catch_criteria._COL_LABEL_,
                                            panel_report_catch_criteria._ROW_SUBJECT_
                                           );
            this._x_subject.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._x_subject,
                                            panel_report_catch_criteria._COL_TEXT_,
                                            panel_report_catch_criteria._ROW_SUBJECT_
                                           );
            this._layout_table.SetColumnSpan(this._x_subject, _SPAN_COLUMNS_CRITERIA_);

            this._btn_subject.Text = resource_panel_report_catch_criteria._btn_select_text;
            this._tooltip.SetToolTip(this._btn_subject, resource_panel_report_catch_criteria._btn_subject_tip);
            this._btn_subject.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_subject,
                                            panel_report_catch_criteria._COL_SELECT_,
                                            panel_report_catch_criteria._ROW_SUBJECT_
                                           );
            this._btn_subject_clear.Text = resource_panel_report_catch_criteria._btn_clear_text;
            this._tooltip.SetToolTip(this._btn_subject_clear, resource_panel_report_catch_criteria._btn_clear_tip);
            this._btn_subject_clear.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_subject_clear,
                                            panel_report_catch_criteria._COL_CLEAR_,
                                            panel_report_catch_criteria._ROW_SUBJECT_
                                           );
        }
        /// <summary>
        /// init_layout_row_regime( )
        /// </summary>
        private void init_layout_row_regime( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._x_regime;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_LABEL_,
                                            panel_report_catch_criteria._ROW_REGIME_
                                           );
            this._x_regime.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._x_regime,
                                            panel_report_catch_criteria._COL_TEXT_,
                                            panel_report_catch_criteria._ROW_REGIME_
                                           );
            this._layout_table.SetColumnSpan(this._x_regime, _SPAN_COLUMNS_CRITERIA_);

            this._btn_regime.Text = resource_panel_report_catch_criteria._btn_select_text;
            this._tooltip.SetToolTip(this._btn_regime, resource_panel_report_catch_criteria._btn_regime_tip);
            this._btn_regime.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_regime,
                                            panel_report_catch_criteria._COL_SELECT_,
                                            panel_report_catch_criteria._ROW_REGIME_
                                           );
            this._btn_regime_clear.Text = resource_panel_report_catch_criteria._btn_clear_text;
            this._tooltip.SetToolTip(this._btn_regime_clear, resource_panel_report_catch_criteria._btn_clear_tip);
            this._btn_regime_clear.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_regime_clear,
                                            panel_report_catch_criteria._COL_CLEAR_,
                                            panel_report_catch_criteria._ROW_REGIME_
                                           );
        }
        /// <summary>
        /// init_layout_row_region( )
        /// </summary>
        private void init_layout_row_region( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._x_region;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_LABEL_,
                                            panel_report_catch_criteria._ROW_REGION_
                                           );
            this._x_region.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._x_region,
                                            panel_report_catch_criteria._COL_TEXT_,
                                            panel_report_catch_criteria._ROW_REGION_
                                           );
            this._layout_table.SetColumnSpan(this._x_region, _SPAN_COLUMNS_CRITERIA_);

            this._btn_region.Text = resource_panel_report_catch_criteria._btn_select_text;
            this._tooltip.SetToolTip(this._btn_region, resource_panel_report_catch_criteria._btn_region_tip);
            this._btn_region.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_region,
                                            panel_report_catch_criteria._COL_SELECT_,
                                            panel_report_catch_criteria._ROW_REGION_
                                           );
            this._btn_region_clear.Text = resource_panel_report_catch_criteria._btn_clear_text;
            this._tooltip.SetToolTip(this._btn_region_clear, resource_panel_report_catch_criteria._btn_clear_tip);
            this._btn_region_clear.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_region_clear,
                                            panel_report_catch_criteria._COL_CLEAR_,
                                            panel_report_catch_criteria._ROW_REGION_
                                           );
        }
        /// <summary>
        /// init_layout_row_fish( )
        /// </summary>
        private void init_layout_row_fish( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._x_fish;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_LABEL_,
                                            panel_report_catch_criteria._ROW_FISH_
                                           );
            this._x_fish.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._x_fish,
                                            panel_report_catch_criteria._COL_TEXT_,
                                            panel_report_catch_criteria._ROW_FISH_
                                           );
            this._layout_table.SetColumnSpan(this._x_fish, _SPAN_COLUMNS_CRITERIA_);

            this._btn_fish.Text = resource_panel_report_catch_criteria._btn_select_text;
            this._tooltip.SetToolTip(this._btn_fish, resource_panel_report_catch_criteria._btn_fish_tip);
            this._btn_fish.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_fish,
                                            panel_report_catch_criteria._COL_SELECT_,
                                            panel_report_catch_criteria._ROW_FISH_
                                           );
            this._btn_fish_clear.Text = resource_panel_report_catch_criteria._btn_clear_text;
            this._tooltip.SetToolTip(this._btn_fish_clear, resource_panel_report_catch_criteria._btn_clear_tip);
            this._btn_fish_clear.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._btn_fish_clear,
                                            panel_report_catch_criteria._COL_CLEAR_,
                                            panel_report_catch_criteria._ROW_FISH_
                                           );
        }
        /// <summary>
        /// init_layout_row_declarant( )
        /// </summary>
        private void init_layout_row_declarant( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_panel_report_catch_criteria._x_declarant;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_LABEL_,
                                            panel_report_catch_criteria._ROW_DECLARANT_
                                           );
            this._x_declarant.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this._layout_table.Controls.Add(
                                            this._x_declarant,
                                            panel_report_catch_criteria._COL_TEXT_,
                                            panel_report_catch_criteria._ROW_DECLARANT_
                                           );
            this._layout_table.SetColumnSpan(this._x_declarant, _SPAN_COLUMNS_CRITERIA_);

            this._btn_declarant.Text = resource_panel_report_catch_criteria._btn_select_text;
            this._tooltip.SetToolTip(this._btn_declarant, resource_panel_report_catch_criteria._btn_declarant_tip);
            this._btn_declarant.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this._layout_table.Controls.Add(
                                            this._btn_declarant,
                                            panel_report_catch_criteria._COL_SELECT_,
                                            panel_report_catch_criteria._ROW_DECLARANT_
                                           );
            this._btn_declarant_clear.Text = resource_panel_report_catch_criteria._btn_clear_text;
            this._tooltip.SetToolTip(this._btn_declarant_clear, resource_panel_report_catch_criteria._btn_clear_tip);
            this._btn_declarant_clear.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this._layout_table.Controls.Add(
                                            this._btn_declarant_clear,
                                            panel_report_catch_criteria._COL_CLEAR_,
                                            panel_report_catch_criteria._ROW_DECLARANT_
                                           );
        }

        #endregion //__INITIALIZE__

        /*
         * --------------------------------------------------------------------
         *                          FUNCTIONS
         * --------------------------------------------------------------------
         */
        #region __FUNCTIONS__
        /// <summary>
        /// calc_min_size( )
        /// </summary>
        private void calc_min_size( )
        {
            const int _chars_in_label_ = 16;

            System.Drawing.Graphics gr = this.CreateGraphics();
            String s_measure_lbl = new String('W', _chars_in_label_);
            SizeF szf_lbl = gr.MeasureString(s_measure_lbl, this.Font);

            this.min_label_size = new Size((int)szf_lbl.Width, (int)szf_lbl.Height);

            const int _chars_in_btn_ = 2;
            String s_measure_btn = new String('W', _chars_in_btn_);
            SizeF szf_btn = gr.MeasureString(s_measure_btn, this.Font);

            this.min_button_size = new Size((int)szf_btn.Width, (int)szf_btn.Height);

        }
        /// <summary>
        /// calc_layout_column_width( )
        /// </summary>
        private void calc_layout_columns_width( )
        {
            this._COL_WIDTH_[_COL_LABEL_] = this.min_label_size.Width;
            this._COL_WIDTH_[_COL_CLEAR_] = this._COL_WIDTH_[_COL_SELECT_] 
                                                = this.min_button_size.Width;
            int col_text_width = this._layout_table.Width;
            col_text_width -= this.min_label_size.Width + this.min_button_size.Width * 2;
            this._COL_WIDTH_[_COL_TEXT_] = 
                col_text_width > 0 ? col_text_width : this.min_label_size.Width;

            for (int i=0; i < this._layout_table.ColumnCount; ++i)
            {
                this._layout_table.ColumnStyles[i].SizeType = SizeType.Absolute;
                this._layout_table.ColumnStyles[i].Width = this._COL_WIDTH_[i];
            }
        }
        /// <summary>
        /// panel_select_criteria_SizeChanged(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_select_criteria_SizeChanged(object sender, EventArgs e)
        {
            //this.calc_layout_columns_width();
        }
        /// <summary>
        /// panel_select_criteria_FontChanged(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_select_criteria_FontChanged(object sender, EventArgs e)
        {
            //this.calc_min_size();

            //this.calc_layout_columns_width();
        }


        #endregion//__FUNCTIONS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        private const int _LAYOUT_COLS_ = 9;
        private const int _LAYOUT_ROWS_ = 6;
        private const int _SPAN_COLUMNS_SPACE_YEAR_ = 2;
        private const int _SPAN_COLUMNS_CRITERIA_ = 6;

        private const int _ROW_YEAR_ = 0;
        private const int _ROW_SUBJECT_ = 1;
        private const int _ROW_REGIME_ = 2;
        private const int _ROW_REGION_ = 3;
        private const int _ROW_FISH_ = 4;
        private const int _ROW_DECLARANT_ = 5;

        private const int _COL_LABEL_ = 0;
        private const int _COL_TEXT_ = 1;
        private const int _COL_PERCENT_LABEL_ = 2;
        private const int _COL_PERCENT_ = 3;
        private const int _COL_CATCH_LABEL_ = 4;
        private const int _COL_CATCH_ = 5;
        private const int _COL_SPACE_ = 6;
        private const int _COL_SELECT_ = 7;
        private const int _COL_CLEAR_ = 8;

        private const int _PERCENT_DEFAULT_ = 50;

        //ширина столбцов в процентах
        private int[] _COL_WIDTH_ = { 12, 7, 8, 5, 8, 16, 38, 3, 3 };
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private TableLayoutPanel _layout_table;
        private TextBox _x_subject;
        private TextBox _x_regime;
        private TextBox _x_region;
        private TextBox _x_fish;
        private TextBox _x_declarant;
        private combobox_year _cbx_year;
        private NumericUpDown _num_percent;
        private combobox_catch_stat _cbx_stat;
        private Button _btn_subject;
        private Button _btn_regime;
        private Button _btn_region;
        private Button _btn_fish;
        private Button _btn_declarant;
        private Button _btn_subject_clear;
        private Button _btn_regime_clear;
        private Button _btn_region_clear;
        private Button _btn_fish_clear;
        private Button _btn_declarant_clear;

        private System.Windows.Forms.ToolTip _tooltip;
        //
        #endregion//__FIELDS__

    }//public class panel_report_catch_criteria : Panel

}//namespace cfmc.quotas.forms
