using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace ExamplePOSTrequest
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            TGMTini.GetInstance().LoadConfig("config.ini", "VietANPR");

            Application.Run(new Form1());
        }
    }
}
