using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task AddType(AddTypeViewModel vm) {

            Database.Models.Type type = new() {Id=vm.TypeId,Name=vm.Name };

            await _repository.AddTypeAsync(type);

        }

        public async Task<List<TypeViewModel>> GetTypes() { 
        
        var types = await _repository.GetTypesAsync();

            return types.Select(type => new TypeViewModel { TypeId = type.Id, Name = type.Name }).ToList();

        }

        public async Task<AddTypeViewModel> GetTypeById(int Id) {

            var types = await _repository.GetTypeByIdAsync(Id);

            return new() { TypeId=types.Id,Name=types.Name};

        }

        public async Task UpdateType(AddTypeViewModel vm) {

            Database.Models.Type type = new() { Id = vm.TypeId, Name = vm.Name };

            await _repository.UpdateTypeAsync(type);
        
        }

        public async Task DeleteType(int Id) {
            
            var type = await _repository.GetTypeByIdAsync(Id);

            await _repository.DeleteTypeAsync(type);
        
        }
    }
}
