using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerateToken.Models
{
    public class User
    {
        public string username { get; set; }
    }
    public class UserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string clientId { get; set; }
    }
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyData
    {
        public mytoken data { get; set; }
        public MyData()
        {
            data = new mytoken();
        }      
    }
    public class mytoken
    {
        public string token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class GetToken
    {
        public string token { get; set; }
        public DateTime expiryDate { get; set; }
    }
}