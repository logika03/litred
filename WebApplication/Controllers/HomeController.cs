using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // private Configurations _configuration;
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager)//, Configurations configuration)
        {
            _userManager = userManager;
            // _configuration = configuration;
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
