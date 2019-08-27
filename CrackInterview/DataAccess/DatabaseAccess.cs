using CrackInterview.Model;
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
    
    public interface IDatabaseAccess
    {
        Task<RegisterResponse> RegisterInsertData(Register register);
        Task<DataTable> ForgetPasswordInsertData(ForgetRequest forgetRequest);
        Task<RegisterResponse> ForgetPasswordUpdate(ForgetRequestUpdate forgetRequest);
    }
    public class DatabaseAccess: IDatabaseAccess
    {
        private IConfiguration _configuration;
        public DatabaseAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<RegisterResponse> RegisterInsertData(Register register)
        {
            var responseCode = new RegisterResponse();
            var connection = _configuration.GetConnectionString("AwdDB");
            SqlConnection sqlConnection = new SqlConnection(connection);
            try
            {
                string query = ConnectionQueryLogin(register);
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int count = (int)sqlCommand.ExecuteNonQuery();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
                if (count>0)
                {
                    responseCode.Message = "Inserted Successfully";
                    responseCode.statusCode = 201;
                }
            }
            catch(Exception ex)
            {
                Log.Information("DB Having Error" + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return responseCode;
        }
        public async Task<DataTable> ForgetPasswordInsertData(ForgetRequest forgetRequest)
        {
            var responseCode = new RegisterResponse();
            var connection = _configuration.GetConnectionString("AwdDB");
            SqlConnection sqlConnection = new SqlConnection(connection);
            DataTable table = new DataTable();
            try
            {
                string query = ConnectionQueryForget(forgetRequest);
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(table);
            }
            catch (Exception ex)
            {
                Log.Information("DB Having Error" + ex.Message);
            }
            finally
            {
               
                sqlConnection.Dispose();
            }
            return table;
        }
        public async Task<RegisterResponse> ForgetPasswordUpdate(ForgetRequestUpdate forgetRequest)
        {
            var responseCode = new RegisterResponse();
            var connection = _configuration.GetConnectionString("AwdDB");
            SqlConnection sqlConnection = new SqlConnection(connection);
            DataTable table = new DataTable();
            try
            {
                string query = connectionqueryforgetupdate(forgetRequest);
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int count = (int)sqlCommand.ExecuteNonQuery();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
                if (count > 0)
                {
                    responseCode.Message = "Inserted Successfully";
                    responseCode.statusCode = 201;
                }
            }
            catch (Exception ex)
            {
                Log.Information("DB Having Error" + ex.Message);
            }
            finally
            {

                sqlConnection.Dispose();
            }
            return responseCode;
        }
        public string ConnectionQueryLogin(Register register)
        {
            register.FirstName = register.FirstName ?? null;
            register.LastName = register.LastName ?? null;
            register.MiddleName = register.MiddleName ?? null;
            register.FirstName = register.FirstName ?? null;
            string Roles = "Normal";
            string query = "INSERT INTO Register VALUES ('" + register.Email + "','" + register.Password + "','" + register.Mobile + "','" + register.FirstName + "','" + register.LastName + "','" + register.DateOfBirth + "','" + register.MiddleName + "','" +Roles+ "');";
            return query;
        }
        public string ConnectionQueryForget(ForgetRequest forgetRequest)
        {
            string query = "SELECT EMAIL,securityQuestion1,securityAnswer1,securityQuestion2,securityAnswer2 FROM REGISTER WHERE EMAIL='" + forgetRequest.Email + "'";
            return query;
        }
        public string connectionqueryforgetupdate(ForgetRequestUpdate forgetrequest)
        {
            string query = "update register set password='" + forgetrequest.Password + "'where email = " + forgetrequest.Email + "'";
            return query;
        }
    }
}
