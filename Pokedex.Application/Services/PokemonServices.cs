using Pokedex.Application.Repository;
using Pokedex.Application.ViewModel;
using Pokedex.Database;
using Pokedex.Database.Models;
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
        private readonly RegionServices _regionServices;
        private readonly TypeServices _typeServices;
        public PokemonServices(ApplicationContext dbContext)
        {
            _repository = new(dbContext);
            _regionServices = new(dbContext);
            _typeServices = new(dbContext);
        }

        public async Task AddPokemon(AddPokemonViewModel vm) {
            Pokemon pokemon = new() {
            Name=vm.Name,
            PhotoUrl=vm.PhotoUrl,
            Color=vm.Color,
            RegionId=vm.RegionId,
            PrimaryTypeId=vm.PrimaryTypeId,
            SecondaryTypeId = vm.SecondaryTypeId <= 0 ? vm.PrimaryTypeId : vm.SecondaryTypeId
            };

            await _repository.AddPokemonAsync(pokemon);
        }

        public async Task UpdatePokemon(AddPokemonViewModel vm)
        {
            Pokemon pokemon = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                PhotoUrl = vm.PhotoUrl,
                Color = vm.Color,
                RegionId = vm.RegionId,
                PrimaryTypeId = vm.PrimaryTypeId,
                SecondaryTypeId = vm.SecondaryTypeId <= 0 ? vm.PrimaryTypeId : vm.SecondaryTypeId
            };

            await _repository.UpdatePokemonAsync(pokemon);
        }

        public async Task<AddPokemonViewModel> GetByIdEditPokemon(int id) {

            var pokemon = await _repository.GetPokemonsById(id);

            AddPokemonViewModel vm = new()
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                PhotoUrl = pokemon.PhotoUrl,
                Color = pokemon.Color,
                RegionId = pokemon.RegionId,
                PrimaryTypeId = pokemon.PrimaryTypeId,
                SecondaryTypeId = pokemon.SecondaryTypeId,
                Region = _regionServices.RegionDrop(),
                Type = _typeServices.TypeDrop()
            };

            return vm;
        }

        public async Task DeletePokemon(int id) {

            var Pokemon = await _repository.GetPokemonsById(id);

            await _repository.DeletePokemonAsync(Pokemon);
        
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
                SecondTypeName=pokemon.SecondaryType.Name
            }).ToList();        
        }


        public async Task<List<PokemonViewModel>> GetPokemonByName(string name) { 
        
            var Pokemon = await _repository.GetPokemonByName(name);

            return Pokemon.Select(Pokemon=> new PokemonViewModel { 
            Id = Pokemon.Id,
            Name = Pokemon.Name,
            PhotoUrl = Pokemon.PhotoUrl,
            Color = Pokemon.Color,
            RegionName = Pokemon.Region.Name,
            FirstTypeName = Pokemon.PrimaryType.Name,
            SecondTypeName = Pokemon.SecondaryType.Name
            }).ToList();
        }

        public async Task<List<PokemonViewModel>> GetPokemonByRegion(int id)
        {

            var Pokemon = await _repository.GetPokemonByRegion(id);

            return Pokemon.Select(Pokemon => new PokemonViewModel
            {
                Id = Pokemon.Id,
                Name = Pokemon.Name,
                PhotoUrl = Pokemon.PhotoUrl,
                Color = Pokemon.Color,
                RegionName = Pokemon.Region.Name,
                FirstTypeName = Pokemon.PrimaryType.Name,
                SecondTypeName = Pokemon.SecondaryType.Name
            }).ToList();
        }
    }
}
