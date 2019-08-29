using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.Model
{
    public class CompanyResponse
    {
        public string CompanyNames { get; set; }
        public string Questions { get; set; }
    }
    public class ListCompanyResponse
    {
        public List<CompanyResponse> questions { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
