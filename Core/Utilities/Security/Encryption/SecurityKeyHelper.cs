using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //işin içinde şifreleme olan sistemlerde her şeyi byte array şeklinde olması gerekiyor.JWT servicelerinin anlayacağıh hale getirmemiz gerekiyor
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
