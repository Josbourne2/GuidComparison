using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GuidComparison.Workers
{
    static class InsertMethods
    {
        public delegate void InsertDelegate(int number, ref List<Statistics> statsList);
        static string connectionstring = "Server=localhost;Database=SqlGuidTestDB;Trusted_Connection = yes; ";
        public static void InsertLeonid(int number, ref List<Statistics> statsList)
        {
            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                stopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    Guid myGuid = SQLGuidUtil.NewSequentialId();


                    string cmd = string.Format("INSERT INTO SQLGuidUtilTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO SQLGuidUtilTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }
                stopwatch.Stop();
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
                // Console.WriteLine(myGuid.ToString());
            }


        }



        public static void InsertRTComb(int number, ref List<Statistics> statsList)
        {
            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                stopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    Guid myGuid = RT.Comb.Provider.Sql.Create();


                    string cmd = string.Format("INSERT INTO RTCombTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO RTCombTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }
                stopwatch.Stop();
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
                //Console.WriteLine(myGuid.ToString());



            }
        }
        public static void InsertRandomGuids(int number, ref List<Statistics> statsList)
        {
            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                stopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    Guid myGuid = Guid.NewGuid();


                    string cmd = string.Format("INSERT INTO RandomGuidTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO RandomGuidTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }
                stopwatch.Stop();
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);

                // Console.WriteLine(myGuid.ToString());
            }
        }
    }
}
