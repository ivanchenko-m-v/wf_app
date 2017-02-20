//=============================================================================
// form_report_catch - форма отчётов о вылове ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  17-02-2017
// Дата обновления:         20-02-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_app
{
    public class form_report_catch : Form
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public form_report_catch()
        {
            this.MinimumSize = new Size(
                                        form_report_catch._MIN_WIDTH_, 
                                        form_report_catch._MIN_HEIGHT_
                                       );

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
            //layout
            this._layout_table = new System.Windows.Forms.TableLayoutPanel();
            //
            this._pn_criteria = new GUI.panels.panel_select_criteria();
            this._lv_result = new GUI.controls.listview_report_catch_2_years();
            this._pb_process = new System.Windows.Forms.ProgressBar( );
            this._pn_buttons = new GUI.panels.panel_control_buttons();
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
            //_row_result
            //
            this.init_layout_row_result( );
            //
            //_row_progress
            //
            this.init_layout_row_progress( );
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
            this._layout_table.ColumnCount = form_report_catch._LAYOUT_COLS_;
            for (int i = 0; i < form_report_catch._LAYOUT_COLS_; ++i)
            {
                this._layout_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            }
            this._layout_table.RowCount = form_report_catch._LAYOUT_ROWS_;
            for (int i = 0; i < form_report_catch._LAYOUT_ROWS_; ++i)
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
                                            form_report_catch._COL_CONTROL_,
                                            form_report_catch._ROW_CRITERIA_
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
                                            form_report_catch._COL_CONTROL_,
                                            form_report_catch._ROW_RESULT_
                                           );
        }
        /// <summary>
        /// init_layout_row_progress( )
        /// </summary>
        private void init_layout_row_progress()
        {
            this._pb_process.AutoSize = true;
            this._pb_process.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            this._pb_process.Dock = DockStyle.Top;
            this._layout_table.Controls.Add(
                                            this._pb_process,
                                            form_report_catch._COL_CONTROL_,
                                            form_report_catch._ROW_PROGRESS_
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
                                            form_report_catch._COL_CONTROL_,
                                            form_report_catch._ROW_BUTTONS_
                                           );
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
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        private const int _MIN_WIDTH_ = 1024;
        private const int _MIN_HEIGHT_ = 768;

        private const int _LAYOUT_COLS_ = 1;
        private const int _LAYOUT_ROWS_ = 4;

        private const int _ROW_CRITERIA_ = 0;
        private const int _ROW_RESULT_ = 1;
        private const int _ROW_PROGRESS_ = 2;
        private const int _ROW_BUTTONS_ = 3;

        private const int _COL_CONTROL_ = 0;

        //высота строк в процентах
        private int[] _ROW_HEIGHT_ = { 23, 69, 5, 8 };
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private System.Windows.Forms.TableLayoutPanel _layout_table;
        private wf_app.GUI.panels.panel_select_criteria _pn_criteria;
        private wf_app.GUI.controls.listview_report_catch_2_years _lv_result;
        private System.Windows.Forms.ProgressBar _pb_process;
        private wf_app.GUI.panels.panel_control_buttons _pn_buttons;
        //
        #endregion//__FIELDS__
    }

}//namespace wf_app
