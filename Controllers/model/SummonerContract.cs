using System.Runtime.Serialization;

namespace LoLStats.Controllers.model
{
    [DataContract]
    public class SummonerContract
    {
        [DataMember(Name= "profileIconId")]
        public int ProfileIconId { get; set; }

        [DataMember(Name= "name")]
        public string Name { get; set; }

        [DataMember(Name = "puuid")]
        public string Puuid { get; set; }

        [DataMember(Name = "summonerLevel")]
        public long SummonerLevel { get; set; }

        [DataMember(Name = "revisionDate")]
        public long RevisionDate { get; set; }

        [DataMember(Name ="id")]
        public string Id { get; set; }

        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }
    }

}
