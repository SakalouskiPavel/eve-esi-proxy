using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Models.Skills
{
    public class CharacterSkills
    {
        [JsonProperty("skills")]
        public List<SkillDetails> Skills { get; set; } = new List<SkillDetails>();

        [JsonProperty("total_sp")]
        public long TotalSp { get; set; }

        [JsonProperty("unallocated_sp")]
        public int UnallocatedSp { get; set; }
    }
}
