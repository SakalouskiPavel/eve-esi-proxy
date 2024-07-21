using EveEsiProxy.Models;
using EveEsiProxy.Models.Universe;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EveEsiProxy.Services
{
    public class UniverseService
    {
        private const string GET_TOKEN_URL = "https://esi.evetech.net/latest/universe/";

        private const string GET_UNIVERSE_TYPES_TEMPLATE = "types/?datasource=tranquility&page={0}";

        private const string GET_UNIVERSE_TYPE_TEMPLATE = "types/{0}/?datasource=tranquility&language=en";

        private const string REFRESH_TOKEN_BODY_TEMPLATE = "&grant_type=refresh_token&refresh_token={0}";

        private const string GET_TYPES_PAGE_NOT_EXIST = "{\"error\":\"Undefined 404 response. Original message: Requested page does not exist!\"}";

        private const string CLIENT_ID_BODY_TEMPLATE = "&client_id={0}";

        public List<long> GetUniverseTypes(int page)
        {
            var result = new List<long>();
            var response = this.SendRequest(string.Format(GET_UNIVERSE_TYPES_TEMPLATE, page));

            if (response != GET_TYPES_PAGE_NOT_EXIST)
            {
                JsonConvert.DeserializeObject<List<long>>(response);
            }

            return result;
        }

        public UniverseType GetUniverseTypeById(long id) 
        {
            var response = this.SendRequest(string.Format(GET_UNIVERSE_TYPE_TEMPLATE, id));

            return JsonConvert.DeserializeObject<UniverseType>(response);
        }

        private string SendRequest(string path)
        {    
            var request = WebRequest.CreateHttp(GET_TOKEN_URL + path);

            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var response = request.GetResponse();
                var text = "";
                using (var responseStream = new StreamReader(response.GetResponseStream()))
                {
                    text = responseStream.ReadToEnd();
                }

                return text;
            }
            catch (WebException e)
            {
                var text = "";
                using (var responseStream = new StreamReader(e.Response.GetResponseStream()))
                {
                    text = responseStream.ReadToEnd();
                }

                if (text == GET_TYPES_PAGE_NOT_EXIST)
                {
                    return text;
                }
                else
                {
                    throw e;
                }
            }
        }


    }
}
