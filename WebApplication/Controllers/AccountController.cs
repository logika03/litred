using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;
using WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApplication.ViewModels.Book;

namespace WebApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment _appEnvironment;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationContext db, IWebHostEnvironment appEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Home(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            UserViewModel model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImagePath = user.ImagePath
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImagePath = user.ImagePath
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var result = await _userManager.UpdateAsync(user);
                    if (model.Image != null)
                    {
                        string path = "/media/users/" + model.Image.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await model.Image.CopyToAsync(fileStream);
                            user.ImagePath = model.Image.FileName;
                            model.ImagePath = user.ImagePath;
                        }
                    }

                    user.FirstName = model.FirstName is null ? user.FirstName : model.FirstName;
                    user.LastName = model.LastName is null ? user.LastName : model.LastName;

                    _db.Users.Update(user);
                    await _db.SaveChangesAsync();


                    if (model.OldPassword == model.NewPassword)
                    {
                        ModelState.AddModelError(string.Empty, "Новый пароль не должен совпадать с текущим.");
                    }
                    else if (model.NewPassword != null)
                        result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }

            return View(model);
        }

        public IActionResult UserBooks(string id)
        {
            var userBooks = _db.ReaderDiaries
                .Include(r => r.ReadingStatus)
                .Include(r => r.Book)
                .ThenInclude(b => b.Authors)
                .Include(r => r.Book)
                .ThenInclude(b => b.SubscriptionType)
                .Include(r => r.User)
                .Where(rd => rd.User.Id == id)
                .ToList();

            var books = userBooks.Select(userBook =>
                    new BookViewModel
                    {
                        Book = userBook.Book,
                        ReadingStatus = userBook.ReadingStatus.Description
                    })
                .ToList();

            var model = new UserBooksViewModel
            {
                Books = books,
                UserId = id
            };
            return View(model);
        }
    }
}
