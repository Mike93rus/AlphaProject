using System;
using System.Windows.Forms;

namespace Alpha
{
    static class Program
    {
        public static FormEnter EnterForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EnterForm = new FormEnter();
            Application.Run(EnterForm);
        }

        //Изменение строки подключения в настройках
        public static void ChangeConnectionString(string connectionstring)
        {
            global::Alpha.Properties.Settings.Default.ConnectionString = connectionstring;
        }
    }
}
