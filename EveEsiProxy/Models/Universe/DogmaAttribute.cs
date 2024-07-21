using Newtonsoft.Json;

namespace EveEsiProxy.Models.Universe
{
    public class DogmaAttribute
    {
        [JsonProperty("attribute_id")]
        public int AttributeId { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }
    }
}
