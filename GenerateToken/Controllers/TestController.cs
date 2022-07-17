using GenerateToken.Models;
using GenerateToken.Service;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace GenerateToken.Controllers
{
    public class TestController : ApiController
    {
     
        private readonly IJwtAuth _jWTManager;
        public TestController()
        {
            Auth jWTManager = new Auth();
            _jWTManager = jWTManager;
        }

        //public GetToken Authentication(string username, string password, string clientId)
        //{
        //    GetToken tokens = new GetToken();
        //    var key = "This is my first Test Key";
        //    var ufd = new string[] { uname = "sooacz", pass = "acharya", clientId = "1234" };
        //    if (username != uname && password != pass && clientId != clientId)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenKey = Encoding.ASCII.GetBytes(key);
        //        var tokenDescriptor = new SecurityTokenDescriptor()
        //        {
        //            Subject = new ClaimsIdentity(
        //                new Claim[]
        //                {
        //                new Claim(ClaimTypes.Name, username)
        //                }),
        //            Expires = DateTime.Now.AddSeconds(60),
        //            SigningCredentials = new SigningCredentials(
        //                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        DateTime Expires = (DateTime)tokenDescriptor.Expires;
        //         var token = tokenHandler.CreateToken(tokenDescriptor);
        //        tokens.expiryDate = Expires;
        //        tokens.token = tokenHandler.WriteToken(token);
        //        return tokens;
        //    }
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Test/GetToken")]
        public IHttpActionResult GetToken([FromBody] UserCredential userCredential)
        {
            MyData md = new MyData();
            GetToken tokengen= new GetToken();
            tokengen = _jWTManager.Authentication(userCredential.UserName, userCredential.Password, userCredential.clientId);
            if (tokengen == null)
                return Unauthorized();
            md.data.token = tokengen.token;
            md.data.ExpiryDate = tokengen.expiryDate ;
         
            return Ok(md);
        }
    }
}
