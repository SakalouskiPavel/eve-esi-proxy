using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Models
{
    public class EsiToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public string Expires { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        public override string ToString()
        {
            return AccessToken + Environment.NewLine + Expires + Environment.NewLine + RefreshToken + Environment.NewLine + TokenType + Environment.NewLine;
        }
    }
}
