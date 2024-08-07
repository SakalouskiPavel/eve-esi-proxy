﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Models.Universe
{
    public class UniverseType
    {
        [JsonProperty("capacity")]
        public float Capacity { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dogma_attributes")]
        public List<DogmaAttribute> DogmaAttributes { get; set; } = new List<DogmaAttribute>();

        [JsonProperty("dogma_effects")]
        public List<DogmaEffect> DogmaEffects { get; set; } = new List<DogmaEffect>();

        [JsonProperty("graphic_id")]
        public int GraphicId { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("icon_id")]
        public int IconId { get; set; }

        [JsonProperty("market_group_id")]
        public int MarketGroupId { get; set; }

        [JsonProperty("mass")]
        public float Mass { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("packaged_volume")]
        public float PackagedVolume { get; set; }

        [JsonProperty("portion_size")]
        public int PortionSize { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("radius")]
        public float Radius { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        [JsonProperty("volume")]
        public float Volume { get; set; }
    }
}
