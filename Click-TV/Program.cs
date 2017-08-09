using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Click_TV
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, @"Global\" + "RIKTIPTvPlayer"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Вторая копия данного приложения не может быть запущена!", "Ошибка запуска приложения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                GC.Collect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoadingWindow());
            }
        }
    }
}
