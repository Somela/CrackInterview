using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.Model
{
    public class EmailResponse
    {
        public OTPRequest OTPNumber { get; set; }
        public string ValueType { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
    public class EmailRequest
    {
        public string  ValueType { get; set; }
    }
    public class OTPRequest
    {
        public string message { get; set; }
    }
}
