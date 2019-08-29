using CrackInterview.DataAccess;
using CrackInterview.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class HomeController : ControllerBase
    {
        private IHomeDataAccess _homeDataAccess;
        public HomeController(IHomeDataAccess homeDataAccess)
        {
            _homeDataAccess = homeDataAccess;
        }
        [HttpGet("CompanyQuestions")]
        public async Task<IActionResult> GetCompanyQuestions()
        {
            ListCompanyResponse questions = new ListCompanyResponse();
            questions.questions = await _homeDataAccess.GetCompanyResponse();
            questions.Message = "Loaded Questions";
            questions.StatusCode = 200;
            return StatusCode(questions.StatusCode, questions);
        }
    }
}
