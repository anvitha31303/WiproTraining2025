using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;   // ✅ Fixed casing
using Microsoft.IdentityModel.Tokens;
using System;                               // ✅ Fixed casing
using System.IdentityModel.Tokens.Jwt;      // ✅ Fixed casing
using System.Security.Claims;
using System.Text;                          // ✅ Fixed casing
using JWTAuthentication.Models;             // ✅ Added for UserModel

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)   // ✅ Fixed casing
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  // ✅ Fixed
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);     // ✅ Fixed

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);  // ✅ Fixed
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            // Dummy validation — you can connect DB later
            if (login.Username == "anvitha" && login.Password == "12345")
            {
                user = new UserModel
                {
                    Username = "WiproUser",
                    EmailAddress = "test@gmail.com"
                };
            }
            return user;
        }
    }
}