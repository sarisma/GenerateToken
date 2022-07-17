using GenerateToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerateToken.Service
{
    public interface IJwtAuth
    {
        GetToken Authentication(string username, string password, string clientId);
    }
}