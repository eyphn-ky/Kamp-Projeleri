using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{//Hazır sınıfların metodları propertyleri yetersiz kaldığında veya ek yapmak istediğimizde onları extend(genişletmek) ederiz.
 //Extend edilen classlar static olmalıdır.
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email) //Claim sınıfını extend edeceğimizi this ile belirttik ev ettik
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));//extend ettiğimiz sınıfa hazır isimlerden birini verdik ve parametreyide yolladık.
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(p => claims.Add(new Claim(ClaimTypes.Role, p)));
        }
    }
}
