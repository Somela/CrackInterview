using CrackInterview.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.DataAccess
{
    public interface IHomeDataAccess
    {
        Task<List<CompanyResponse>> GetCompanyResponse();
    }
    public class HomeDataAccess:IHomeDataAccess
    {
        private IConfiguration _configuration;
        private IDatabaseAccesReuseable _IdatabaseAccesReuseable;
        public HomeDataAccess(IConfiguration configuration, IDatabaseAccesReuseable IdatabaseAccesReuseable)
        {
            _configuration = configuration;
            _IdatabaseAccesReuseable = IdatabaseAccesReuseable;
        }
        public async Task<List<CompanyResponse>> GetCompanyResponse()
        {
            var listOfCompanies = new List<CompanyResponse>();
            string ConnectionString = _configuration.GetSection("Queries").GetSection("SelectQuestionQuery").Value;
            DataTable dataTable = _IdatabaseAccesReuseable.ReturnTable(ConnectionString);
            foreach(DataRow data in dataTable.Rows)
            {
                listOfCompanies.Add(new CompanyResponse()
                {
                    CompanyNames = data["CompanyName"].ToString(),
                    Questions = data["Questions"].ToString()
                });
            }
            return listOfCompanies;
        }
    }
}
