using Newtonsoft.Json;

namespace EveEsiProxy.Models.Universe
{
    public class DogmaEffect
    {
        [JsonProperty("effect_id")]
        public int EffectId { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}
