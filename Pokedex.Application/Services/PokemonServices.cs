using Pokedex.Application.Repository;
using Pokedex.Application.ViewModel;
using Pokedex.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.Services
{
    public class PokemonServices
    {
        private readonly PokemonRepository _repository;
        public PokemonServices(ApplicationContext dbContext)
        {
            _repository = new(dbContext);
        }

        public async Task<List<PokemonViewModel>> GetPokemons() {
            var pokemonList = await _repository.GetPokemonsAsync();

            return pokemonList.Select(pokemon => new PokemonViewModel {
                Id=pokemon.Id,
                Name=pokemon.Name,
                PhotoUrl=pokemon.PhotoUrl,
                Color=pokemon.Color,
                RegionName=pokemon.Region.Name,
                FirstTypeName=pokemon.PrimaryType.Name,
                SecondTypeName=pokemon.SecondaryType.Name}).ToList();        
        }

    }
}
