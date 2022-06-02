using Microsoft.AspNetCore.Mvc.Rendering;
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
    }
}
