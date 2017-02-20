//=============================================================================
// Program - класс программы с функцией Main( )
// Автор: Иванченко М.В.
// Дата начала разработки:  17-02-2017
// Дата обновления:         20-02-2017
// Релиз:                   0.0.0.0
//=============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_app
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_report_catch());
        }
    }
}
