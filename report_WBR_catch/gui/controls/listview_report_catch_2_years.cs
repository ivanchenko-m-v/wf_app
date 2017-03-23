//=============================================================================
// REPORT_WBR_CATCH
// listview_report_catch_2_years - список результирующих строк запроса выборки 
//                                 данных отчёта о вылове ВБР за 2 года
// Автор: Иванченко М.В.
// Дата начала разработки:  20-02-2017
// Дата обновления:         21-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;
using System.Drawing;
using System.Windows.Forms;

using cfmc.quotas.resources;
using cfmc.utils;
using cfmc.quotas.db_objects;

namespace cfmc.quotas.controls
{
    public class listview_report_catch_2_years : ListView
    {
        public event EventHandler<PercentChangedEventArgs> RefreshPercentChanged = null;

        private delegate void notify_func( PercentChangedEventArgs ea );
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
            this.FullRowSelect = true;
            this.MultiSelect = false;

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
            this.init_column(rc_report_catch.column_declarant, this._COL_WIDTH_[0]);
            //inn
            this.init_column(rc_report_catch.column_inn, this._COL_WIDTH_[1]);
            //WBR
            this.init_column(rc_report_catch.column_fish, this._COL_WIDTH_[2]);
            //region
            this.init_column(rc_report_catch.column_region, this._COL_WIDTH_[3]);
            //subject
            this.init_column(rc_report_catch.column_subject, this._COL_WIDTH_[4]);
            //portion
            this.init_column(rc_report_catch.column_portion, this._COL_WIDTH_[5]);
            //limit 1
            this.init_column(rc_report_catch.column_limit, this._COL_WIDTH_[6]);
            //catch 1
            this.init_column(rc_report_catch.column_catch, this._COL_WIDTH_[7]);
            //percent 1
            this.init_column(rc_report_catch.column_percent, this._COL_WIDTH_[8]);
            //limit 2
            this.init_column(rc_report_catch.column_limit, this._COL_WIDTH_[9]);
            //catch 2
            this.init_column(rc_report_catch.column_catch, this._COL_WIDTH_[10]);
            //percent 2
            this.init_column(rc_report_catch.column_percent, this._COL_WIDTH_[11]);
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
        /// <summary>
        /// refresh_data( ) - заполнение данных выборки
        /// </summary>
        public void refresh_data( )
        {
            this.SuspendLayout( );

            this.Items.Clear( );
            this.Groups.Clear( );
            this.Sorting = SortOrder.None;
            this.ListViewItemSorter = null;

            //определяем цвета для чередования выбранных долей в списке
            Color color_base = this.BackColor;
            Color color_alt = System.Drawing.Color.LightSteelBlue;
            //.Azure//.LightGray;//.LightSlateGray;////.LightSeaGreen;//.Beige;//.LemonChiffon;
            int id_declarant_prev = -1;
            Color item_color = color_alt;
            //счётчик обработанных записей
            int processed_rows = 0;
            //вставляем выбранные данные в список
            foreach( data_report_WBR_catch itm in data_model_store.report_catch_data )
            {
                if( id_declarant_prev != itm.id_declarant )
                {
                    id_declarant_prev = itm.id_declarant;
                    item_color = item_color == color_alt ? color_base : color_alt;
                }
                //добавляем данные в список
                this.append_item( itm, item_color );

                //нотификация подписчиков о вставке порции данных
                this.notify_refresh_percent_changed( ++processed_rows, data_model_store.report_catch_data.Count );
            }
            //last notification
            this.notify_refresh_percent_changed( data_model_store.report_catch_data.Count, data_model_store.report_catch_data.Count );
            //resize some cols to content
            //this.resize_columns( );

            this.ResumeLayout( false );
        }
        private void append_item( data_report_WBR_catch data, Color item_color )
        {
            string[] sub_items = new string[this.Columns.Count];
            sub_items[0] = data.declarant;
            sub_items[1] = data.inn;
            sub_items[2] = data.WBR;
            sub_items[3] = data.region;
            sub_items[4] = data.subject;
            sub_items[5] = data.portion != 0 ? data.portion.ToString( ) : "";
            sub_items[6] = data.limits_1.ToString( );
            sub_items[7] = data.catch_stat_1 != 0 ? data.catch_stat_1.ToString( ) : "";
            sub_items[8] = data.percent_1 != 0 ? data.percent_1.ToString( ) : "";
            sub_items[9] = data.limits_2.ToString( );
            sub_items[10] = data.catch_stat_2 != 0 ? data.catch_stat_2.ToString( ) : "";
            sub_items[11] = data.percent_2 != 0 ? data.percent_2.ToString( ) : "";

            ListViewItem item = new ListViewItem( sub_items );
            item.Tag = data;
            item.BackColor = item_color;
            this.Items.Add( item );
        }
        /// <summary>
        /// notify_percent_changed( int processed_rows, int rows, notify_func notify ) -
        /// нотификация подписчиков, для обновления представления хода процесса обработки,
        /// об очередной порции обработанных данных
        /// </summary>
        /// <param name="processed_rows">количество обработанных записей</param>
        /// <param name="rows">общее количество записей для обработки</param>
        /// <param name="notify">функция, вызывающая обработчики нотификации</param>
        private void notify_percent_changed( int processed_rows, int rows, notify_func notify )
        {
            if( processed_rows < 1 )
            {
                return;
            }
            //event args for notification about export process
            PercentChangedEventArgs ea = new PercentChangedEventArgs( );
            ea.Percent = 0;
            if( rows < 100 )
            {
                ea.Percent = 100 - ( 100 / processed_rows );
                notify( ea );
                return;
            }
            int itm_on_percent = rows / 100;

            if( ( processed_rows % itm_on_percent ) == 0 )
            {
                //нотификация подписчиков о вставке очередной порции данных
                //равной одному проценту от общего объёма
                ea.Percent = processed_rows / itm_on_percent;
                notify( ea );
            }
        }
        /// <summary>
        /// notify_refresh_percent_changed( int processed_rows, int rows )
        /// </summary>
        /// <param name="processed_rows">количество обработанных записей</param>
        /// <param name="rows">общее количество записей для обработки</param>
        private void notify_refresh_percent_changed( int processed_rows, int rows )
        {
            this.notify_percent_changed( processed_rows, rows, on_refresh_percent_changed );
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
        /// <param name="ea">процент выполненной работы по вставке записей</param>
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

    }//public class listview_report_catch_2_years : ListView

}//namespace cfmc.quotas.controls
