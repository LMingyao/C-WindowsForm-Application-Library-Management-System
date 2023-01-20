using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject2021.GUI;

namespace FinalProject2021
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
            Application.Run(new MainInterface());
            //Application.Run(new MISManager());
            //Application.Run(new SalesManager());
            //Application.Run(new OrderClerk());
            //Application.Run(new InventoryController());
            //Application.Run(new Accountant());
        }
    }
}
