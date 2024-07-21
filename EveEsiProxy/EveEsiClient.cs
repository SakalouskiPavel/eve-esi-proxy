using EveEsiProxy.Models;
using EveEsiProxy.Services;
using EveEsiProxy.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy
{
    public class EveEsiClient
    {
        private readonly EsiConfig _config;

        public EveEsiClient(EsiConfig config)
        {
            this._config = config;
            this.Tokens = new TokenService(this._config);
        }

        public TokenService Tokens { get; private set; }

        public CharacterInfo GetCharacterInfo(string authorizationCode)
        {
            var token = this.Tokens.GetToken(authorizationCode);

            return GetCharacterInfoFromToken(token);
        }

        public CharacterInfo GetCharacterInfoFromToken(EsiToken token)
        {
            var characterInfo = new CharacterInfo();

            characterInfo.Token = token;

            var validator = new JWTValidator();

            var jwtToken = validator.ValidateToken(token.AccessToken);

            characterInfo.CharacterId = jwtToken.Claims.First(x => x.Type == "sub").Value.Split(':')[2];
            characterInfo.Server = jwtToken.Claims.First(x => x.Type == "tenant").Value;
            characterInfo.CharacterName = jwtToken.Claims.First(x => x.Type == "name").Value;

            return characterInfo;
        }
    }
}
