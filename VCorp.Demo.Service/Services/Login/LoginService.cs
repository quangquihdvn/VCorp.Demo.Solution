using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VCorp.Demo.ViewModels.Common;

namespace VCorp.Demo.Service.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;
        public LoginService(
            IConfiguration config)
        {
            _config = config;
        }

        public string Authencate()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,"quangquihdvn@gmail.com"),
                new Claim(ClaimTypes.Name, "Bui Quang Qui")
            };
            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
