using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.Services;
using Pokedex.Application.ViewModel;
using Pokedex.Database;
using System.Threading.Tasks;

namespace PokeDex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        private readonly RegionServices _regionServices;
        private readonly TypeServices _typeServices;

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
            _regionServices = new(dbContext);
            _typeServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetPokemons());
        }

        public IActionResult Create()
        {
            var _addPokemon = new AddPokemonViewModel() { 
                Region = _regionServices.RegionDrop(), 
                Type = _typeServices.TypeDrop() };

            return View("CreatePokemon", _addPokemon);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPokemonViewModel vm) {

            await _pokemonServices.AddPokemon(vm);

            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Edit(int Id) {


            return View("CreatePokemon", await _pokemonServices.GetByIdEditPokemon(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddPokemonViewModel vm)
        {

            await _pokemonServices.UpdatePokemon(vm);

            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
    }
}
