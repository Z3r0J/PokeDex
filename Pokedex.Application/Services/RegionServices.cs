using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Application.Repository;
using Pokedex.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.Services
{
    public class RegionServices
    {
        private readonly RegionRepository _repository;
        public RegionServices(ApplicationContext dbContext)
        {
            _repository = new(dbContext);
        }

        public SelectList RegionDrop() {

            return _repository.RegionDropDown();
        }
    }
}
