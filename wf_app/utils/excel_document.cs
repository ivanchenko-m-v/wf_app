
//=============================================================================
// excel_document - class description
// Автор: Иванченко М.В.
// Дата начала разработки:  16-03-2017
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
    /// public class excel_document
    /// </summary>
    public class excel_document
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public excel_document( )
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
        string[] header { get; set; }
        /// <summary>
        /// header_formats - 
        /// массив форматов ячеек заголовка таблицы выводимых данных
        /// </summary>
        string[] header_formats { get; set; }
        /// <summary>
        /// data -
        /// данные для размещения на листе Excel
        /// </summary>
        List<IDataRow> data { get; set; }
        /// <summary>
        /// data_formats -
        /// массив форматов ячеек таблицы выводимых данных
        /// </summary>
        string[] data_formats { get; set; }
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
        /// save( ) - 
        /// fill cells with data and save excel workbook
        /// </summary>
        void save( )
        {
            try
            {
                /*
                excelappworkbook = excelappworkbooks[1];
                excelappworkbook.Saved = true;
                excelapp.DisplayAlerts = false;
                excelapp.DefaultSaveFormat = Excel.XlFileFormat.xlHtml;
                excelappworkbook.SaveAs( @"C:\a.html",  //object Filename
                   Excel.XlFileFormat.xlHtml,          //object FileFormat
                   Type.Missing,                       //object Password 
                   Type.Missing,                       //object WriteResPassword  
                   Type.Missing,                       //object ReadOnlyRecommended
                   Type.Missing,                       //object CreateBackup
                   Excel.XlSaveAsAccessMode.xlNoChange,//XlSaveAsAccessMode AccessMode
                   Type.Missing,                       //object ConflictResolution
                   Type.Missing,                       //object AddToMru 
                   Type.Missing,                       //object TextCodepage
                   Type.Missing,                       //object TextVisualLayout
                   Type.Missing );                      //object Local
                excelappworkbook = excelappworkbooks["Book2"];
                excelappworkbook.SaveAs( @"C:\a.xls",
                Excel.XlFileFormat.xlExcel9795,
                "WWWWW",                                //Пароль для доступа на запись 
                "WWWWW",                                //Пароль для открытия документа
                Type.Missing, Type.Missing,
                Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing );
                excelapp.Quit( );
                */
            }
            catch( Exception ex )
            {
                //Обработка сбоя
                //excelapp.Quit( );
            }
        }
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        #endregion//__FIELDS__

    }//class excel_document

    class excel_cell_format
    {
        string number_format { get; set; }
        System.Windows.Forms.HorizontalAlignment alignment { get; set; }
        int column_span { get; set; }
    }//class excel_cell_format

}//namespace cfmc.utils

            