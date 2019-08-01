using LoLStats.Controllers.model;
using LoLStats.Models;
using LoLStats.Repository;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using System;

namespace LoLStats.Services
{
    public class LoLService
    {
        //Dados imutaveis de chamada da api
        private const string urlBase = "api.riotgames.com";
        private string key = $"?api_key={Environment.GetEnvironmentVariable("LOL_API")}";

        private readonly LoLStatsContext _context;
        private readonly Perfil _perfil;
        private SummonerContract _summonerContract;
        private LigaContract _ligaContract;
        private readonly PerfilContract _perfilContract;
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

            _perfilContract.GetLigaContract().QueueType = _perfilContract.GetLigaContract().QueueType.Replace("_", " ");

            _context.Perfil.Add(PrepararObj(_perfilContract));
            _context.SaveChanges();

            return _perfilContract;
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
            using (HttpClient HttpClient = new HttpClient())
            {
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
        public string GetRegion(int Region)
        {
            string[] RegiaoShort = { "br1.", "na1.", "eun1.", "jp1.", "kr.", "oc1." };
            string[] RegiaoFull = { "Brasil", "America do Norte", "Europa", "Japão", "Coreia", "Oceania" };

            _perfilContract.SetRegiao(RegiaoFull[Region - 1]);

            return RegiaoShort[Region - 1];
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
}
