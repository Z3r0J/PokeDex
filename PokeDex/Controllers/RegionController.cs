using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.Services;
using Pokedex.Application.ViewModel;
using Pokedex.Database;
using System.Threading.Tasks;

namespace PokeDex.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionServices _services;

        public RegionController(ApplicationContext dbContext)
        {
            _services = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {

            return View(await _services.GetRegions());
        }

        public IActionResult Create()
        {
            return View("CreateRegion", new AddRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRegionViewModel vm) {

            if (!ModelState.IsValid)
            {
                return View("CreateRegion",vm);
            }

            await _services.AddRegion(vm);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id) {

            return View("CreateRegion", await _services.GetRegionById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddRegionViewModel vm) {

            if (!ModelState.IsValid)
            {
                return View("CreateRegion",vm);
            }

            await _services.UpdateRegion(vm);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int Id)
        {

            return View(await _services.GetRegionById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id) {

            await _services.DeleteRegion(Id);

            return RedirectToAction("Index");
        }
    }
}
