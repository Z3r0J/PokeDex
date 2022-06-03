using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task AddRegion(RegionViewModel vm) {

            Region region = new() {
            Id = vm.RegionId,
            Name = vm.Name
            };

            await _repository.AddRegionAsync(region);
        }

        public async Task<List<RegionViewModel>> GetRegions()
        {

            var regionList = await _repository.GetRegionsAsync();

            return regionList
                .Select(region => new RegionViewModel { RegionId = region.Id, Name = region.Name })
                .ToList();
        }

        public async Task<RegionViewModel> GetRegionById(int id) {

            var region = await _repository.GetRegionsById(id);

            return new() { RegionId = region.Id, Name = region.Name };
        }

        public async Task UpdateRegion(RegionViewModel vm) {

            Region region = new()
            {
                Id = vm.RegionId,
                Name = vm.Name
            };

            await _repository.UpdateRegionAsync(region);

        }

        public async Task DeleteRegion(int id) {

            var region = await _repository.GetRegionsById(id);

            await _repository.DeleteRegionAsync(region);
        }


    }
}
