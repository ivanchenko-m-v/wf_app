//=============================================================================
// REPORT_WBR_CATCH
// form_report_catch - форма отчётов о вылове ВБР
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

namespace cfmc.quotas.forms
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
            //this.Icon = app_resources.icon_app;
            this.MinimumSize = new Size(
                                        form_report_catch._MIN_WIDTH_, 
                                        form_report_catch._MIN_HEIGHT_
                                       );
            this.Text = rc_report_catch.form_title;
            this.StartPosition = FormStartPosition.CenterScreen;


            this.create_form_elements();

            this.init_form_elements();

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
            this._layout_table = new System.Windows.Forms.TableLayoutPanel();
            //
            this._pn_criteria = new panel_report_catch_criteria();
            this._lv_result = new controls.listview_report_catch_2_years();
            this._pb_process = new System.Windows.Forms.ProgressBar( );
            this._pn_buttons = new panel_control_buttons();
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
        /// <summary>
        /// subscribe_events( )
        /// </summary>
        private void subscribe_events( )
        {
            data_model_store.ReportDataComplete += data_model_store_ReportDataComplete;
            /*
            this._lv_result.RefreshPercentChanged += lv_result_RefreshPercentChanged;
            this._lv_result.SortStarting += lv_result_SortStarting;
            this._lv_result.SortPercentChanged += lv_result_SortPercentChanged;
            this._lv_result.SortFinished += lv_result_SortFinished;
            */
            //
            this._pn_buttons.Select += pn_buttons_Select;
            this._pn_buttons.Export += pn_buttons_Export;
            this._pn_buttons.Exit += pn_buttons_Exit;
            //
            //business_logic.excel_producer.ExportStart += lv_result_SortStarting;
            //business_logic.excel_producer.ExportFinish += lv_result_SortFinished;
            //business_logic.excel_producer.ExportPercentChanged += lv_result_SortPercentChanged;
        }
        #endregion //__INITIALIZE__

        /*
         * --------------------------------------------------------------------
         *                          METHODS
         * --------------------------------------------------------------------
         */
        #region __METHODS__
        /// <summary>
        /// select_report_data( ) 
        /// </summary>
        private void select_report_data( )
        {
            Cursor stored_cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                business_logic.select_report_data( this._pn_criteria.criteria );
                this._lv_result.refresh_data( );
            }
            catch( Exception ex )
            {
                string s_msg = String.Format(
                                             "{0}\n{1} {2}\n{3}",
                                             rc_report_catch.msgbox_select_message,
                                             rc_report_catch.msgbox_exception_type,
                                             ex.GetType( ).ToString( ),
                                             ex.Message
                                            );
                MessageBox.Show(
                                s_msg,
                                rc_report_catch.msgbox_exception_title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                               );
            }
            finally
            {
                //clear progress bar, when all data in the listview
                this._pb_process.Value = 0;
                this.Cursor = stored_cursor;
            }
        }

        #endregion//__FUNCTIONS__
        /*
        * --------------------------------------------------------------------
        *                          EVENTS
        * --------------------------------------------------------------------
        */
        #region __EVENTS__
        private void pn_buttons_Exit( object sender, EventArgs e )
        {
        }

        private void pn_buttons_Export( object sender, EventArgs e )
        {
        }

        private void pn_buttons_Select( object sender, EventArgs e )
        {
            //установить значения индикатора процесса выборки
            this._pb_process.Maximum = form_report_catch._MAX_REFRESH_PROGRESS_;
            this._pb_process.Value = form_report_catch._MIN_PROGRESS_;
            //выборка данных
            this.select_report_data( );
        }
        /// <summary>
        /// data_model_store_ReportDataComplete( object sender, EventArgs e )
        /// - обработчик события окончания выборки данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void data_model_store_ReportDataComplete( object sender, EventArgs e )
        {
            //считаем, что выполнение запроса - полдела
            this._pb_process.Value = form_report_catch._MAX_REFRESH_PROGRESS_ / 2;
            //заполняем список - ещё полдела
            this._lv_result.refresh_data( );
        }
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        private const int _MIN_WIDTH_ = 1024;
        private const int _MIN_HEIGHT_ = 768;

        private const int _MIN_PROGRESS_ = 0;
        private const int _MAX_SORT_PROGRESS_ = 100;
        private const int _MAX_REFRESH_PROGRESS_ = 200;

        private const int _LAYOUT_COLS_ = 1;
        private const int _LAYOUT_ROWS_ = 4;

        private const int _ROW_CRITERIA_ = 0;
        private const int _ROW_RESULT_ = 1;
        private const int _ROW_PROGRESS_ = 2;
        private const int _ROW_BUTTONS_ = 3;

        private const int _COL_CONTROL_ = 0;

        //высота строк в процентах
        private int[] _ROW_HEIGHT_ = { 14, 77, 2, 7 };
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private System.Windows.Forms.TableLayoutPanel _layout_table;
        private panel_report_catch_criteria _pn_criteria;
        private controls.listview_report_catch_2_years _lv_result;
        private System.Windows.Forms.ProgressBar _pb_process;
        private panel_control_buttons _pn_buttons;
        //
        #endregion//__FIELDS__

    }//public class form_report_catch : Form

}//namespace cfmc.quotas.forms
