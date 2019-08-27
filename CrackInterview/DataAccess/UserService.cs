using CrackInterview.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrackInterview.Model
{
    public interface IUserService
    {
        UserResponse Authenticate(Users user);
    }

    public class UserService: IUserService
    {
        private IConfiguration _configuration { get; }
        private readonly AppSettings _appSettings;
        private readonly IDatabaseAccesReuseable _databaseAccesReuseable;
        public UserService(IConfiguration configuration, IOptions<AppSettings> appSettings, IDatabaseAccesReuseable databaseAccesReuseable)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _databaseAccesReuseable = databaseAccesReuseable;
        }
        public UserResponse Authenticate(Users user)
        {
            UserResponse response = new UserResponse();
            string Token = "";
            string query = "SELECT * FROM REGISTER WHERE Email='" + user.Email + "' and password='" + user.Password+"'";
            DataTable dt = _databaseAccesReuseable.ReturnTable(query);
            if (dt.Rows.Count > 0)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Token = tokenHandler.WriteToken(token);
                foreach(DataRow dr in dt.Rows)
                {
                    response.FullName = dr["FirstName"].ToString() +" "+ dr["MiddleName"].ToString()+ " " +dr["LastName"].ToString();
                }
                response.Message = "User having Access";
            }
            else
            {
                response.Token = "";
                response.FullName = "";
                response.Message = "Username or password is incorrect";
            }
            return response;
        }
    }
}
