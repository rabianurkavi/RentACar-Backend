using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //WebAPI için döndürülen anahtar
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)//JWT oluşturulabilmesi için credentials=anahtarımız 
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
