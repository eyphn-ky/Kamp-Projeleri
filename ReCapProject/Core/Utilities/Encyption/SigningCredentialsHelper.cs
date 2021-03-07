using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Encyption
{
    public class SigningCredentialsHelper //hangi key hangi algoritma onu seçer
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        }
    }
}
