//=============================================================================
// listview_portions_history - список результирующих строк запроса выборки 
//                             истории закрепления долей за пользователями ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  09-03-2017
// Дата обновления:         10-03-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;

using cfmc.quotas.resources;

namespace cfmc.quotas.controls
{
    public class listview_portions_history : ListView
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public listview_portions_history()
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
        private void init_control()
        {
            this.View = View.Details;
            this.GridLines = true;
            this.FullRowSelect = true;

            this.SuspendLayout();
            //
            //_layout
            //
            this.init_columns();
            //--
            this.ResumeLayout(false);
        }
        /// <summary>
        /// init_columns( )
        /// </summary>
        private void init_columns()
        {
            //basin
            this.init_column(resource_portions_history.column_basin, this._COL_WIDTH_[0]);
            //regime
            this.init_column(resource_portions_history.column_regime, this._COL_WIDTH_[1]);
            //fish(WBR)
            this.init_column(resource_portions_history.column_WBR, this._COL_WIDTH_[2]);
            //region
            this.init_column(resource_portions_history.column_region, this._COL_WIDTH_[3]);
            //portion
            this.init_column(resource_portions_history.column_portion, this._COL_WIDTH_[5]);
            //date open
            this.init_column(resource_portions_history.column_date_open, this._COL_WIDTH_[6]);
            //date close
            this.init_column(resource_portions_history.column_date_close, this._COL_WIDTH_[7]);
            //report number
            this.init_column(resource_portions_history.column_report_number, this._COL_WIDTH_[8]);
            //report date
            this.init_column(resource_portions_history.column_report_date, this._COL_WIDTH_[9]);
            //declarant
            this.init_column(resource_portions_history.column_declarant, this._COL_WIDTH_[10]);
            //inn
            this.init_column(resource_portions_history.column_INN, this._COL_WIDTH_[11]);
            //contract number
            this.init_column(resource_portions_history.column_contract_number, this._COL_WIDTH_[8]);
            //contract date
            this.init_column(resource_portions_history.column_contract_date, this._COL_WIDTH_[9]);
        }

        private void init_column(String text, int width = -1)
        {
            ColumnHeader column = new ColumnHeader();
            column.Text = text;
            if (width > 0)
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

            int[] _COL_WIDTH_ = {
                                    100,//basin
                                    100,//regime
                                    100,//wbr
                                    100,//region
                                    50, //portion
                                    50, //date open
                                    50, //date close
                                    50, //report number
                                    50, //report date
                                    100,//declarant
                                    50, //INN
                                    50, //contract number
                                    50  //contract date
                                };

            private const int _COL_BASIN_ = 0;
            private const int _COL_REGIME_ = 1;
            private const int _COL_FISH_ = 2;
            private const int _COL_REGION_ = 3;
            private const int _COL_PORTION_ = 4;
            private const int _COL_DATE_OPEN_ = 5;
            private const int _COL_DATE_CLOSE_ = 6;
            private const int _COL_REPORT_NUMBER_ = 7;
            private const int _COL_REPORT_DATE_ = 8;
            private const int _COL_DECLARANT_ = 9;
            private const int _COL_INN_ = 10;
            private const int _COL_CONTRACT_NUMBER_ = 11;
            private const int _COL_CONTRACT_DATE_ = 12;
            //
            #endregion//__FIELDS__

    }//public class listview_portions_history : ListView

}//namespace cfmc.quotas.controls

