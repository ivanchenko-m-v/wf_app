//=============================================================================
// listview_portions_history - список результирующих строк запроса выборки 
//                             истории закрепления долей за пользователями ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  09-03-2017
// Дата обновления:         14-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Windows.Forms;
using System.Collections.Generic;

using cfmc.quotas.resources;
using cfmc.quotas;
using cfmc.quotas.db_objects;
using cfmc.utils;

namespace cfmc.quotas.controls
{
    using n_field = data_report_portion_history.field_report_portion_history;

    public class listview_portions_history : ListView
    {
        public event EventHandler<PercentChangedEventArgs> RefreshPercentChanged = null;
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
        /// <summary>
        /// refresh_data( ) - заполнение данных выборки
        /// </summary>
        public void refresh_data( )
        {
            this.SuspendLayout( );

            this.Items.Clear( );

            PercentChangedEventArgs ea = new PercentChangedEventArgs( );
            ea.Percent = 0;
            int count = 0, itm_on_percent = data_model_store.portions.Count / 100;
            if( itm_on_percent == 0 )
            {
                itm_on_percent = 1;
            }
            foreach( data_report_portion_history itm in data_model_store.portions )
            {
                //добавляем данные в список
                this.append_item( itm );

                ++count;
                if( ( count % itm_on_percent ) == 0 )
                {
                    //нотификация подписчиков о вставке порции данных
                    ea.Percent = count / itm_on_percent;
                    this.on_refresh_percent_changed( ea );
                }
            }
            ea.Percent = 100;
            //last notification
            this.on_refresh_percent_changed( ea );

            this.ResumeLayout( false );

            this.Update( );
        }

        private void append_item( data_report_portion_history itm )
        {
            //id_portion не выводится в список результатов,
            //поэтому: (количество полей - 1)
            //         (порядковый номер поля - 1)
            string[] sub_items = new string[itm.record_fields_count-1];
            sub_items[( int)n_field.basin - 1] = itm.basin;
            sub_items[(int)n_field.regime - 1] = itm.regime;
            sub_items[(int)n_field.WBR - 1] = itm.WBR;
            sub_items[(int)n_field.region - 1] = itm.region;
            sub_items[(int)n_field.portion - 1] = itm.portion.ToString( );
            sub_items[(int)n_field.date_open - 1] = itm.date_open;
            sub_items[(int)n_field.date_close - 1] = itm.date_close;
            sub_items[(int)n_field.report_number - 1] = itm.report_number;
            sub_items[(int)n_field.report_date - 1] = itm.report_date;
            sub_items[(int)n_field.declarant - 1] = itm.declarant;
            sub_items[(int)n_field.INN - 1] = itm.INN;
            sub_items[(int)n_field.contract_number - 1] = itm.contract_number;
            sub_items[(int)n_field.contract_date - 1] = itm.contract_date;

            ListViewItem item = new ListViewItem( sub_items );
            item.Tag = itm;
            this.Items.Add( item );
        }
        #endregion//__FUNCTIONS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        /// <summary>
        /// on_refresh_percent_changed( int percent ) - 
        /// нотификация подписчиков об изменении количества вставленных 
        /// в список записей
        /// </summary>
        /// <param name="percent"></param>
        protected void on_refresh_percent_changed( PercentChangedEventArgs ea )
        {
            if( this.RefreshPercentChanged != null )
            {
                this.RefreshPercentChanged( this, ea );
            }
        }
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

