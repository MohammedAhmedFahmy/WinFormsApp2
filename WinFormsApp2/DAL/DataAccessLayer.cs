using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace WinFormsApp2.DAL
{
    internal class DataAccessLayer
    {
        SqlConnection sqlconnection;

        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection(@"Server=.; Database=company; Integrated Security=true");
            SqlCommand cmd = new SqlCommand();



        }

        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        public void Close()
        {
            if (sqlconnection.State != ConnectionState.Closed)
            {
                sqlconnection.Close();
            }
        }
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stored_procedure;
            cmd.Connection = sqlconnection;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++) { cmd.Parameters.Add(param[i]); }

            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void ExexuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stored_procedure;
            cmd.Connection = sqlconnection;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            cmd.ExecuteNonQuery();

        }
        public DataTable order(string query)
        {
            SqlDataAdapter d = new SqlDataAdapter(query, sqlconnection);
            DataTable dt = new DataTable();
            d.Fill(dt);
            return dt;

        }
        public void Run(String tquery)
        {
            string sqlQuery = (tquery);
            SqlCommand cmd;
            cmd = new SqlCommand(sqlQuery, sqlconnection);
            int n = cmd.ExecuteNonQuery();
        }
        public int getMax(string tblName)
        {
            int max = 0;
            DAL.DataAccessLayer dataAccesLayer = new DAL.DataAccessLayer();
            dataAccesLayer.Open();
            DataTable d = dataAccesLayer.order("select * from " + tblName + "");
            if (d.Rows.Count > 0)
            {
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (int.Parse(d.Rows[i][0].ToString()) >= max)
                    {
                        max = int.Parse(d.Rows[i][0].ToString()) + 1;
                    }

                }
                dataAccesLayer.Close();
                return max;
            }
            else
            {
                dataAccesLayer.Close();
                return 1;
            }
        }
    }
}
