using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.Repository
{
    public class TypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public TypeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SelectList TypeDropDown() {

            return new SelectList(_dbContext.Set<Database.Models.Type>().ToList(), "Id", "Name");
        }

        public async Task AddTypeAsync(Database.Models.Type type) {

            await _dbContext.Types.AddAsync(type);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Database.Models.Type>> GetTypesAsync(){

            return await _dbContext.Set<Database.Models.Type>().ToListAsync();

        }

        public async Task<Database.Models.Type> GetTypeByIdAsync(int Id) {

            return await _dbContext.Set<Database.Models.Type>().FindAsync(Id);

        }

        public async Task UpdateTypeAsync(Database.Models.Type type) {

            _dbContext.Entry(type).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        
        }

        public async Task DeleteTypeAsync(Database.Models.Type type) {

            _dbContext.Set<Database.Models.Type>().Remove(type);

            await _dbContext.SaveChangesAsync();

        }
    }
}
