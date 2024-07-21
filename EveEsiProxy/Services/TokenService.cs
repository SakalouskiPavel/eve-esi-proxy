using EveEsiProxy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Services
{
    public class TokenService
    {
        private const string GET_TOKEN_URL = "https://login.eveonline.com/v2/oauth/token";

        private const string GET_TOKEN_BODY_TEMPLATE = "&grant_type=authorization_code&code={0}";

        private const string REFRESH_TOKEN_BODY_TEMPLATE = "&grant_type=refresh_token&refresh_token={0}";

        private const string CLIENT_ID_BODY_TEMPLATE = "&client_id={0}";

        private readonly EsiConfig _config;

        public TokenService(EsiConfig config)
        {
            this._config = config;
        }

        public EsiToken GetToken(string authorizationCode)
        {
            return SendRequest(authorizationCode, GET_TOKEN_BODY_TEMPLATE);
        }

        public EsiToken RefreshToken(string refreshToken)
        {
            return SendRequest(refreshToken, REFRESH_TOKEN_BODY_TEMPLATE, CLIENT_ID_BODY_TEMPLATE);
        }

        private EsiToken SendRequest(string authorizationCode, string requestBodyTemplate, string clientIdBodyTemplate = null)
        {
            var encodedCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:lVsnAUlnUpLjFb16d6kv4vWc5VyJjVzioJmBW5a4", this._config.ClientId)));

            var request = WebRequest.CreateHttp(GET_TOKEN_URL);

            request.Method = "POST";
            request.Headers.Add("Authorization: Basic " + encodedCode);
            request.ContentType = "application/x-www-form-urlencoded";

            var requestBody = string.Format(requestBodyTemplate, authorizationCode);

            if (clientIdBodyTemplate != null)
            {
                requestBody += string.Format(clientIdBodyTemplate, this._config.ClientId);
            }

            using (var requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write(requestBody);
            }

            var response = request.GetResponse();
            var text = "";
            using (var responseStream = new StreamReader(response.GetResponseStream()))
            {
                text = responseStream.ReadToEnd();
            }

            var token = JsonConvert.DeserializeObject<EsiToken>(text);

            return token;
        }
    }
}
