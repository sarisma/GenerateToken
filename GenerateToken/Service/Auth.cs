using GenerateToken.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace GenerateToken.Service
{
    public class Auth: IJwtAuth
    {
        private readonly string key;
        string uname = "";
        string pass = "";
        string clientId = "";

        public Auth()
        {
            this.key = key;
            var ufd = new string[] { uname = "sarisma", pass = "sarisma@123", clientId = "1234" };
        }

        public GetToken Authentication(string username, string password, string clientId)
        {
            GetToken tokens = new GetToken();
            var key = "This is my first Test Key";
            if (username != uname && password != pass && clientId != clientId)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.Name, username)
                        }),
                    Expires = DateTime.UtcNow.AddMilliseconds(600),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                DateTime Expires = (DateTime)tokenDescriptor.Expires;
                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokens.expiryDate = Expires;
                tokens.token = tokenHandler.WriteToken(token);
                return tokens;
            }
        }
    }
}