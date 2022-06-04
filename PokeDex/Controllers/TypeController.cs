using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.Services;
using Pokedex.Application.ViewModel;
using Pokedex.Database;
using System.Threading.Tasks;

namespace PokeDex.Controllers
{
    public class TypeController : Controller
    {
        private readonly TypeServices _services;

        public TypeController(ApplicationContext dbContext)
        {
            _services = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {

            return View(await _services.GetTypes());
        }

        public IActionResult Create()
        {
            return View("CreateType", new AddTypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddTypeViewModel vm) {

            if (!ModelState.IsValid)
            {
                return View("CreateType",vm);
            }

            await _services.AddType(vm);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id) {

            return View("CreateType", await _services.GetTypeById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddTypeViewModel vm) {

            if (!ModelState.IsValid)
            {
                return View("CreateType",vm);
            }

            await _services.UpdateType(vm);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int Id)
        {

            return View(await _services.GetTypeById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int TypeId) {

            await _services.DeleteType(TypeId);

            return RedirectToAction("Index");
        }
    }
}
