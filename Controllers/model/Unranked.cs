using System;
using System.Collections.Generic;
using System.Text;

namespace LoLStats.Controllers.model
{
    public class Unranked : LigaContract
    {
        public Unranked(string Id, string Name)
        {
            this.FreshBlood = false;
            this.HotStreak = false;
            this.Inactive = false;
            this.LeagueId = "Indisponivel";
            this.LeaguePoints = 0;
            this.Losses = 0;
            this.QueueType = "Sem estatísticas";
            this.Rank = "Sem estatísticas";
            this.SummonerId = Id;
            this.SummonerName = Name;
            this.Tier = "Sem estatísticas";
            this.Veteran = false;
            this.Wins = 0;
        }
    }
}
