using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var formLogin = new FormLogin();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormMenu());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
