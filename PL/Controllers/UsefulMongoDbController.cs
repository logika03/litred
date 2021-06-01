using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PL.ViewModels.UsefulMongoDb;

namespace PL.Controllers
{
    public class UsefulMongoDbController : Controller
    {
        private readonly ProductService db;

        public UsefulMongoDbController(ProductService context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(FilterViewModel filter)
        {
            var phones = await db.GetProducts(filter.MinPrice, filter.MaxPrice, filter.Name);
            var model = new IndexViewModel {Products = phones, Filter = filter};
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                await db.Create(p);
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await db.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
