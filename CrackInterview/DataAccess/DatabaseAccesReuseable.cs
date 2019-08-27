using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.DataAccess
{
    public interface IDatabaseAccesReuseable
    {
        DataTable ReturnTable(string query);
        void ExcuteQuery(string query);
    }
    public class DatabaseAccesReuseable: IDatabaseAccesReuseable
    {
        private IConfiguration _configuration { get; }
        public DatabaseAccesReuseable(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DataTable ReturnTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Log.Information("Data Exception" + ex.Message);
            }
            return dt;
        }
        public void ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.BeginExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Log.Information("Data Exception" + ex.Message);
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}
