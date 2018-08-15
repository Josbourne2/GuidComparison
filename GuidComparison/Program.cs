using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GuidComparison
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
            Application.Run(new Form1());


            string connectionstring = "Server=localhost;Database=SqlGuidTestDB;Trusted_Connection = yes; ";
            Timer t1 = new Timer();


            Console.WriteLine("Now Leonid's approach");

            


        }
        
    }
}
