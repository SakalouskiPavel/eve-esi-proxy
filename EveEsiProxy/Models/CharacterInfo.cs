using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Models
{
    public class CharacterInfo
    {
        public EsiToken Token { get; set; }

        public string CharacterId { get; set; }

        public string CharacterName { get; set; }

        public string Server { get; set; }

        public DateTime LastRefershed { get; set; } = DateTime.MinValue;
    }
}
