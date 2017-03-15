//=============================================================================
// listview_portions_history - список результирующих строк запроса выборки 
//                             истории закрепления долей за пользователями ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  09-03-2017
// Дата обновления:         15-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

using cfmc.quotas.resources;
using cfmc.quotas.db_objects;
using cfmc.utils;

namespace cfmc.quotas.controls
{
    using n_field = data_report_portion_history.field_report_portion_history;
    /// <summary>
    /// public class listview_portions_history : ListView
    /// </summary>
    public class listview_portions_history : ListView
    {
        public event EventHandler<PercentChangedEventArgs> RefreshPercentChanged = null;
        public event EventHandler<PercentChangedEventArgs> SortPercentChanged = null;
        public event EventHandler<EventArgs> SortStarting = null;
        public event EventHandler<EventArgs> SortFinished = null;
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__

        public listview_portions_history( )
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
            //
            //groups hashes
            //
            this.init_groups( );
            //
            //
            //
            this.init_events( );
            //--
            this.ResumeLayout( false );
        }
        /// <summary>
        /// init_columns( )
        /// </summary>
        private void init_columns( )
        {
            //basin
            this.init_column( resource_portions_history.column_basin, this._COL_WIDTH_[0] );
            //regime
            this.init_column( resource_portions_history.column_regime, this._COL_WIDTH_[1] );
            //fish(WBR)
            this.init_column( resource_portions_history.column_WBR, this._COL_WIDTH_[2] );
            //region
            this.init_column( resource_portions_history.column_region, this._COL_WIDTH_[3] );
            //portion
            this.init_column( resource_portions_history.column_portion, this._COL_WIDTH_[5] );
            //date open
            this.init_column( resource_portions_history.column_date_open, this._COL_WIDTH_[6] );
            //date close
            this.init_column( resource_portions_history.column_date_close, this._COL_WIDTH_[7] );
            //report number
            this.init_column( resource_portions_history.column_report_number, this._COL_WIDTH_[8] );
            //report date
            this.init_column( resource_portions_history.column_report_date, this._COL_WIDTH_[9] );
            //declarant
            this.init_column( resource_portions_history.column_declarant, this._COL_WIDTH_[10] );
            //inn
            this.init_column( resource_portions_history.column_INN, this._COL_WIDTH_[11] );
            //contract number
            this.init_column( resource_portions_history.column_contract_number, this._COL_WIDTH_[8] );
            //contract date
            this.init_column( resource_portions_history.column_contract_date, this._COL_WIDTH_[9] );
        }
        /// <summary>
        /// init_column( String text, int width = -1 )
        /// </summary>
        /// <param name="text">column title</param>
        /// <param name="width">column width</param>
        private void init_column( String text, int width = -1 )
        {
            ColumnHeader column = new ColumnHeader( );
            column.Text = text;
            if( width > 0 )
            {
                column.Width = width;
            }
            this.Columns.Add( column );
        }
        /// <summary>
        /// init_groups( )
        /// </summary>
        private void init_groups( )
        {
            this._group_basin = new System.Collections.Hashtable( );
            this._group_regime = new System.Collections.Hashtable( );
            this._group_WBR = new System.Collections.Hashtable( );
            this._group_region = new System.Collections.Hashtable( );

            this._groups = new System.Collections.Hashtable[]
            {
                this._group_basin,
                this._group_regime,
                this._group_WBR,
                this._group_region
            };
        }
        /// <summary>
        /// init_events( )
        /// </summary>
        private void init_events( )
        {
            this.ColumnClick += listview_portions_history_ColumnClick;
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

            PercentChangedEventArgs ea = new PercentChangedEventArgs( );
            ea.Percent = 0;
            int count = 0, itm_on_percent = data_model_store.portions.Count / 100;
            if( itm_on_percent == 0 )
            {
                itm_on_percent = 1;
            }
            //определяем цвета для чередования выбранных долей в списке
            Color color_base = this.BackColor;
            Color color_alt = System.Drawing.Color.LightSteelBlue;
            //.Azure//.LightGray;//.LightSlateGray;////.LightSeaGreen;//.Beige;//.LemonChiffon;
            int id_portion_prev = -1;
            Color item_color = color_alt;
            //вставляем выбранные данные в список
            foreach( data_report_portion_history itm in data_model_store.portions )
            {
                if( id_portion_prev != itm.id_portion )
                {
                    id_portion_prev = itm.id_portion;
                    item_color = item_color == color_alt ? color_base : color_alt;
                }
                //добавляем данные в список
                this.append_item( itm, item_color );

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
            //resize some cols to content
            this.resize_columns( );

            this.ResumeLayout( false );
        }

        private void resize_columns( )
        {
            this.AutoResizeColumn( _COL_PORTION_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_DATE_OPEN_, ColumnHeaderAutoResizeStyle.ColumnContent );
            this.AutoResizeColumn( _COL_DATE_CLOSE_, ColumnHeaderAutoResizeStyle.ColumnContent );
        }

        private void append_item( data_report_portion_history data, Color item_color )
        {
            //id_portion не выводится в список результатов,
            //поэтому: (количество полей - 1)
            //         (порядковый номер поля - 1)
            string[] sub_items = new string[data.record_fields_count - 1];
            sub_items[(int)n_field.basin - 1] = data.basin;
            sub_items[(int)n_field.regime - 1] = data.regime;
            sub_items[(int)n_field.WBR - 1] = data.WBR;
            sub_items[(int)n_field.region - 1] = data.region;
            sub_items[(int)n_field.portion - 1] = data.portion.ToString( );
            sub_items[(int)n_field.date_open - 1] = data.date_open;
            sub_items[(int)n_field.date_close - 1] = data.date_close;
            sub_items[(int)n_field.report_number - 1] = data.report_number;
            sub_items[(int)n_field.report_date - 1] = data.report_date;
            sub_items[(int)n_field.declarant - 1] = data.declarant;
            sub_items[(int)n_field.INN - 1] = data.INN;
            sub_items[(int)n_field.contract_number - 1] = data.contract_number;
            sub_items[(int)n_field.contract_date - 1] = data.contract_date;

            ListViewItem item = new ListViewItem( sub_items );
            item.Tag = data;
            item.BackColor = item_color;
            this.Items.Add( item );

            // включение элемента списка в группу
            this.item_group( item );
        }
        /// <summary>
        /// item_group( ListViewItem item ) - 
        /// включение элемента списка в группы
        /// </summary>
        /// <param name="item">элемент списка</param>
        private void item_group( ListViewItem item )
        {
            for( int i = 0; i < 4; ++i )
            {
                //regime group
                string s_key = item.SubItems[i].Text;
                if( !this._groups[i].Contains( s_key ) )
                {
                    ListViewGroup item_group = new ListViewGroup(
                                                                 s_key,
                                                                 HorizontalAlignment.Center
                                                                );
                    this._groups[i].Add( s_key, item_group );
                }
            }
        }
        /// <summary>
        /// sort_by_column( int column )
        /// </summary>
        /// <param name="column">column for sorting</param>
        private void sort_by_column( int column )
        {
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.SuspendLayout( );

            this.Groups.Clear( );
            this.Sorting = SortOrder.Ascending;
            this.ListViewItemSorter = new listview_portions_history_item_sorter( this.Sorting );
            //нотификация о старте сортировки
            this.on_sort_starting( );

            //копия групп для сортировки
            Hashtable column_groups = this._groups[column];
            ListViewGroup[] lvgroups = new ListViewGroup[column_groups.Count];
            column_groups.Values.CopyTo( lvgroups, 0 );
            //сортировка
            Array.Sort( 
                        lvgroups, 
                        new listview_portions_history_group_sorter( this.Sorting ) 
                      );
            this.Groups.AddRange( lvgroups );

            //инициализация аргументов события нотификации
            PercentChangedEventArgs ea = new PercentChangedEventArgs( );
            ea.Percent = 0;
            int count = 0, itm_on_percent = this.Items.Count / 100;
            if( itm_on_percent == 0 )
            {
                itm_on_percent = 1;
            }
            //присвоение группы элементам списка
            foreach( ListViewItem lvi in this.Items)
            {
                lvi.Group = column_groups[lvi.SubItems[column].Text] as ListViewGroup;
                lvi.BackColor = this.BackColor;

                ++count;
                if( ( count % itm_on_percent ) == 0 )
                {
                    //нотификация подписчиков о вставке порции данных
                    ea.Percent = count / itm_on_percent;
                    this.on_sort_percent_changed( ea );
                }
            }
            ea.Percent = 100;
            //last notification
            this.on_sort_percent_changed( ea );
            this.on_sort_finished( );

            this.ResumeLayout( false );
            this.Cursor = cursor;
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
        /// on_sort_starting( ) - 
        /// нотификация подписчиков о начале сортировки списка
        /// </summary>
        protected void on_sort_starting( )
        {
            if( this.SortStarting != null )
            {
                this.SortStarting( this, new EventArgs( ) );
            }
        }
        /// <summary>
        /// on_sort_finished( )
        /// </summary>
        protected void on_sort_finished( )
        {
            if( this.SortFinished != null )
            {
                this.SortFinished( this, new EventArgs( ) );
            }
        }
        /// <summary>
        /// on_sort_percent_changed( int percent ) - 
        /// нотификация подписчиков об изменении количества вставленных 
        /// в список записей
        /// </summary>
        /// <param name="ea">процент выполненной работы по сортировке</param>
        protected void on_sort_percent_changed( PercentChangedEventArgs ea )
        {
            if( this.SortPercentChanged != null )
            {
                this.SortPercentChanged( this, ea );
            }
        }
        /// <summary>
        /// listview_portions_history_ColumnClick( object sender, ColumnClickEventArgs e )
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event params</param>
        private void listview_portions_history_ColumnClick( object sender, ColumnClickEventArgs e )
        {
            if( e.Column > _COL_REGION_ )
            {
                return;
            }
            this.sort_by_column( e.Column );
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

        System.Collections.Hashtable _group_basin = null;
        System.Collections.Hashtable _group_regime = null;
        System.Collections.Hashtable _group_WBR = null;
        System.Collections.Hashtable _group_region = null;
        System.Collections.Hashtable[] _groups = null;

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

    /// <summary>
    /// listview_portions_history_group_sorter : IComparer
    /// </summary>
    class listview_portions_history_group_sorter : IComparer
    {
        private SortOrder _sort_order;

        public listview_portions_history_group_sorter( SortOrder order )
        {
            this._sort_order = order;
        }

        public int Compare( object x, object y )
        {
            ListViewGroup lvg_x = x as ListViewGroup;
            ListViewGroup lvg_y = y as ListViewGroup;

            int result = String.Compare( lvg_x.Header, lvg_y.Header );

            return this._sort_order == SortOrder.Ascending ? result : -result;
        }

    }//class listview_portions_history_group_sorter : IComparer

    /// <summary>
    /// listview_portions_history_item_sorter : IComparer
    /// </summary>
    class listview_portions_history_item_sorter : IComparer
    {
        private SortOrder _sort_order;

        public listview_portions_history_item_sorter( SortOrder order )
        {
            this._sort_order = order;
        }

        public int Compare( object x, object y )
        {
            ListViewItem lvi_x = x as ListViewItem;
            ListViewItem lvi_y = y as ListViewItem;

            if( lvi_x.Tag == null || lvi_y.Tag == null )
            {
                return 0;
            }
            data_report_portion_history s_x = lvi_x.Tag as data_report_portion_history;
            data_report_portion_history s_y = lvi_y.Tag as data_report_portion_history;

            int result = s_x.CompareTo( s_y );

            return this._sort_order == SortOrder.Ascending ? result : -result;
        }

    }//class listview_portions_history_group_sorter : IComparer
    
}//namespace cfmc.quotas.controls

