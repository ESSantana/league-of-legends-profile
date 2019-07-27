using System.Collections.Generic;
using System.Threading.Tasks;
using LoLStats.Models;
using System.Net.Http;
using LoLStats.Controllers.model;
using System.Net.Http.Headers;
using LoLStats.Repository;
using System.Data.SqlClient;

namespace LoLStats.Services
{
    public class LoLService : ILoLService
    {
        //Dados imutaveis de chamada da api
        private const string urlBase = "api.riotgames.com";
        private const string key = "?api_key=RGAPI-6d33117e-c18d-475a-b494-be4dcb517b5e";

        private readonly LoLStatsContext _context;
        private Perfil _perfil;
        private SummonerContract _summonerContract;
        private LigaContract _ligaContract;
        private PerfilContract _perfilContract;
        private Unranked _unranked;

        public LoLService(SummonerContract summonerContract, PerfilContract perfilContract, 
            LigaContract ligaContract, LoLStatsContext context, Perfil perfil)
        {
            _perfil = perfil;
            _context = context;
            _summonerContract = summonerContract;
            _ligaContract = ligaContract;
            _perfilContract = perfilContract;
        }

        
        public async Task<PerfilContract> GetProfileAsync(string Summoner, int Region)
        {

            string QuerySummoner = $"https://{GetRegion(Region)}";
            QuerySummoner += $"{urlBase}/lol/summoner/v4/summoners/by-name/{Summoner}{key}";
            _perfilContract.SetSummonerContract(await GetSummonerAsync(QuerySummoner));

            string QueryLiga = $"https://{GetRegion(Region)}";
            QueryLiga += $"{urlBase}/lol/league/v4/entries/by-summoner/{_perfilContract.GetSummonerContract().Id}{key}";
            _perfilContract.SetLigaContract(await GetLigaAsync(QueryLiga));



            _context.Perfil.Add(PrepararObj(_perfilContract));
            _context.SaveChanges();

            return _perfilContract;
        }

        public string GetRegion(int Region)
        {
            string[] RegiaoShort = { "br1.", "na1.", "eun1.", "jp1.", "kr.", "oc1." };
            string[] RegiaoFull = { "Brasil", "America do Norte", "Europa", "Japão", "Coreia", "Oceania" };
            _perfilContract.SetRegiao(RegiaoFull[Region - 1]);
            return RegiaoShort[Region-1];
        }

        public async Task<SummonerContract> GetSummonerAsync(string Summoner)
        {
            using (HttpClient HttpClient = new HttpClient())
            {
                HttpClient.DefaultRequestHeaders.Accept.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await HttpClient.GetAsync(Summoner);
                if (response.IsSuccessStatusCode)
                {
                    SummonerContract sum = await response.Content.ReadAsAsync<SummonerContract>();
                    _summonerContract = sum;
                }

            }
            return _summonerContract;
        }

        public async Task<LigaContract> GetLigaAsync(string Liga)
        {
            using (HttpClient HttpClient = new HttpClient()) {
                HttpClient.DefaultRequestHeaders.Accept.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                HttpResponseMessage response = await HttpClient.GetAsync(Liga);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        List<LigaContract> lig = await response.Content.ReadAsAsync<List<LigaContract>>();
                        _ligaContract = lig[0];
                    }
                    catch (System.Exception)
                    {
                        _unranked = new Unranked(_perfilContract.GetSummonerContract().Id,
                            _perfilContract.GetSummonerContract().Name);
                        _ligaContract = _unranked;
                    }
                
                }
            }
            return _ligaContract;
        }

        private Perfil PrepararObj(PerfilContract entity)
        {
            _perfil.AccountId = entity.GetSummonerContract().AccountId;
            _perfil.Name = entity.GetSummonerContract().Name;
            _perfil.Tier = entity.GetLigaContract().Tier;
            _perfil.Rank = entity.GetLigaContract().Rank;
            _perfil.QueueType = entity.GetLigaContract().QueueType;
            _perfil.LeaguePoints = entity.GetLigaContract().LeaguePoints;
            _perfil.Wins = entity.GetLigaContract().Wins;
            _perfil.Losses = entity.GetLigaContract().Losses;
            _perfil.Regiao = entity.GetRegiao();


            return _perfil;
        }

    }
    public interface ILoLService
    {
        Task<PerfilContract> GetProfileAsync(string Summoner, int Region);
        string GetRegion(int Region);
        Task<SummonerContract> GetSummonerAsync(string Summoner);
        Task<LigaContract> GetLigaAsync(string Liga);
    }
}
