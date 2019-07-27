using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoLStats.Models;
using LoLStats.Services;
using LoLStats.Controllers.model;

namespace LoLStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoLService _loLService;
        //private LigaContract _ligaContract;

        public HomeController(LoLService loLService)
        {
            _loLService = loLService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoL()
        {
            return View();
        }

        public async Task<IActionResult> SearchLoLAsync(string Summoner, int Region)
        {

            PerfilContract Result = await _loLService.GetProfileAsync(Summoner, Region);

            if(Result.Equals(null))
            {
                ViewBag.Erro = "Gênero inválido ou não encontrado";
            }
            else
            {
                ViewBag.Erro = "";
            }

            ViewBag.Perfil = Result;

            return View("~/Views/Result/List.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
