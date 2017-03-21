
//=============================================================================
// utils - вспомогательные классы для работы программы
// Автор: Иванченко М.В.
// Дата начала разработки:  14-03-2017
// Дата обновления:         21-03-2017
// Первый релиз:            1.0.0.0
// Текущий релиз:           1.0.0.0
//=============================================================================
using System;
using System.Globalization;

namespace cfmc.utils
{
    /// <summary>
    /// public class PercentChangedEventArgs : EventArgs
    /// </summary>
    public class PercentChangedEventArgs : EventArgs
    {
        public int Percent { get; set; }

    }//public class PercentChangedEventArgs : EventArgs

    /// <summary>
    /// public static class helper
    /// </summary>
    public static class helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime date_from_string( string s )
        {
            return DateTime.ParseExact( s, "yyyy.MM.dd", CultureInfo.InvariantCulture );
        }
        /// <summary>
        /// cvt_field_int( object[] data_row, int num_field )
        /// преобразование элемента массива object[] из типа object в int 
        /// </summary>
        /// <param name="data_row">массив значений</param>
        /// <param name="num_field">номер элемента массива</param>
        /// <returns>значение типа int</returns>
        public static int cvt_field_int( object[] data_row, int num_field )
        {
            int retval = 0;
            if(
                ( data_row.Length > num_field ) &&
                ( data_row[num_field] != null )
              )
            {
                try
                {
                    retval = Convert.ToInt32( data_row[num_field] );
                }
                catch
                {
                }
            }
            return retval;
        }
        /// <summary>
        /// cvt_field_byte( object[] data_row, int num_field )
        /// преобразование элемента массива object[] из типа object в byte 
        /// </summary>
        /// <param name="data_row">массив значений</param>
        /// <param name="num_field">номер элемента массива</param>
        /// <returns>значение типа byte</returns>
        public static byte cvt_field_byte( object[] data_row, int num_field )
        {
            byte retval = 0;
            if(
                ( data_row.Length > num_field ) &&
                ( data_row[num_field] != null )
              )
            {
                try
                {
                    retval = Convert.ToByte( data_row[num_field] );
                }
                catch
                {
                }
            }
            return retval;
        }
        /// <summary>
        /// cvt_field_byte( object[] data_row, int num_field )
        /// преобразование элемента массива object[] из типа object в decimal 
        /// </summary>
        /// <param name="data_row">массив значений</param>
        /// <param name="num_field">номер элемента массива</param>
        /// <returns>значение типа decimal</returns>
        public static decimal cvt_field_decimal( object[] data_row, int num_field )
        {
            decimal retval = 0;
            if(
                ( data_row.Length > num_field ) &&
                ( data_row[num_field] != null )
              )
            {
                try
                {
                    retval = Convert.ToDecimal( data_row[num_field] );
                }
                catch
                {
                }
            }
            return retval;
        }
        /// <summary>
        /// cvt_field_string( object[] data_row, int num_field )
        /// преобразование элемента массива object[] из типа object в string 
        /// </summary>
        /// <param name="data_row">массив значений</param>
        /// <param name="num_field">номер элемента массива</param>
        /// <returns>значение типа string</returns>
        public static string cvt_field_string( object[] data_row, int num_field )
        {
            string retval = "";
            if(
                ( data_row.Length > num_field ) &&
                ( data_row[num_field] != null )
              )
            {
                try
                {
                    retval = Convert.ToString( data_row[num_field] );
                }
                catch
                {
                }
            }
            return retval;
        }
    }//public static class helper

}//namespace cfmc.utils

            