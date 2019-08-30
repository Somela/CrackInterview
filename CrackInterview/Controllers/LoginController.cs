using CrackInterview.DataAccess;
using CrackInterview.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackInterview.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private IUserService _userService;
        private IEmailDataAccess _emailDataAccess;
        private IMobileDataAccess _mobileDataAccess;

        public LoginController(IUserService userService, IEmailDataAccess emailDataAccess, IMobileDataAccess mobileDataAccess)
        {
            _userService = userService;
            _emailDataAccess = emailDataAccess;
            _mobileDataAccess = mobileDataAccess;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Users userParam)
        {
            var response = _userService.Authenticate(userParam);
            return StatusCode(200, response);
        }
        [AllowAnonymous]
        [HttpPost("two-way-authenticate")]
        public async Task<IActionResult> TwoWayAuthenticate([FromBody] EmailRequest emailRequest)
        {
            EmailResponse otpResponse = new EmailResponse();
            if (emailRequest.ValueType.Contains("@"))
            {
                //response = _emailDataAccess.OTPRequest(emailRequest);
            }
            else
            {
                otpResponse.OTPNumber= await _mobileDataAccess.PhoneOTPRequest(emailRequest);
                otpResponse.Message = "OTP Sent Successfully";
                otpResponse.StatusCode = 200;
                otpResponse.ValueType = emailRequest.ValueType;
            }
            return StatusCode(200, otpResponse);
        }
    }
}
