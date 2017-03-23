//=============================================================================
// REPORT_WBR_CATCH
// panel_report_catch_criteria - панель выбора условий отбора в отчёте о
//                         пользователях ВБР, которые не выбрали квоту.
// Автор: Иванченко М.В.
// Дата начала разработки:  17-02-2017
// Дата обновления:         23-03-2017
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

        public db_objects.params_report_WBR_catch criteria
        {
            get
            {
                db_objects.params_report_WBR_catch c = 
                                new db_objects.params_report_WBR_catch( );
                c.year_1st = this._cbx_year.current_year - 1;
                c.year_2nd = this._cbx_year.current_year;
                c.percent = (int)this._num_percent.Value;
                c.stat_type = this._cbx_stat_data.current_item_data;
                c.id_subject = this._cbx_subject.id_subject;
                c.id_regime = this._cbx_regime.id_regime;
                c.id_region = this._cbx_region.id_region;
                c.id_WBR = this._cbx_WBR.id_WBR;
                c.id_declarant = this._cbx_declarant.id_declarant;

                return c;
            }
        }
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
            //1st line controls
            this._cbx_year = new combobox_year();
            this._num_percent = new NumericUpDown();
            this._cbx_stat_data = new combobox_catch_stat();
            //2nd line controls
            this._cbx_subject = new combobox_subject( );
            this._cbx_regime = new combobox_regime( );
            this._cbx_region = new combobox_region( );
            //3rd line controls
            this._cbx_WBR = new combobox_WBR( );
            this._cbx_declarant = new combobox_declarant( );
        }

        /// <summary> 
        /// init_form_elements( )
        /// </summary>
        private void init_form_elements( )
        {
            this._layout_table.SuspendLayout( );
            this.SuspendLayout( );
            //
            //_layout_table
            //
            this.init_layout( );
            //
            //_cbx_year
            //
            this.init_cbx_year( );
            //
            //_cbx_stat_data
            //
            this.init_cbx_stat_data( );
            //
            //_cbx_year
            //
            this.init_num_percent( );
            //
            //_cbx_subject
            //
            this.init_cbx_subject( );
            //
            //_cbx_regime
            //
            this.init_cbx_regime( );
            //
            //_cbx_region
            //
            this.init_cbx_region( );
            //
            //_cbx_fish
            //
            this.init_cbx_WBR( );
            //
            //_cbx_declarant
            //
            this.init_cbx_declarant( );
            //--
            this._layout_table.ResumeLayout( false );
            this.ResumeLayout( false );
        }
        /// <summary>
        /// init_layout( )
        /// </summary>
        private void init_layout( )
        {
            this._layout_table.Name = "_layout_table";
            this._layout_table.ColumnCount = panel_report_catch_criteria._LAYOUT_COLS_;
            for( int i = 0; i < panel_report_catch_criteria._LAYOUT_COLS_; ++i )
            {
                System.Windows.Forms.ColumnStyle col_style = new ColumnStyle( );
                col_style.SizeType = SizeType.Percent;
                col_style.Width = _COL_WIDTH_[i];
                this._layout_table.ColumnStyles.Add( col_style );
            }
            this._layout_table.RowCount = panel_report_catch_criteria._LAYOUT_ROWS_;
            for( int i = 0; i < panel_report_catch_criteria._LAYOUT_ROWS_; ++i )
            {
                this._layout_table.RowStyles.Add( new System.Windows.Forms.RowStyle( ) );
            }
            this._layout_table.Dock = DockStyle.Fill;
            this._layout_table.TabIndex = 0;

            this.Controls.Add( this._layout_table );
        }
        /// <summary>
        /// void init_table_layout_control( Control ctl, string title, int row, int col, int tabindex )
        /// - размещение элемента управления формы на сетке таблицы
        /// </summary>
        /// <param name="ctl">элемент управления формы</param>
        /// <param name="title">подпись элемента управления</param>
        /// <param name="row">строка сетки таблицы</param>
        /// <param name="col">столбец сетки таблицы</param>
        /// <param name="tabindex">порядковый номер при навигации по форме</param>
        private void init_table_layout_control( Control ctl, string title, int row, int col, int tabindex )
        {
            Label lbl = new Label( );
            lbl.Text = title;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            col - 1, //подпись располагается перед элементом управления
                                            row      //и в той же строке
                                           );

            ctl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add( ctl, col, row );
            ctl.TabIndex = tabindex;
        }
        /// <summary>
        /// init_cbx_year( )
        /// </summary>
        private void init_cbx_year( )
        {
            this.init_table_layout_control( 
                                            this._cbx_year, 
                                            rc_report_catch.lbl_year, 
                                            _ROW_YEAR_, 
                                            _COL_YEAR_, 
                                            _TABINDEX_YEAR_ 
                                          );
            /*
            Label lbl = new Label( );
            lbl.Text = rc_report_catch.lbl_year;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_report_catch_criteria._COL_YEAR_ - 1,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            this._cbx_year.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_year,
                                            panel_report_catch_criteria._COL_YEAR_,
                                            panel_report_catch_criteria._ROW_YEAR_
                                           );
            this._cbx_year.TabIndex = panel_report_catch_criteria._TABINDEX_YEAR_;
            */
        }
        /// <summary>
        /// init_num_percent( )
        /// </summary>
        private void init_num_percent( )
        {
            this.init_table_layout_control(
                                            this._num_percent,
                                            rc_report_catch.lbl_percent,
                                            _ROW_PERCENT_,
                                            _COL_PERCENT_,
                                            _TABINDEX_PERCENT_
                                          );
            this._num_percent.Value = _PERCENT_DEFAULT_;
        }
        /// <summary>
        /// init_cbx_stat_data( )
        /// </summary>
        private void init_cbx_stat_data( )
        {
            this.init_table_layout_control(
                                         this._cbx_stat_data,
                                         rc_report_catch.lbl_stat_data,
                                         _ROW_STAT_DATA_,
                                         _COL_STAT_DATA_,
                                         _TABINDEX_STAT_DATA_
                                       );
        }
        /// <summary>
        /// init_cbx_subject( )
        /// </summary>
        private void init_cbx_subject( )
        {
            this.init_table_layout_control(
                                         this._cbx_subject,
                                         rc_report_catch.lbl_subject,
                                         _ROW_SUBJECT_,
                                         _COL_SUBJECT_,
                                         _TABINDEX_SUBJECT_
                                       );
            this._layout_table.SetColumnSpan( this._cbx_subject, _SPAN_COLUMNS_SUBJECT_ );
        }
        /// <summary>
        /// init_cbx_regime( )
        /// </summary>
        private void init_cbx_regime( )
        {
            this.init_table_layout_control(
                                         this._cbx_regime,
                                         rc_report_catch.lbl_regime,
                                         _ROW_REGIME_,
                                         _COL_REGIME_,
                                         _TABINDEX_REGIME_
                                       );
            this._layout_table.SetColumnSpan( this._cbx_regime, _SPAN_COLUMNS_REGIME_ );
        }
        /// <summary>
        /// init_cbx_region( )
        /// </summary>
        private void init_cbx_region( )
        {
            this.init_table_layout_control(
                                         this._cbx_region,
                                         rc_report_catch.lbl_region,
                                         _ROW_REGION_,
                                         _COL_REGION_,
                                         _TABINDEX_REGION_
                                       );
        }
        /// <summary>
        /// init_cbx_WBR( )
        /// </summary>
        private void init_cbx_WBR( )
        {
            this.init_table_layout_control(
                                         this._cbx_WBR,
                                         rc_report_catch.lbl_WBR,
                                         _ROW_WBR_,
                                         _COL_WBR_,
                                         _TABINDEX_WBR_
                                       );
            this._layout_table.SetColumnSpan( this._cbx_WBR, _SPAN_COLUMNS_WBR_ );
        }
        /// <summary>
        /// init_cbx_declarant( )
        /// </summary>
        private void init_cbx_declarant( )
        {
            this.init_table_layout_control(
                                         this._cbx_declarant,
                                         rc_report_catch.lbl_declarant,
                                         _ROW_DECLARANT_,
                                         _COL_DECLARANT_,
                                         _TABINDEX_DECLARANT_
                                       );
            this._layout_table.SetColumnSpan( this._cbx_declarant, _SPAN_COLUMNS_DECLARANT_ );
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
            /*
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
            */
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
        private const int _LAYOUT_COLS_ = 8;
        private const int _LAYOUT_ROWS_ = 3;
        //количество занимаемых соседних столбцов для элементов формы 
        private const int _SPAN_COLUMNS_SUBJECT_ = 2;
        private const int _SPAN_COLUMNS_REGIME_ = 2;
        private const int _SPAN_COLUMNS_WBR_ = 2;
        private const int _SPAN_COLUMNS_DECLARANT_ = 4;
        //номера строк в табличном расположении
        private const int _ROW_YEAR_ = 0;
        private const int _ROW_PERCENT_ = 0;
        private const int _ROW_STAT_DATA_ = 0;
        private const int _ROW_SUBJECT_ = 1;
        private const int _ROW_REGIME_ = 1;
        private const int _ROW_REGION_ = 1;
        private const int _ROW_WBR_ = 4;
        private const int _ROW_DECLARANT_ = 4;
        //номера столбцов в табличном расположении
        private const int _COL_YEAR_ = 1;
        private const int _COL_PERCENT_ = 4;
        private const int _COL_STAT_DATA_ = 7;
        private const int _COL_SUBJECT_ = 1;
        private const int _COL_REGIME_ = 4;
        private const int _COL_REGION_ = 7;
        private const int _COL_WBR_ = 1;
        private const int _COL_DECLARANT_ = 4;
        //порядок обхода по клавише <TAB>
        private const int _TABINDEX_YEAR_ = 0;
        private const int _TABINDEX_PERCENT_ = 1;
        private const int _TABINDEX_STAT_DATA_ = 2;
        private const int _TABINDEX_SUBJECT_ = 3;
        private const int _TABINDEX_REGIME_ = 4;
        private const int _TABINDEX_REGION_ = 5;
        private const int _TABINDEX_WBR_ = 6;
        private const int _TABINDEX_DECLARANT_ = 7;

        private const int _PERCENT_DEFAULT_ = 50;

        //ширина столбцов в процентах
        private int[] _COL_WIDTH_ = { 7, 4, 12, 9, 4, 12, 10, 15  };
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private TableLayoutPanel _layout_table;
        //1st layout table row
        private combobox_year _cbx_year;
        private NumericUpDown _num_percent;
        private combobox_catch_stat _cbx_stat_data;
        //
        private combobox_subject _cbx_subject;
        private combobox_regime _cbx_regime;
        private combobox_region _cbx_region;
        private combobox_WBR _cbx_WBR;
        private combobox_declarant _cbx_declarant;

        //
        #endregion//__FIELDS__

    }//public class panel_report_catch_criteria : Panel

}//namespace cfmc.quotas.forms
