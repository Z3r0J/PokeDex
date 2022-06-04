using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Application.Services;
using Pokedex.Database;
using PokeDex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PokeDex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        private readonly RegionServices _regionServices;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
            _regionServices = new RegionServices(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Region = _regionServices.RegionDrop();

            return View(await _pokemonServices.GetPokemons());
        }

        [HttpPost]
        public async Task<IActionResult> FindByName(string name)
        {

            if (string.IsNullOrEmpty(name)) {
                return RedirectToRoute(new { controller = "Home", Action = "Index" });
            }

            ViewBag.Region = _regionServices.RegionDrop();

            return View("Index", await _pokemonServices.GetPokemonByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> FilterByRegion(int id)
        {

            if (id == 0)
            {
                return RedirectToRoute(new { controller = "Home", Action = "Index" });
            }

            ViewBag.Region = _regionServices.RegionDrop();


            return View("Index", await _pokemonServices.GetPokemonByRegion(id));

        }
    }
}