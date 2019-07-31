using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LoLStats.Controllers.model
{
    [DataContract]
    public class LigaContract
    {
        [DataMember(Name = "queueType")]
        public string QueueType { get; set; }

        [DataMember(Name = "summonerName")]
        public string SummonerName { get; set; }

        [DataMember(Name = "hotStreak")]
        public Boolean HotStreak { get; set; }

        [DataMember(Name = "wins")]
        public int Wins { get; set; }

        [DataMember(Name = "veteran")]
        public Boolean Veteran { get; set; }

        [DataMember(Name = "losses")]
        public int Losses { get; set; }

        [DataMember(Name = "rank")]
        public string Rank { get; set; }

        [DataMember(Name = "tier")]
        public string Tier { get; set; }

        [DataMember(Name = "inactive")]
        public Boolean Inactive { get; set; }

        [DataMember(Name = "freshBlood")]
        public Boolean FreshBlood { get; set; }

        [DataMember(Name = "leagueId")]
        public string LeagueId { get; set; }

        [DataMember(Name = "summonerId")]
        public string SummonerId { get; set; }

        [DataMember(Name = "leaguePoints")]
        public int LeaguePoints { get; set; }

    }

}
