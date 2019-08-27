using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.Model
{
    public class ForgetResponse
    {
        public string Message { get; set; }
        public string Email { get; set; }
    }
    public class ForgetRequestUpdate
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string securityQuestion1 { get; set; }
        public string securityAnswer1 { get; set; }
        public string securityQuestion2 { get; set; }
        public string securityAnswer2 { get; set; }
        public string securityQuestion3 { get; set; }
        public string securityAnswer3 { get; set; }
    }
}
