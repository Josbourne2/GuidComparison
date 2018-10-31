using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;

namespace GuidComparison.Workers
{
    static class InsertMethods
    {
        public delegate void InsertDelegate(int number, ref List<Statistics> statsList, string connectionString);

        public static void InsertLeonid(int number, ref List<Statistics> statsList, string connectionString)
        {
            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                stopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    Guid myGuid = SqlGuidUtil.NewSequentialId();


                    string cmd = string.Format("INSERT INTO SQLGuidUtilTestTable ([UUID]) VALUES ('{0}')", myGuid.ToString());
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    cmd = string.Format("INSERT INTO SQLGuidUtilTestTableFKTable (FK) VALUES ('{0}')", myGuid.ToString());
                    command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();

                }
                stopwatch.Stop();
                SqlCommand getRowCount = new SqlCommand("GetRowcountFromTable", con);
                getRowCount.CommandType = CommandType.StoredProcedure;
                getRowCount.Parameters.Add(new SqlParameter("@schema_name", "dbo"));
                getRowCount.Parameters.Add(new SqlParameter("@table_name", "SQLGuidUtilTestTable"));

                SqlParameter pvRowCount = new SqlParameter();
                pvRowCount.ParameterName = "@row_count";
                pvRowCount.DbType = DbType.Int32;
                pvRowCount.Direction = ParameterDirection.Output;
                getRowCount.Parameters.Add(pvRowCount);
                getRowCount.ExecuteNonQuery();
                //int rowCount = int.Parse(getRowCount.Parameters["@row_count"].Value.ToString());
                int rowCount = Convert.ToInt32(getRowCount.Parameters["@row_count"].Value);

                stats.NumberOfRowsInTable = rowCount;
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
            }


        }



        public static void InsertRTComb(int number, ref List<Statistics> statsList, string connectionString)
        {
            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionString))
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
                SqlCommand getRowCount = new SqlCommand("GetRowcountFromTable", con);
                getRowCount.CommandType = CommandType.StoredProcedure;
                getRowCount.Parameters.Add(new SqlParameter("@schema_name", "dbo"));
                getRowCount.Parameters.Add(new SqlParameter("@table_name", "RTCombTestTable"));

                SqlParameter pvRowCount = new SqlParameter();
                pvRowCount.ParameterName = "@row_count";
                pvRowCount.DbType = DbType.Int32;
                pvRowCount.Direction = ParameterDirection.Output;
                getRowCount.Parameters.Add(pvRowCount);
                getRowCount.ExecuteNonQuery();
                //int rowCount = int.Parse(getRowCount.Parameters["@row_count"].Value.ToString());
                int rowCount = Convert.ToInt32(getRowCount.Parameters["@row_count"].Value);

                stats.NumberOfRowsInTable = rowCount;
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
            }
        }
        public static void InsertRandomGuids(int number, ref List<Statistics> statsList, string connectionString)
        {
            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionString))
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
                SqlCommand getRowCount = new SqlCommand("GetRowcountFromTable", con);
                getRowCount.CommandType = CommandType.StoredProcedure;
                getRowCount.Parameters.Add(new SqlParameter("@schema_name", "dbo"));
                getRowCount.Parameters.Add(new SqlParameter("@table_name", "RandomGuidTestTable"));

                SqlParameter pvRowCount = new SqlParameter();
                pvRowCount.ParameterName = "@row_count";
                pvRowCount.DbType = DbType.Int32;
                pvRowCount.Direction = ParameterDirection.Output;
                getRowCount.Parameters.Add(pvRowCount);
                getRowCount.ExecuteNonQuery();
                //int rowCount = int.Parse(getRowCount.Parameters["@row_count"].Value.ToString());
                int rowCount = Convert.ToInt32(getRowCount.Parameters["@row_count"].Value);

                stats.NumberOfRowsInTable = rowCount;
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
            }
        }

        public static void BulkInsertLeonid(int number, ref List<Statistics> statsList, string connectionString)
        {
            DataTable insertDataTable = new DataTable();
            insertDataTable.Columns.Add("UUID", typeof(SqlGuid));
            for (int i = 0; i < number; i++)
            {

                SqlGuid myGuid = SqlGuidUtil.NewSequentialId();

                DataRow row = insertDataTable.NewRow();
                row["UUID"] = myGuid;
                insertDataTable.Rows.Add(row);
            }



            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                stopwatch.Start();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.BulkCopyTimeout = 3600;
                    bulkCopy.DestinationTableName =
                        "[dbo].[SQLGuidUtilTestTable]";

                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(insertDataTable);

                }


                stopwatch.Stop();

                SqlCommand getRowCount = new SqlCommand("GetRowcountFromTable", con);
                getRowCount.CommandType = CommandType.StoredProcedure;
                getRowCount.Parameters.Add(new SqlParameter("@schema_name", "dbo"));
                getRowCount.Parameters.Add(new SqlParameter("@table_name", "SQLGuidUtilTestTable"));

                SqlParameter pvRowCount = new SqlParameter();
                pvRowCount.ParameterName = "@row_count";
                pvRowCount.DbType = DbType.Int32;
                pvRowCount.Direction = ParameterDirection.Output;
                getRowCount.Parameters.Add(pvRowCount);
                getRowCount.ExecuteNonQuery();
                //int rowCount = int.Parse(getRowCount.Parameters["@row_count"].Value.ToString());
                int rowCount = Convert.ToInt32(getRowCount.Parameters["@row_count"].Value);

                stats.NumberOfRowsInTable = rowCount;
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
            }


        }

        public static void BulkInsertRandomGuids(int number, ref List<Statistics> statsList, string connectionString)
        {
            DataTable insertDataTable = new DataTable();
            insertDataTable.Columns.Add("UUID", typeof(SqlGuid));
            for (int i = 0; i < number; i++)
            {

                SqlGuid myGuid = Guid.NewGuid();

                DataRow row = insertDataTable.NewRow();
                row["UUID"] = myGuid;
                insertDataTable.Rows.Add(row);
            }



            Stopwatch stopwatch = new Stopwatch();
            Statistics stats = new Statistics();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                stopwatch.Start();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.BulkCopyTimeout=3600;
                    bulkCopy.DestinationTableName =
                        "[dbo].[RandomGuidTestTable]";

                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(insertDataTable);

                }
                stopwatch.Stop();

                SqlCommand getRowCount = new SqlCommand("GetRowcountFromTable", con);
                getRowCount.CommandType = CommandType.StoredProcedure;
                getRowCount.Parameters.Add(new SqlParameter("@schema_name", "dbo"));
                getRowCount.Parameters.Add(new SqlParameter("@table_name", "RandomGuidTestTable"));

                SqlParameter pvRowCount = new SqlParameter();
                pvRowCount.ParameterName = "@row_count";
                pvRowCount.DbType = DbType.Int32;
                pvRowCount.Direction = ParameterDirection.Output;
                getRowCount.Parameters.Add(pvRowCount);
                getRowCount.ExecuteNonQuery();
                //int rowCount = int.Parse(getRowCount.Parameters["@row_count"].Value.ToString());
                int rowCount = Convert.ToInt32(getRowCount.Parameters["@row_count"].Value);

                stats.NumberOfRowsInTable = rowCount;
                stats.Operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
                stats.DurationInMilliseconds = stopwatch.ElapsedMilliseconds;
                statsList.Add(stats);
            }
        }
    }
}
