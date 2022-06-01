using Microsoft.EntityFrameworkCore;
using Pokedex.Database;
using Pokedex.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.Repository
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;
        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPokemonAsync(Pokemon pokemon) { 

            await _dbContext.Pokemons.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }        
        public async Task UpdatePokemonAsync(Pokemon pokemon) {

            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }        
        public async Task DeletePokemonAsync(Pokemon pokemon) {

            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetPokemonsAsync() {

            return await _dbContext.Set<Pokemon>()
                .Include(pokemon => pokemon.Region)
                .Include(pokemon => pokemon.PrimaryType)
                .Include(pokemon => pokemon.SecondaryType)
                .ToListAsync();
        }
        public async Task<Pokemon> GetPokemonsById(int id) {

            return await _dbContext.Set<Pokemon>().FindAsync(id);
                
        }



    }
}
