using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Models.Universe
{
    public class Category
    {
        [JsonProperty("category_id")]
        public long Id { get; set; }

        [JsonProperty("groups")]
        public long[] Groups { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("published")]
        public bool IsPublished { get; set; }
    }
}
