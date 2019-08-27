using CrackInterview.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CrackInterview.DataAccess;
using System.Data;

namespace CrackInterview.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IDatabaseAccess _databaseAccess;
        public RegisterController(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(
           [FromBody] Register registerRequest)
        {

            var responseCode = _databaseAccess.RegisterInsertData(registerRequest);
            return StatusCode(responseCode.Result.statusCode, responseCode.Result.Message);
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> Forget(
           [FromBody] ForgetRequest  forgetPasswordRequest)
        {

            var dataTable = _databaseAccess.ForgetPasswordInsertData(forgetPasswordRequest);
            return StatusCode(200, dataTable);
        }
        [HttpPut("ForgetPasswordUpdate")]
        public async Task<IActionResult> ForgetUpdate(
           [FromBody] ForgetRequestUpdate forgetRequestUpdate)
        {

            var dataTable = _databaseAccess.ForgetPasswordUpdate(forgetRequestUpdate);
            return StatusCode(200, dataTable);
        }
    }
}
