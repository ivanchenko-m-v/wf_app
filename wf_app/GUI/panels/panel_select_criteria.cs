using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using wf_app.resources;

namespace wf_app.GUI.panels
{
    public class panel_select_criteria : Panel
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public panel_select_criteria()
        {
            InitializeComponent();
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
            this._layout_table = new System.Windows.Forms.TableLayoutPanel();

            this._x_subject = new System.Windows.Forms.TextBox();
            this._x_regime = new System.Windows.Forms.TextBox();
            this._x_region = new System.Windows.Forms.TextBox();
            this._x_fish = new System.Windows.Forms.TextBox();
            this._x_declarant = new System.Windows.Forms.TextBox();
        }

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.create_form_elements();

            this._layout_table.SuspendLayout();
            this.SuspendLayout();
            //
            //_layout_table
            //
            this.init_layout( );
            //
            //_x_subject
            //
            this.init_subject( );
            //
            //_x_regime
            //
            this.init_regime( );
            //
            //_x_region
            //
            this.init_region( );
            //
            //_x_fish
            //
            this.init_fish( );
            //
            //_x_declarant
            //
            this.init_declarant( );
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
            this._layout_table.ColumnCount = panel_select_criteria._LAYOUT_COLS_;
            for( int i = 0; i < panel_select_criteria._LAYOUT_COLS_; ++i )
            {
                this._layout_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            }
            this._layout_table.RowCount = panel_select_criteria._LAYOUT_ROWS_;
            for (int i = 0; i < panel_select_criteria._LAYOUT_ROWS_; ++i)
            {
                this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            }
            this._layout_table.Dock = DockStyle.Fill;
            this._layout_table.TabIndex = 0;
        }
        /// <summary>
        /// init_subject( )
        /// </summary>
        private void init_subject( )
        {
            System.Windows.Forms.Label lbl = new Label();
            lbl.Text = resource_panel_search_criteria._x_subject;
        }
        /// <summary>
        /// init_regime( )
        /// </summary>
        private void init_regime( )
        {

        }
        /// <summary>
        /// init_region( )
        /// </summary>
        private void init_region( )
        {

        }
        /// <summary>
        /// init_fish( )
        /// </summary>
        private void init_fish( )
        {

        }
        /// <summary>
        /// init_declarant( )
        /// </summary>
        private void init_declarant( )
        {

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
        private const int _LAYOUT_ROWS_ = 5;

        private const int _ROW_SUBJECT_ = 0;
        private const int _ROW_REGIME_ = 1;
        private const int _ROW_REGION_ = 2;
        private const int _ROW_FISH_ = 3;
        private const int _ROW_DECLARANT_ = 4;

        private const int _COL_LABEL_ = 0;
        private const int _COL_TEXT_ = 0;
        private const int _COL_SELECT_ = 0;
        private const int _COL_CLEAR_ = 0;
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //
        private System.Windows.Forms.TableLayoutPanel _layout_table;
        private System.Windows.Forms.TextBox _x_subject;
        private System.Windows.Forms.TextBox _x_regime;
        private System.Windows.Forms.TextBox _x_region;
        private System.Windows.Forms.TextBox _x_fish;
        private System.Windows.Forms.TextBox _x_declarant;
        //
        #endregion//__FIELDS__

    }//public class panel_select_criteria : Panel

}//namespace wf_app.GUI.panels
