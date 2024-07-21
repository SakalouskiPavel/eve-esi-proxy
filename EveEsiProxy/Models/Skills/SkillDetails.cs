using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Models.Skills
{
    public class SkillDetails
    {
        [JsonProperty("skill_id")]
        public int SkillId { get; set; }

        [JsonProperty("skillpoints_in_skill")]
        public long SkillpointsInSkill { get; set; }

        [JsonProperty("trained_skill_level")]
        public int TrainedSkillLevel { get; set; }

        [JsonProperty("active_skill_level")]
        public int ActiveSkillLevel { get; set; }
    }
}
