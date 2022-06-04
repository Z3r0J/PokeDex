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

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetPokemons());
        }

        [HttpPost]
        public async Task<IActionResult> FindByName(string name)
        {

            if (string.IsNullOrEmpty(name)) {
                return RedirectToRoute(new {controller="Home",Action="Index"});
            }
            return View("Index", await _pokemonServices.GetPokemonByName(name));
        }
    }
}
