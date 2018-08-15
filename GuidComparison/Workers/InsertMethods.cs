using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GuidComparison.Workers
{
    static class InsertMethods
    {
        public delegate void InsertDelegate(int number);
        static string connectionstring = "Server=localhost;Database=SqlGuidTestDB;Trusted_Connection = yes; ";
        public static void InsertLeonid(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Guid myGuid = SQLGuidUtil.NewSequentialId();
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string cmd = string.Format("INSERT INTO SQLGuidUtilTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO SQLGuidUtilTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }

                // Console.WriteLine(myGuid.ToString());
            }


        }



        public static void InsertRTComb(int number)
        {

            for (int i = 0; i < number; i++)
            {
                Guid myGuid = RT.Comb.Provider.Sql.Create();
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string cmd = string.Format("INSERT INTO RTCombTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO RTCombTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }
                //Console.WriteLine(myGuid.ToString());



            }
        }
        public static void InsertRandomGuids(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Guid myGuid = Guid.NewGuid();
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string cmd = string.Format("INSERT INTO RandomGuidTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO RandomGuidTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }

                // Console.WriteLine(myGuid.ToString());
            }
        }
    }
}
