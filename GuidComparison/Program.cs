using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

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
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SQLGuidConnection"];            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(settings.ConnectionString));

            
            


            Console.WriteLine("Now Leonid's approach");

            


        }
        
    }
}
