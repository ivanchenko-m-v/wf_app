
//=============================================================================
// excel_producer - класс для вывода форматированных данных на лист Excel
// Автор: Иванченко М.В.
// Дата начала разработки:  16-03-2017
// Дата обновления:         17-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

using Excel = Microsoft.Office.Interop.Excel;

namespace cfmc.utils
{
    /// <summary>
    /// public class excel_producer
    /// </summary>
    public class excel_producer
    {
        public EventHandler<EventArgs> ExportStart = null;
        public EventHandler<EventArgs> ExportFinish = null;
        public EventHandler<PercentChangedEventArgs> ExportPercentChanged = null;
        /*
          * --------------------------------------------------------------------
          *                          CONSTRUCTION
          * --------------------------------------------------------------------
          */
        #region __CONSTRUCTION__	
        public excel_producer( )
        {
            this.initialize( );
        }
        #endregion //__CONSTRUCTION__	

        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// header - 
        /// шапка заголовка столбцов
        /// </summary>
        public string[] header { get; set; }
        /// <summary>
        /// header_formats - 
        /// массив форматов ячеек заголовка таблицы выводимых данных
        /// </summary>
        public string[] header_formats { get; set; }
        /// <summary>
        /// data -
        /// данные для размещения на листе Excel
        /// </summary>
        public List<IDataRow> data { get; set; }
        /// <summary>
        /// data_formats -
        /// массив форматов ячеек таблицы выводимых данных
        /// </summary>
        public string[] data_formats { get; set; }
        /// <summary>
        /// массив, задающий ширину каждого выводимого столбца данных
        /// </summary>
        public int[] column_widths { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize( )
        {
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        /// <summary>
        /// export_excel_book( ) - 
        /// fill cells with data excel workbook
        /// </summary>
        public void export_excel_book( )
        {
            if( this.data == null || this.data.Count == 0 )
            {
                throw new Exception( resources.rc_utils.excel_export_not_data );
            }
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            try
            {
                //notify about export started
                this.on_export_start( );
                //init excel application object
                this.excel_init( );

                //create workbook
                wb = this.create_excel_workbook( );
                if( wb == null )
                {
                    return;
                }
                ws = this.create_excel_worksheet( wb );
                if( ws == null )
                {
                    return;
                }
                //place header
                this.place_data_header( ws );
                //export process
                this.place_data( ws );
                //auto fits columns widths
                ws.Columns.AutoFit( );

                //notify about export finished
                this.on_export_finish( );
                //show excel application with exported data
                this.excel_show( );
            }
            catch( Exception ex )
            {
                this.releaseObject( ws );
                this.releaseObject( wb );

                this.excel_close( );

                throw ex;
            }
        }
        /// <summary>
        /// place_data_header( ) - 
        /// размещает заголовок столбцов на листе Excel
        /// </summary>
        /// <param name="ws">лист Excel</param>
        private void place_data_header( Excel.Worksheet ws )
        {
            if( this.header == null )
            {
                return;
            }
            //in Excel worksheet cells starts from [1,1]
            this.object_to_worksheet( _ROW_HEADER_START_, this.header, ws );
        }
        /// <summary>
        /// place_data( ) - 
        /// размещение данных на листе Excel
        /// </summary>
        /// <param name="ws">лист Excel</param>
        private void place_data( Excel.Worksheet ws )
        {
            //in Excel worksheet cells starts from [1,1]
            int row_current = _ROW_DATA_START_, count = 0;
            //export data
            foreach( IDataRow data_row in this.data )
            {
                this.object_to_worksheet( row_current++, data_row.Fields( ), ws );

                this.notify_percent_changed( ++count, this.data.Count );
            }
        }
        /// <summary>
        /// object_to_worksheet( int n_row, IDataRow row, Excel.Worksheet ws ) - 
        /// размещение объекта IDataRow на строке листа
        /// </summary>
        /// <param name="n_row">номер строки для листа Excel</param>
        /// <param name="row">объект IDataRow</param>
        /// <param name="ws">лист Excel</param>
        private void object_to_worksheet( int n_row, object[] obj_row, Excel.Worksheet ws )
        {
            Excel.Range excelcells;

            for( int i = 0; i < obj_row.Length; ++i )
            {
                //выбор ячейки рабочего листа [n_row, i+1]
                excelcells = (Excel.Range)ws.Cells[n_row, i + 1];
                //помещение данных в ячейку
                excelcells.Value2 = obj_row[i].ToString( );
            }
        }
        /// <summary>
        /// excel_init( ) - 
        /// инициализация объекта приложения Excel
        /// </summary>
        private void excel_init( )
        {
            if( this._excelapp != null )
            {
                return;
            }
            this._excelapp = new Excel.Application( );
            this._excelapp.Visible = false;
            this._excelapp.SheetsInNewWorkbook = 1;
        }
        /// <summary>
        /// excel_show( ) -
        /// активация окна приложения Excel
        /// </summary>
        private void excel_show( )
        {
            //show Excel with exported data
            if( this._excelapp != null )
            {
                this._excelapp.Visible = true;
            }
        }
        /// <summary>
        /// excel_close( ) - 
        /// закрытие приложения Excel
        /// </summary>
        public void excel_close( )
        {
            //quit Excel app
            if( this._excelapp != null )
            {
                this._excelapp.DisplayAlerts = false;
                this._excelapp.Quit( );
            }
            this.releaseObject( this._excelapp );
            this._excelapp = null;
        }
        /// <summary>
        /// create_excel_workbook( ) - 
        /// создание новой книги Excel
        /// </summary>
        /// <returns>новая книга Excel</returns>
        private Excel.Workbook create_excel_workbook( )
        {
            return this._excelapp.Workbooks.Add( );
        }
        /// <summary>
        /// create_excel_worksheet( Excel.Workbook wb ) -
        /// создание листа Excel для вывода данных
        /// </summary>
        /// <param name="wb">книга Excel, в которой создаётся лист</param>
        /// <returns>лист книги Excel</returns>
        private Excel.Worksheet create_excel_worksheet( Excel.Workbook wb )
        {
            Excel.Worksheet ws;
            if( wb.ActiveSheet != null )
            {
                ws = wb.ActiveSheet as Excel.Worksheet;
            }
            else
            {
                ws = wb.Sheets.Add( ) as Excel.Worksheet;
            }
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //this.init_columns_widths( ws );
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            return ws;
        }
        /// <summary>
        /// init_columns_widths( Excel.Worksheet ws ) - 
        /// установка значений ширины столбцов на листе Excel
        /// </summary>
        /// <param name="ws">лист Excel</param>
        private void init_columns_widths( Excel.Worksheet ws )
        {
            if( ws == null || this.column_widths == null )
            {
                return;
            }
            //не работает со ссылками R1C1
            string[] s = new string[]
            {
                "A","B","C","D","E","F","G","H","I","J",
                "K","L","M","N","O","P","Q","R","S","T",
                "U","V","W","X","Y","Z","AA","AB","AC","AD"
            };
            for( int i = 0; i < column_widths.Length; ++i )
            {
                Excel.Range range = ws.Range[s[i] + ( i + 1 ).ToString( ), Type.Missing];
                range.EntireColumn.ColumnWidth = column_widths[i];
            }
        }
        /// <summary>
        /// save_excel_workbook( Excel.Workbook wb, string s_file_path ) -
        /// сохранить книгу Excel в файл
        /// </summary>
        /// <param name="wb">книга Excel</param>
        /// <param name="s_file_path">путь к файлу</param>
        public void save_excel_workbook( Excel.Workbook wb, string s_file_path )
        {
            wb.Saved = true;
            this._excelapp.DisplayAlerts = false;
            this._excelapp.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault;
            wb.SaveAs(
                      s_file_path,  //object Filename
                      this._excelapp.DefaultSaveFormat,   //object FileFormat
                      Type.Missing,                       //object Password 
                      Type.Missing,                       //object WriteResPassword  
                      Type.Missing,                       //object ReadOnlyRecommended
                      Type.Missing,                       //object CreateBackup
                      Excel.XlSaveAsAccessMode.xlNoChange,//XlSaveAsAccessMode AccessMode
                      Type.Missing,                       //object ConflictResolution
                      Type.Missing,                       //object AddToMru 
                      Type.Missing,                       //object TextCodepage
                      Type.Missing,                       //object TextVisualLayout
                      Type.Missing                        //object Local
                     );
        }
        /// <summary>
        /// notify_percent_changed( int processed_rows, int rows )
        /// </summary>
        /// <param name="processed_rows">qty of processed rows</param>
        /// <param name="rows">total rows qty for processing</param>
        private void notify_percent_changed( int processed_rows, int rows )
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
                this.on_export_percent_changed( ea );
                return;
            }
            int itm_on_percent = rows / 100;

            if( ( processed_rows % itm_on_percent ) == 0 )
            {
                //нотификация подписчиков о вставке порции данных
                //равной одному проценту от общего объёма
                ea.Percent = processed_rows / itm_on_percent;
                this.on_export_percent_changed( ea );
            }
        }
        /// <summary>
        /// releaseObject( object obj )
        /// </summary>
        /// <param name="obj">объект COM для уничтожения</param>
        private void releaseObject( object obj )
        {
            if( obj==null)
            {
                return;
            }
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject( obj );
                obj = null;
            }
            catch( Exception ex )
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect( );
            }
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        /// <summary>
        /// on_export_start( ) - 
        /// notify subscribers about event ExportStart
        /// </summary>
        private void on_export_start( )
        {
            if( this.ExportStart != null )
            {
                this.ExportStart( null, new EventArgs( ) );
            }
        }
        /// <summary>
        /// on_export_finish( ) - 
        /// notify subscribers about event ExportFinish
        /// </summary>
        private void on_export_finish( )
        {
            if( this.ExportFinish != null )
            {
                this.ExportFinish( null, new EventArgs( ) );
            }
        }
        /// <summary>
        /// on_export_percent_changed( PercentChangedEventArgs ea ) - 
        /// notify subscribers about event ExportPercentChanged
        /// </summary>
        /// <param name="ea">percent of export completion</param>
        private void on_export_percent_changed( PercentChangedEventArgs ea )
        {
            if( this.ExportPercentChanged != null )
            {
                this.ExportPercentChanged( null, ea );
            }
        }
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        Excel.Application _excelapp = null;

        const int _ROW_DATA_START_ = 2;
        const int _ROW_HEADER_START_ = 1;
        #endregion//__FIELDS__

        #region save_example
        /*
          excelappworkbook = excelappworkbooks["Book2"];
          excelappworkbook.SaveAs(@"C:\a.xls",
          Excel.XlFileFormat.xlExcel9795,
          "WWWWW",                                //Пароль для доступа на запись 
          "WWWWW",                                //Пароль для открытия документа
          Type.Missing, Type.Missing,
          Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing,
          Type.Missing, Type.Missing, Type.Missing, Type.Missing);
          excelapp.Quit();         
         */
        #endregion// save_example
    }//class excel_producer

    class excel_cell_format
    {
        string number_format { get; set; }
        System.Windows.Forms.HorizontalAlignment alignment { get; set; }
        int column_span { get; set; }
    }//class excel_cell_format

}//namespace cfmc.utils

            