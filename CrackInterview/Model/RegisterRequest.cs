using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.Model
{
    public class Register
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public long Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string securityQuestion1 { get; set; }
        public string securityAnswer1 { get; set; }
        public string securityQuestion2 { get; set; }
        public string securityAnswer2
        {
            get; set;
        }
    }
}
