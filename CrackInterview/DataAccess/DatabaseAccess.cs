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
        Task<ForgetResponse> ForgetPasswordUpdate(ForgetRequestUpdate forgetRequest);
    }
    public class DatabaseAccess: IDatabaseAccess
    {
        private IConfiguration _configuration;
        private readonly IDatabaseAccesReuseable _databaseAccesReuseable;
        public DatabaseAccess(IConfiguration configuration, IDatabaseAccesReuseable databaseAccesReuseable)
        {
            _configuration = configuration;
            _databaseAccesReuseable = databaseAccesReuseable;
        }
        public async Task<RegisterResponse> RegisterInsertData(Register register)
        {
            var responseCode = new RegisterResponse();
            var connection = _configuration.GetConnectionString("DBConnection");
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
        public async Task<ForgetResponse> ForgetPasswordUpdate(ForgetRequestUpdate forgetRequest)
        {
            var responseCode = new ForgetResponse();
            var connection = _configuration.GetConnectionString("DBConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            DataTable table = new DataTable();
            DataTable dt = new DataTable();
            try
            {
                string querySelect= ConnectionQueryForget(forgetRequest.Email);
                dt = _databaseAccesReuseable.ReturnTable(querySelect);
                if (dt.Rows.Count > 0)
                {
                    DataColumn[] columns = dt.Columns.Cast<DataColumn>().ToArray();
                    bool anyFieldContainsSecurity = dt.AsEnumerable()
                    .Where(c =>c.Field<string>("securityQuestion1").Equals(forgetRequest.securityQuestion1))
                    .Where(c =>c.Field<string>("securityAnswer1").Equals(forgetRequest.securityAnswer1))
                    .Where(c => c.Field<string>("securityQuestion2").Equals(forgetRequest.securityQuestion2))
                    .Where(c => c.Field<string>("securityAnswer2").Equals(forgetRequest.securityAnswer2))
                    .Where(c => c.Field<string>("securityQuestion3").Equals(forgetRequest.securityQuestion3))
                    .Where(c => c.Field<string>("securityAnswer3").Equals(forgetRequest.securityAnswer3))
                    .Count() > 0;
                    if (anyFieldContainsSecurity)
                    {
                        string query = connectionqueryforgetupdate(forgetRequest);
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlConnection.Open();
                        int count = (int)sqlCommand.ExecuteNonQuery();
                        if (sqlConnection.State == System.Data.ConnectionState.Open)
                            sqlConnection.Close();
                        if (count > 0)
                        {
                            responseCode.Message = "Updated Successfully";
                            responseCode.Email = forgetRequest.Email;
                        }
                    }
                    else
                    {
                        responseCode.Message = "Email Not Exist";
                    }
                }
                else
                {
                    responseCode.Message = "Email Not Exist";
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
            string Roles = "Normal";
            string query = "INSERT INTO Register VALUES ('" + register.Email + "','" + register.Password + "','" + register.Mobile + "','" + register.DateOfBirth + "','" + register.FirstName + "','" + register.MiddleName + "','" + register.LastName + "','" + register.securityQuestions.securityQuestion1 + "','" + register.securityQuestions.securityAnswer1 + "','" + register.securityQuestions.securityQuestion2 + "','" + register.securityQuestions.securityAnswer2 + "','" + register.securityQuestions.securityQuestion3 + "','" + register.securityQuestions.securityAnswer3 + "','" + Roles + "');";
            return query;
        }
        public string ConnectionQueryForget(string Email)
        {
            string query = "SELECT EMAIL,securityQuestion1,securityAnswer1,securityQuestion2,securityAnswer2,securityQuestion3,securityAnswer3 FROM REGISTER WHERE EMAIL='" + Email + "'";
            return query;
        }
        public string connectionqueryforgetupdate(ForgetRequestUpdate forgetrequest)
        {
            string query = "update register set password='" + forgetrequest.Password + "' where email = '" + forgetrequest.Email + "'";
            return query;
        }
    }
}
