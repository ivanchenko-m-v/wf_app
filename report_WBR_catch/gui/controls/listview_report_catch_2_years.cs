//=============================================================================
// REPORT_WBR_CATCH
// listview_report_catch_2_years - список результирующих строк запроса выборки 
//                                 данных отчёта о вылове ВБР за 2 года
// Автор: Иванченко М.В.
// Дата начала разработки:  20-02-2017
// Дата обновления:         24-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;
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

        public listview_report_catch_2_years( )
        {
            this.create_control_elements( );

            this.init_control( );
        }
        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
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
        private void create_control_elements( )
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

            this.SuspendLayout( );
            //
            //_layout
            //
            this.init_columns( );
            //--
            this.ResumeLayout( false );
            //subscribe event
            this.SizeChanged += listview_report_catch_2_years_SizeChanged;
        }
        /// <summary>
        /// init_columns( )
        /// </summary>
        private void init_columns( )
        {
            //declarant
            this.init_column( rc_report_catch.column_declarant, this._COL_WIDTH_[_COL_DECLARANT_] );
            //inn
            this.init_column( rc_report_catch.column_inn, this._COL_WIDTH_[_COL_INN_] );
            //WBR
            this.init_column( rc_report_catch.column_fish, this._COL_WIDTH_[_COL_FISH_] );
            //region
            this.init_column( rc_report_catch.column_region, this._COL_WIDTH_[_COL_REGION_] );
            //subject
            this.init_column( rc_report_catch.column_subject, this._COL_WIDTH_[_COL_SUBJECT_] );
            //portion
            this.init_column( rc_report_catch.column_portion, this._COL_WIDTH_[_COL_PORTION_], HorizontalAlignment.Right );
            //limit 1
            this.init_column( rc_report_catch.column_limit, this._COL_WIDTH_[_COL_LIMIT_1_], HorizontalAlignment.Right );
            //catch 1
            this.init_column( rc_report_catch.column_catch, this._COL_WIDTH_[_COL_CATCH_1_], HorizontalAlignment.Right );
            //percent 1
            this.init_column( rc_report_catch.column_percent, this._COL_WIDTH_[_COL_PERCENT_1_], HorizontalAlignment.Right );
            //limit 2
            this.init_column( rc_report_catch.column_limit, this._COL_WIDTH_[_COL_LIMIT_2_], HorizontalAlignment.Right );
            //catch 2
            this.init_column( rc_report_catch.column_catch, this._COL_WIDTH_[_COL_CATCH_2_], HorizontalAlignment.Right );
            //percent 2
            this.init_column( rc_report_catch.column_percent, this._COL_WIDTH_[_COL_PERCENT_2_], HorizontalAlignment.Right );
        }
        /// <summary>
        /// init_column( 
        ///             String text,
        ///             int width = -1,
        ///             HorizontalAlignment align = HorizontalAlignment.Left
        ///            )
        /// </summary>
        /// <param name="text">заголовок столбца</param>
        /// <param name="width">ширина столбца</param>
        /// <param name="align">выравнивание</param>
        private void init_column(
                                    String text,
                                    int width = -1,
                                    HorizontalAlignment align = HorizontalAlignment.Left
                                )
        {
            ColumnHeader column = new ColumnHeader( );
            column.Text = text;
            if( width > 0 )
            {
                column.Width = width;
            }
            column.TextAlign = align;
            this.Columns.Add( column );
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
            //очистка списка
            this.clear( );

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
            this.resize_columns( );

            this.ResumeLayout( false );
        }
        /// <summary>
        /// clear( )
        /// - очистка списка
        /// </summary>
        private void clear( )
        {
            this.Items.Clear( );
            this.Groups.Clear( );
            this._groups_regime.Clear( );
            this.Sorting = SortOrder.None;
            this.ListViewItemSorter = null;
        }
        /// <summary>
        /// append_item( data_report_WBR_catch data, Color item_color )
        /// добавление записи данных отчёта в список
        /// </summary>
        /// <param name="data">запись данных отчёта</param>
        /// <param name="item_color">цвет</param>
        private void append_item( data_report_WBR_catch data, Color item_color )
        {
            string[] sub_items = new string[this.Columns.Count];
            sub_items[_COL_DECLARANT_] = data.declarant;
            sub_items[_COL_INN_] = data.inn;
            sub_items[_COL_FISH_] = data.WBR;
            sub_items[_COL_REGION_] = data.region;
            sub_items[_COL_SUBJECT_] = data.subject;
            sub_items[_COL_PORTION_] = data.portion != 0 ? data.portion.ToString( "N3" ) : "";
            sub_items[_COL_LIMIT_1_] = data.limits_1.ToString( "N3" );
            sub_items[_COL_CATCH_1_] = data.catch_stat_1 != 0 ? data.catch_stat_1.ToString( "N3" ) : "";
            sub_items[_COL_PERCENT_1_] = data.percent_1 != 0 ? data.percent_1.ToString( "N6" ) : "";
            sub_items[_COL_LIMIT_2_] = data.limits_2.ToString( "N3" );
            sub_items[_COL_CATCH_2_] = data.catch_stat_2 != 0 ? data.catch_stat_2.ToString( "N3" ) : "";
            sub_items[_COL_PERCENT_2_] = data.percent_2 != 0 ? data.percent_2.ToString( "N6" ) : "";

            ListViewItem item = new ListViewItem( sub_items );
            item.Tag = data;
            item.BackColor = item_color;
            this.Items.Add( item );

            // включение элемента списка в группу
            this.item_group( item );
        }
        /// <summary>
        /// item_group( ListViewItem item )
        /// - включение элемента списка в группу
        /// </summary>
        /// <param name="item">элемент списка</param>
        private void item_group( ListViewItem item )
        {
            data_report_WBR_catch data = item.Tag as data_report_WBR_catch;
            if( data == null )
            {
                return;
            }
            //regime group
            if( !this._groups_regime.ContainsKey( data.id_regime ) )
            {
                ListViewGroup item_group = new ListViewGroup(
                                                             data.regime,
                                                             HorizontalAlignment.Center
                                                            );
                this._groups_regime.Add( data.id_regime, item_group );
                this.Groups.Add( item_group );
            }
            item.Group = this._groups_regime[data.id_regime];
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
        /// <summary>
        /// resize_columns( )
        /// </summary>
        private void resize_columns( )
        {
            this.Visible = false;

            this.resize_data_columns( );
            this.resize_text_columns( );

            this.Visible = true;
        }
        /// <summary>
        /// resize_data_columns( )
        /// </summary>
        private void resize_data_columns( )
        {
            this.AutoResizeColumn( _COL_PORTION_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_LIMIT_1_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_CATCH_1_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_PERCENT_1_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_LIMIT_2_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_CATCH_2_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_PERCENT_2_, ColumnHeaderAutoResizeStyle.ColumnContent );
        }
        /// <summary>
        /// resize_text_columns( )
        /// </summary>
        private void resize_text_columns( )
        {
            int width_data_cols = this.Columns[_COL_PORTION_].Width +
                                  this.Columns[_COL_LIMIT_1_].Width +
                                  this.Columns[_COL_CATCH_1_].Width +
                                  this.Columns[_COL_PERCENT_1_].Width +
                                  this.Columns[_COL_LIMIT_2_].Width +
                                  this.Columns[_COL_CATCH_2_].Width +
                                  this.Columns[_COL_PERCENT_2_].Width;
            int width_text_cols = this.Columns[_COL_DECLARANT_].Width +
                                  this.Columns[_COL_INN_].Width +
                                  this.Columns[_COL_FISH_].Width +
                                  this.Columns[_COL_REGION_].Width +
                                  this.Columns[_COL_SUBJECT_].Width;
            //вычисляем разницу
            int diff = this.DisplayRectangle.Width - width_data_cols - width_text_cols;
            //изменяем ширину 5 столбцов пропорционально
            this.Columns[_COL_INN_].Width += diff / 5;
            this.Columns[_COL_FISH_].Width += diff / 5;
            this.Columns[_COL_REGION_].Width += diff / 5;
            this.Columns[_COL_SUBJECT_].Width += diff / 5;
            this.Columns[_COL_DECLARANT_].Width += ( diff / 5 ) + ( diff % 5 );
        }
        /// <summary>
        /// change_cols_name( int year1, int year2 )
        /// --изменяет имена столбцов данных в соответствии с параметрами выборки
        /// </summary>
        /// <param name="year1">год выборки 1</param>
        /// <param name="year2">год выборки 2</param>
        public void change_cols_name( int year1, int year2 )
        {
            this.Columns[_COL_PERCENT_1_].Text = rc_report_catch.column_percent + ", "
                                                 + year1.ToString( );
            this.Columns[_COL_PERCENT_2_].Text = rc_report_catch.column_percent + ", "
                                                 + year2.ToString( );
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
        /// <summary>
        /// listview_report_catch_2_years_SizeChanged( object sender, EventArgs e )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listview_report_catch_2_years_SizeChanged( object sender, EventArgs e )
        {
            this.SuspendLayout( );

            this.resize_columns( );

            this.ResumeLayout( false );
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
        SortedDictionary<int, ListViewGroup> _groups_regime = new SortedDictionary<int, ListViewGroup>( );

        #endregion//__FIELDS__

    }//public class listview_report_catch_2_years : ListView

}//namespace cfmc.quotas.controls
