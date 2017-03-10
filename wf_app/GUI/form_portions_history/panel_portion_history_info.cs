
//=============================================================================
// panel_portion_history_info - информация о выбранной доле в списке результатов 
//                              выборки информации о передачи доли при 
//                              реорганизациях пользователей ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         10-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System.Windows.Forms;

using cfmc.quotas.resources;

namespace cfmc.quotas.forms
{
    public class panel_portion_history_info : Panel
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public panel_portion_history_info()
        {
            this.initialize();
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
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize()
        {
            this.create_form_elements();

            this.init_form_elements();
        }

        /// <summary>
        /// create_form_elements( )
        /// </summary>
        private void create_form_elements()
        {
            this._layout_table = new System.Windows.Forms.TableLayoutPanel();
            //
            _lbl_basin = new System.Windows.Forms.Label( );
            _lbl_regime = new System.Windows.Forms.Label();
            _lbl_WBR = new System.Windows.Forms.Label();
            _lbl_region = new System.Windows.Forms.Label();
            _lbl_portion = new System.Windows.Forms.Label();
            _lbl_date_open = new System.Windows.Forms.Label();
            _lbl_date_close = new System.Windows.Forms.Label();
            _lbl_report_number = new System.Windows.Forms.Label();
            _lbl_report_date = new System.Windows.Forms.Label();
            _lbl_declarant = new System.Windows.Forms.Label();
            _lbl_INN = new System.Windows.Forms.Label();
            _lbl_contract_number = new System.Windows.Forms.Label();
            _lbl_contract_date = new System.Windows.Forms.Label();
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
            //_lbl_basin
            //
            this.init_lbl_basin();
            //
            //_lbl_regime
            //
            this.init_lbl_regime();
            //
            //_lbl_WBR
            //
            this.init_lbl_WBR();
            //
            //_lbl_region
            //
            this.init_lbl_region();
            //
            //_lbl_portion
            //
            this.init_lbl_portion();
            //
            //_lbl_date_open
            //
            this.init_lbl_date_open();
            //
            //_lbl_date_close
            //
            this.init_lbl_date_close();
            //
            //_lbl_report_number
            //
            this.init_lbl_report_number();
            //
            //_lbl_report_date
            //
            this.init_lbl_report_date();
            //
            //_lbl_declarant
            //
            this.init_lbl_declarant();
            //
            //_lbl_INN
            //
            this.init_lbl_INN();
            //
            //_lbl_contract_number
            //
            this.init_lbl_contract_number();
            //
            //_lbl_contract_date
            //
            this.init_lbl_contract_date();
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
            this._layout_table.ColumnCount = panel_portion_history_info._LAYOUT_COLS_;
            for (int i = 0; i < panel_portion_history_info._LAYOUT_COLS_; ++i)
            {
                System.Windows.Forms.ColumnStyle col_style = new ColumnStyle();
                col_style.SizeType = SizeType.Percent;
                col_style.Width = _COL_WIDTH_[i];
                this._layout_table.ColumnStyles.Add(col_style);
            }
            this._layout_table.RowCount = panel_portion_history_info._LAYOUT_ROWS_;
            for (int i = 0; i < panel_portion_history_info._LAYOUT_ROWS_; ++i)
            {
                this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            }
            this._layout_table.Dock = DockStyle.Fill;
            this._layout_table.TabIndex = 0;

            this.Controls.Add(this._layout_table);
        }
        /// <summary>
        /// init_lbl_basin( )
        /// </summary>
        private void init_lbl_basin()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_basin;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_BASIN_,
                                            panel_portion_history_info._ROW_BASIN_
                                           );
            this._lbl_basin.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_basin,
                                            panel_portion_history_info._COL_BASIN_,
                                            panel_portion_history_info._ROW_BASIN_
                                           );
        }
        /// <summary>
        /// init_lbl_regime( )
        /// </summary>
        private void init_lbl_regime()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_regime;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_REGIME_,
                                            panel_portion_history_info._ROW_REGIME_
                                           );
            this._lbl_regime.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_regime,
                                            panel_portion_history_info._COL_REGIME_,
                                            panel_portion_history_info._ROW_REGIME_
                                           );
        }
        /// <summary>
        /// init_lbl_WBR( )
        /// </summary>
        private void init_lbl_WBR()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_WBR;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_WBR_,
                                            panel_portion_history_info._ROW_WBR_
                                           );
            this._lbl_WBR.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_WBR,
                                            panel_portion_history_info._COL_WBR_,
                                            panel_portion_history_info._ROW_WBR_
                                           );
        }
        /// <summary>
        /// init_lbl_region( )
        /// </summary>
        private void init_lbl_region()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_region;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_REGION_,
                                            panel_portion_history_info._ROW_REGION_
                                           );
            this._lbl_region.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_region,
                                            panel_portion_history_info._COL_REGION_,
                                            panel_portion_history_info._ROW_REGION_
                                           );
        }
        /// <summary>
        /// init_lbl_portion( )
        /// </summary>
        private void init_lbl_portion()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_portion;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_PORTION_,
                                            panel_portion_history_info._ROW_PORTION_
                                           );
            this._lbl_portion.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_portion,
                                            panel_portion_history_info._COL_PORTION_,
                                            panel_portion_history_info._ROW_PORTION_
                                           );
        }
        /// <summary>
        /// init_lbl_date_open( )
        /// </summary>
        private void init_lbl_date_open()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_date_open;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_DATE_OPEN_,
                                            panel_portion_history_info._ROW_DATE_OPEN_
                                           );
            this._lbl_date_open.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_date_open,
                                            panel_portion_history_info._COL_DATE_OPEN_,
                                            panel_portion_history_info._ROW_DATE_OPEN_
                                           );
        }
        /// <summary>
        /// init_lbl_date_close( )
        /// </summary>
        private void init_lbl_date_close()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_date_close;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_DATE_CLOSE_,
                                            panel_portion_history_info._ROW_DATE_CLOSE_
                                           );
            this._lbl_date_close.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_date_close,
                                            panel_portion_history_info._COL_DATE_CLOSE_,
                                            panel_portion_history_info._ROW_DATE_CLOSE_
                                           );
        }
        /// <summary>
        /// init_lbl_report_number( )
        /// </summary>
        private void init_lbl_report_number()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_report_number;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_REPORT_NUMBER_,
                                            panel_portion_history_info._ROW_REPORT_NUMBER_
                                           );
            this._lbl_report_number.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_report_number,
                                            panel_portion_history_info._COL_REPORT_NUMBER_,
                                            panel_portion_history_info._ROW_REPORT_NUMBER_
                                           );
        }
        /// <summary>
        /// init_lbl_report_date( )
        /// </summary>
        private void init_lbl_report_date()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_report_date;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_REPORT_DATE_,
                                            panel_portion_history_info._ROW_REPORT_DATE_
                                           );
            this._lbl_report_date.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_report_date,
                                            panel_portion_history_info._COL_REPORT_DATE_,
                                            panel_portion_history_info._ROW_REPORT_DATE_
                                           );
        }
        /// <summary>
        /// init_lbl_declarant( )
        /// </summary>
        private void init_lbl_declarant()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_declarant;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_DECLARANT_,
                                            panel_portion_history_info._ROW_DECLARANT_
                                           );
            this._lbl_declarant.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_declarant,
                                            panel_portion_history_info._COL_DECLARANT_,
                                            panel_portion_history_info._ROW_DECLARANT_
                                           );
            this._layout_table.SetColumnSpan( this._lbl_declarant, _COL_DECLARANT_SPAN_ );
        }
        /// <summary>
        /// init_lbl_INN( )
        /// </summary>
        private void init_lbl_INN()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_INN;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_INN_,
                                            panel_portion_history_info._ROW_INN_
                                           );
            this._lbl_INN.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_INN,
                                            panel_portion_history_info._COL_INN_,
                                            panel_portion_history_info._ROW_INN_
                                           );
        }
        /// <summary>
        /// init_lbl_contract_number( )
        /// </summary>
        private void init_lbl_contract_number()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_contract_number;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_CONTRACT_NUMBER_,
                                            panel_portion_history_info._ROW_CONTRACT_NUMBER_
                                           );
            this._lbl_contract_number.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_contract_number,
                                            panel_portion_history_info._COL_CONTRACT_NUMBER_,
                                            panel_portion_history_info._ROW_CONTRACT_NUMBER_
                                           );
        }
        /// <summary>
        /// init_lbl_contract_date( )
        /// </summary>
        private void init_lbl_contract_date()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_contract_date;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portion_history_info._COL_LBL_CONTRACT_DATE_,
                                            panel_portion_history_info._ROW_CONTRACT_DATE_
                                           );
            this._lbl_contract_date.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._lbl_contract_date,
                                            panel_portion_history_info._COL_CONTRACT_DATE_,
                                            panel_portion_history_info._ROW_CONTRACT_DATE_
                                           );
        }

        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        #endregion//__EVENTS__

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

        //параметры табличного расположения элементов
        private const int _LAYOUT_COLS_ = 8;
        private const int _LAYOUT_ROWS_ = 4;

        //номера строк в табличном расположении
        private const int _ROW_BASIN_ = 0;
        private const int _ROW_REGIME_ = 0;
        private const int _ROW_WBR_ = 0;
        private const int _ROW_REGION_ = 0;
        private const int _ROW_PORTION_ = 1;
        private const int _ROW_DATE_OPEN_ = 1;
        private const int _ROW_DATE_CLOSE_ = 1;
        private const int _ROW_DECLARANT_ = 2;
        private const int _ROW_INN_ = 2;
        private const int _ROW_REPORT_DATE_ = 3;
        private const int _ROW_REPORT_NUMBER_ = 3;
        private const int _ROW_CONTRACT_DATE_ = 3;
        private const int _ROW_CONTRACT_NUMBER_ = 3;
        //номера столбцов в табличном расположении
        private const int _COL_LBL_BASIN_ = 0;
        private const int _COL_BASIN_ = 1;
        private const int _COL_LBL_REGIME_ = 2;
        private const int _COL_REGIME_ = 3;
        private const int _COL_LBL_WBR_ = 4;
        private const int _COL_WBR_ = 5;
        private const int _COL_LBL_REGION_ = 6;
        private const int _COL_REGION_ = 7;
        private const int _COL_LBL_PORTION_ = 0;
        private const int _COL_PORTION_ = 1;
        private const int _COL_LBL_DATE_OPEN_ = 2;
        private const int _COL_DATE_OPEN_ = 3;
        private const int _COL_LBL_DATE_CLOSE_ = 4;
        private const int _COL_DATE_CLOSE_ = 5;
        private const int _COL_LBL_DECLARANT_ = 0;
        private const int _COL_DECLARANT_ = 1;
        private const int _COL_DECLARANT_SPAN_ = 3;
        private const int _COL_LBL_INN_ = 4;
        private const int _COL_INN_ = 5;
        private const int _COL_LBL_REPORT_DATE_ = 0;
        private const int _COL_REPORT_DATE_ = 1;
        private const int _COL_LBL_REPORT_NUMBER_ = 2;
        private const int _COL_REPORT_NUMBER_ = 3;
        private const int _COL_LBL_CONTRACT_DATE_ = 4;
        private const int _COL_CONTRACT_DATE_ = 5;
        private const int _COL_LBL_CONTRACT_NUMBER_ = 6;
        private const int _COL_CONTRACT_NUMBER_ = 7;

        //ширина столбцов в процентах
        private int[] _COL_WIDTH_ = { 10, 15, 10, 15, 10, 15, 10, 15 };

        //
        private System.Windows.Forms.TableLayoutPanel _layout_table;
        //
        private System.Windows.Forms.Label _lbl_basin;
        private System.Windows.Forms.Label _lbl_regime;
        private System.Windows.Forms.Label _lbl_WBR;
        private System.Windows.Forms.Label _lbl_region;
        private System.Windows.Forms.Label _lbl_portion;
        private System.Windows.Forms.Label _lbl_date_open;
        private System.Windows.Forms.Label _lbl_date_close;
        private System.Windows.Forms.Label _lbl_report_number;
        private System.Windows.Forms.Label _lbl_report_date;
        private System.Windows.Forms.Label _lbl_declarant;
        private System.Windows.Forms.Label _lbl_INN;
        private System.Windows.Forms.Label _lbl_contract_number;
        private System.Windows.Forms.Label _lbl_contract_date;
        #endregion//__FIELDS__

    }//class panel_portion_history_info

}//namespace cfmc.quotas.forms

            