using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class RegionRepository
    {
        private readonly ApplicationContext _dbContext;
        public RegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SelectList RegionDropDown() {

            return new SelectList(_dbContext.Set<Region>().ToList(), "Id", "Name");
        }

        public async Task AddRegionAsync(Region region) {

            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        
        }

        public async Task<List<Region>> GetRegionsAsync()
        {

            return await _dbContext.Set<Region>().ToListAsync();
        }

        public async Task<Region> GetRegionsById(int Id)
        {

            return await _dbContext.Set<Region>().FindAsync(Id);
        }


        public async Task UpdateRegionAsync(Region region) {

            _dbContext.Entry(region).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRegionAsync(Region region) {

            _dbContext.Set<Region>().Remove(region);

            await _dbContext.SaveChangesAsync();
        
        }
    }
}
