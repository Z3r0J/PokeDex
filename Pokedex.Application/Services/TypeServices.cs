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
    public class TypeServices
    {
        private readonly TypeRepository _repository;

        public TypeServices(ApplicationContext dbContext)
        {
            _repository = new TypeRepository(dbContext);
        }

        public SelectList TypeDrop() {

            return _repository.TypeDropDown();
        }
    }
}
