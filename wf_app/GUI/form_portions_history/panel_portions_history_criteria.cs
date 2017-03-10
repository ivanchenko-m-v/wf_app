//=============================================================================
// panel_portions_history_criteria - панель условий отбора в отчёте истории перехода
//                         долей пользователей ВБР.
// Автор: Иванченко М.В.
// Дата начала разработки:  09-03-2017
// Дата обновления:         10-03-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Drawing;
using System.Windows.Forms;

using cfmc.quotas.resources;
using cfmc.quotas.controls;

namespace cfmc.quotas.forms
{
    public class panel_portions_history_criteria : Panel
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public panel_portions_history_criteria()
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
            //
            this._cbx_basin = new cfmc.quotas.controls.combobox_basin();
            this._cbx_regime = new cfmc.quotas.controls.combobox_regime();
            this._cbx_WBR = new cfmc.quotas.controls.combobox_WBR();
            this._cbx_region = new cfmc.quotas.controls.combobox_region();
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
            //_cbx_basin
            //
            this.init_cbx_basin();
            //
            //_cbx_regime
            //
            this.init_cbx_regime();
            //
            //_cbx_WBR
            //
            this.init_cbx_WBR();
            //
            //_cbx_region
            //
            this.init_cbx_region();
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
            this._layout_table.ColumnCount = panel_portions_history_criteria._LAYOUT_COLS_;
            for( int i = 0; i < panel_portions_history_criteria._LAYOUT_COLS_; ++i )
            {
                System.Windows.Forms.ColumnStyle col_style = new ColumnStyle();
                col_style.SizeType = SizeType.Percent;
                col_style.Width = _COL_WIDTH_[i];
                this._layout_table.ColumnStyles.Add(col_style);
            }
            this._layout_table.RowCount = panel_portions_history_criteria._LAYOUT_ROWS_;
            for (int i = 0; i < panel_portions_history_criteria._LAYOUT_ROWS_; ++i)
            {
                this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            }
            this._layout_table.Dock = DockStyle.Fill;
            this._layout_table.TabIndex = 0;

            this.Controls.Add(this._layout_table);
        }
        /// <summary>
        /// init_cbx_basin( )
        /// </summary>
        private void init_cbx_basin()
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_basin;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portions_history_criteria._COL_LABEL_BASIN_,
                                            panel_portions_history_criteria._ROW_BASIN_
                                           );
            this._cbx_basin.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_basin,
                                            panel_portions_history_criteria._COL_TEXT_BASIN_,
                                            panel_portions_history_criteria._ROW_BASIN_
                                           );
            this._cbx_basin.TabIndex = panel_portions_history_criteria._TABINDEX_BASIN_;
        }
        /// <summary>
        /// init_cbx_regime( )
        /// </summary>
        private void init_cbx_regime( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_regime;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portions_history_criteria._COL_LABEL_REGIME_,
                                            panel_portions_history_criteria._ROW_REGIME_
                                           );
            this._cbx_regime.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_regime,
                                            panel_portions_history_criteria._COL_TEXT_REGIME_,
                                            panel_portions_history_criteria._ROW_REGIME_
                                           );
            this._cbx_regime.TabIndex = panel_portions_history_criteria._TABINDEX_REGIME_;
        }
        /// <summary>
        /// init_cbx_WBR( )
        /// </summary>
        private void init_cbx_WBR( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_WBR;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portions_history_criteria._COL_LABEL_WBR_,
                                            panel_portions_history_criteria._ROW_WBR_
                                           );
            this._cbx_WBR.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_WBR,
                                            panel_portions_history_criteria._COL_TEXT_WBR_,
                                            panel_portions_history_criteria._ROW_WBR_
                                           );
            this._cbx_WBR.TabIndex = panel_portions_history_criteria._TABINDEX_WBR_;
        }
        /// <summary>
        /// init_cbx_region( )
        /// </summary>
        private void init_cbx_region( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_portions_history.lbl_region;
            lbl.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.AutoSize = true;
            this._layout_table.Controls.Add(
                                            lbl,
                                            panel_portions_history_criteria._COL_LABEL_REGION_,
                                            panel_portions_history_criteria._ROW_REGION_
                                           );
            this._cbx_region.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this._layout_table.Controls.Add(
                                            this._cbx_region,
                                            panel_portions_history_criteria._COL_TEXT_REGION_,
                                            panel_portions_history_criteria._ROW_REGION_
                                           );
            this._cbx_region.TabIndex = panel_portions_history_criteria._TABINDEX_REGION_;
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
        private const int _LAYOUT_COLS_ = 4;
        private const int _LAYOUT_ROWS_ = 2;

        //номера строк в табличном расположении
        private const int _ROW_BASIN_ = 0;
        private const int _ROW_REGIME_ = 0;
        private const int _ROW_WBR_ = 1;
        private const int _ROW_REGION_ = 1;
        //номера столбцов в табличном расположении
        private const int _COL_LABEL_BASIN_ = 0;
        private const int _COL_TEXT_BASIN_ = 1;
        private const int _COL_LABEL_REGIME_ = 2;
        private const int _COL_TEXT_REGIME_ = 3;
        private const int _COL_LABEL_WBR_ = 0;
        private const int _COL_TEXT_WBR_ = 1;
        private const int _COL_LABEL_REGION_ = 2;
        private const int _COL_TEXT_REGION_ = 3;

        //порядок обхода по клавише <TAB>
        private const int _TABINDEX_BASIN_ = 0;
        private const int _TABINDEX_REGIME_ = 1;
        private const int _TABINDEX_WBR_ = 2;
        private const int _TABINDEX_REGION_ = 3;

        //ширина столбцов в процентах
        private int[] _COL_WIDTH_ = { 12, 38, 12, 38 };
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private System.Windows.Forms.TableLayoutPanel _layout_table;
        //
        private cfmc.quotas.controls.combobox_basin _cbx_basin;
        private cfmc.quotas.controls.combobox_regime _cbx_regime;
        private cfmc.quotas.controls.combobox_WBR _cbx_WBR;
        private cfmc.quotas.controls.combobox_region _cbx_region;
        //
        #endregion//__FIELDS__

    }//public class panel_portions_history_criteria : Panel

}//namespace cfmc.quotas.forms