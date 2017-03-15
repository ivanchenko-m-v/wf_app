
//=============================================================================
// utils - вспомогательные классы для работы программы
// Автор: Иванченко М.В.
// Дата начала разработки:  14-03-2017
// Дата обновления:         15-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
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
        public static DateTime date_from_string( string s )
        {
            return DateTime.ParseExact( s, "yyyy.MM.dd", CultureInfo.InvariantCulture );
        }

    }//public static class helper

}//namespace cfmc.utils

            