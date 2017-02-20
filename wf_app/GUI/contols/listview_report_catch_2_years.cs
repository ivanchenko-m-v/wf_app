//=============================================================================
// listview_report_catch_2_years - список результирующих строк запроса выборки 
//                         данных отчёта о вылове ВБР за 2 года
// Автор: Иванченко М.В.
// Дата начала разработки:  20-02-2017
// Дата обновления:         20-02-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;

using wf_app.resources;

namespace wf_app.GUI.controls
{
    public class listview_report_catch_2_years : ListView
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public listview_report_catch_2_years()
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
            this.View = View.Details;
            this.GridLines = true;
            this.SuspendLayout();
            //
            //_layout
            //
            this.init_columns( );
            //--
            this.ResumeLayout(false);
        }
        /// <summary>
        /// init_columns( )
        /// </summary>
        private void init_columns( )
        {
            //declarant
            this.init_column(resource_listview_report._column_declarant, this._COL_WIDTH_[0]);
            //inn
            this.init_column(resource_listview_report._column_inn, this._COL_WIDTH_[1]);
            //fish
            this.init_column(resource_listview_report._column_fish, this._COL_WIDTH_[2]);
            //region
            this.init_column(resource_listview_report._column_region, this._COL_WIDTH_[3]);
            //subject
            this.init_column(resource_listview_report._column_subject, this._COL_WIDTH_[4]);
            //portion
            this.init_column(resource_listview_report._column_portion, this._COL_WIDTH_[5]);
            //limit 1
            this.init_column(resource_listview_report._column_limit, this._COL_WIDTH_[6]);
            //catch 1
            this.init_column(resource_listview_report._column_catch, this._COL_WIDTH_[7]);
            //percent 1
            this.init_column(resource_listview_report._column_percent, this._COL_WIDTH_[8]);
            //limit 2
            this.init_column(resource_listview_report._column_limit, this._COL_WIDTH_[9]);
            //catch 2
            this.init_column(resource_listview_report._column_catch, this._COL_WIDTH_[10]);
            //percent 2
            this.init_column(resource_listview_report._column_percent, this._COL_WIDTH_[11]);
        }

        private void init_column( String text, int width = -1)
        {
            ColumnHeader column = new ColumnHeader();
            column.Text = text;
            if(width>0)
            {
                column.Width = width;
            }
            this.Columns.Add(column);
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

        int[] _COL_WIDTH_ = { 100, 75, 100, 100, 100, 50, 50, 50, 50, 50, 50, 50 };

        private const int _COL_DECLARANT_ = 0;
        private const int _COL_INN_ = 1;
        private const int _COL_FISH_ = 2;
        private const int _COL_REGION_ = 3;
        private const int _COL_SUBJECT_ = 4;
        private const int _COL_PORTION_ = 5;
        private const int _COL_LIMIT_1_ = 6;
        private const int _COL_CATCH_1_ = 7;
        private const int _COL_PERCENT_1_ = 8;
        private const int _COL_LIMIT_2_ = 9;
        private const int _COL_CATCH_2_ = 10;
        private const int _COL_PERCENT_2_ = 11;
        //
        #endregion//__FIELDS__

    }//public class panel_select_criteria : Panel

}//namespace wf_app.GUI.panels
