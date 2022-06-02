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


    }
}
