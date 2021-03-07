using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper //Token optionsu okuyoruz
    {
        public IConfiguration Configuration { get; } //Microsoft.Extensions.Configuration
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//.net core bizim için map ediyor
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//dakika cinsinden olan değeri tarihe çevirmek için (geçerlilik süresi)
        }
        public AccessToken  CreateToken(User user,List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,user,signingCredentials,operationClaims);
            var jwtSecurityTokenHandler=new JwtSecurityTokenHandler();//Elimizdeki token'i yazdırmak için bu kullanılıyor
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//stringe çevirdik yazdırdık.

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration

            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,//Token expiration bilgisi şimdiden önceyse geçerli değil
                claims: SetClaims(user,operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user , List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>(); //System.Security.Claims'den gelir içerisinde olmayan propertyleri eklemek için
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());//List türündeki yapıyı array liste çevirdik.
            return claims;


        }
    }
}
