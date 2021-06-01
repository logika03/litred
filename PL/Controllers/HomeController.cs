using System.Diagnostics;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels.Home;
using PL.ViewModels.User;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity is null)
                return NotFound();
            UserViewModel user = User.Identity.IsAuthenticated
                ? new UserViewModel {Id = _userManager.GetUserId(User)}
                : null;

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [Authorize]
        public IActionResult GetNavbar()
        {
            UserViewModel model = new UserViewModel
            {
                Id = _userManager.GetUserId(User)
            };
            return PartialView(model.Id);
        }

        public IActionResult Map()
        {
            // ViewData["MapKey"] = "AIzaSyByCBmQb4_fJn36Ca6At3fI5Lsid25l0wY";// _configuration.MapKey;
            return View();
        }
    }
}
