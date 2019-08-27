using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.Model
{
    public class Users
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserResponse
    {
        public string FullName { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
