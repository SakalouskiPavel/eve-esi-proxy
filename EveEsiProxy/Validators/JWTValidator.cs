using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Validators
{
    internal class JWTValidator
    {
        private const string ISSUER = "login.eveonline.com";

        public JwtSecurityToken ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = null,
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                var jwt = (JwtSecurityToken)tokenHandler.ReadToken(token);

                var audience = jwt.Claims.Where(x => x.Type == "aud");

                return jwt;
            }
            catch (SecurityTokenValidationException ex)
            {
                throw ex;
            }
        }
    }
}
