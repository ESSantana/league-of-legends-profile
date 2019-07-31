using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LoLStats.Controllers.model
{
    [DataContract]
    public class PerfilContract
    {
        [DataMember]
        private LigaContract LigaContract;

        public void SetLigaContract(LigaContract l)
        {
            this.LigaContract = l;
        }
        public LigaContract GetLigaContract()
        {
            return this.LigaContract;
        }

        [DataMember]
        private SummonerContract SummonerContract;

        public void SetSummonerContract(SummonerContract s)
        {
            this.SummonerContract = s;
        }
        public SummonerContract GetSummonerContract()
        {
            return this.SummonerContract;
        }

        [DataMember]
        private string Regiao;

        public void SetRegiao(string Regiao)
        {
            this.Regiao = Regiao;
        }

        public string GetRegiao()
        {
            return this.Regiao;
        }
    }
}
