
//=============================================================================
// excel_helper - вспомогательный класс для вывода данных в Excel
// Автор: Иванченко М.В.
// Дата начала разработки:  15-03-2017
// Дата обновления:         16-03-2017
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
    ///  public class excel_helper
    /// </summary>
    public class excel_helper
    {
        public static EventHandler<EventArgs> ExportStart = null;
        public static EventHandler<EventArgs> ExportFinish = null;
        public static EventHandler<PercentChangedEventArgs> ExportPercentChanged = null;
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public excel_helper( )
        {
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
        /// export_to_excel( List<IDataRow> list ) -
        /// экспорт списка объектов в Excel
        /// </summary>
        /// <param name="list">список объектов, реализующих IDataRow</param>
        public static void export_to_excel( List<IDataRow> list )
        {
            excel_helper.on_export_start( );

            Excel.Application excelapp = new Excel.Application( );
            excelapp.Visible = false;
            excelapp.SheetsInNewWorkbook = 1;
            Excel.Workbook wb = excelapp.Workbooks.Add( );
            Excel.Worksheet ws;
            if( wb.ActiveSheet != null )
            {
                ws = wb.ActiveSheet as Excel.Worksheet;
            }
            else
            {
                ws = wb.Sheets.Add( ) as Excel.Worksheet;
            }

            //in Excel worksheet cells starts from [1,1]
            int row_current = 1, count = 0;
            //export data
            foreach( IDataRow row in list )
            {
                excel_helper.object_to_worksheet( row_current++, row, ws );

                excel_helper.notify_percent_changed( ++count, list.Count );
            }
            excelapp.Visible = true;

            excel_helper.on_export_finish( );
        }
        /// <summary>
        /// object_to_worksheet( int n_row, IDataRow row, Excel.Worksheet ws ) - 
        /// размещение объекта IDataRow на листе
        /// </summary>
        /// <param name="n_row">номер строки для листа Excel</param>
        /// <param name="row">объект IDataRow</param>
        /// <param name="ws">лист Excel</param>
        private static void object_to_worksheet( int n_row, IDataRow row, Excel.Worksheet ws )
        {
            Excel.Range excelcells;
            object[] obj_row = row.Fields( );
            for( int i = 0; i < obj_row.Length; ++i )
            {
                //выбор ячейки рабочего листа [n_row, i+1]
                excelcells = (Excel.Range)ws.Cells[n_row, i+1];
                //помещение данных в ячейку
                excelcells.Value2 = obj_row[i].ToString( );
            }
        }
        /// <summary>
        /// notify_percent_changed( int processed_rows, int rows )
        /// </summary>
        /// <param name="processed_rows">qty of processed rows</param>
        /// <param name="rows">total rows qty for processing</param>
        private static void notify_percent_changed( int processed_rows, int rows )
        {
            if( processed_rows < 1 )
            {
                return;
            }
            //event args for notification about export process
            PercentChangedEventArgs ea = new PercentChangedEventArgs( );
            ea.Percent = 0;
            if(rows < 100)
            {
                ea.Percent = 100 - ( 100 / processed_rows );
                excel_helper.on_export_percent_changed( ea );
                return;
            }
            int itm_on_percent = rows / 100;

            if( ( processed_rows % itm_on_percent ) == 0 )
            {
                //нотификация подписчиков о вставке порции данных
                //равной одному проценту от общего объёма
                ea.Percent = processed_rows / itm_on_percent;
                excel_helper.on_export_percent_changed( ea );
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
        private static void on_export_start( )
        {
            if( excel_helper.ExportStart != null )
            {
                excel_helper.ExportStart( null, new EventArgs( ) );
            }
        }
        /// <summary>
        /// on_export_finish( ) - 
        /// notify subscribers about event ExportFinish
        /// </summary>
        private static void on_export_finish( )
        {
            if( excel_helper.ExportFinish != null )
            {
                excel_helper.ExportFinish( null, new EventArgs( ) );
            }
        }
        /// <summary>
        /// on_export_percent_changed( PercentChangedEventArgs ea ) - 
        /// notify subscribers about event ExportPercentChanged
        /// </summary>
        /// <param name="ea">percent of export completion</param>
        private static void on_export_percent_changed( PercentChangedEventArgs ea )
        {
            if( excel_helper.ExportPercentChanged != null )
            {
                excel_helper.ExportPercentChanged( null, ea );
            }
        }
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        #endregion//__FIELDS__

    }//class excel_helper

    /// <summary>
    /// interface IDataRow
    /// </summary>
    public interface IDataRow
    {
        object[] Fields( );
    }

}//namespace cfmc.utils

            