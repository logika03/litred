using System.IO;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApplication.Enums;
using WebApplication.ViewModels.Book;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;

        public BookController(UserManager<User> userManager, ApplicationContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Book(string id)
        {
            var userId = _userManager.GetUserId(User);
            var book = _db.Books.Include(b => b.Authors)
                .Include(b => b.Translators)
                .Include(b => b.CopyrightHolders)
                .Include(b => b.SubscriptionType)
                .Include(b => b.Genres)
                .Include(b => b.Themes)
                .Include(b => b.Reviews)
                .Include(b => b.ReaderDiaries.Where(rd => rd.Book.Id == id && rd.User.Id == userId))
                .ThenInclude(rd => rd.ReadingStatus)
                .Include(b=>b.Reviews)
                .ThenInclude(r=>r.Author)
                .FirstOrDefault(b => b.Id == id);
            if (book is null || book.ReaderDiaries.Count() > 1)
                return NotFound();
            var readingStatus = book.ReaderDiaries.FirstOrDefault()?.ReadingStatus.Description;
            User user = null;
            if (User.Identity != null && User.Identity.IsAuthenticated)
                user = _db.User
                    .Where(u => u.Id == userId)
                    .Include(u => u.Subscriptions)
                    .ThenInclude(s => s.SubscriptionStatus)
                    .Include(u => u.Subscriptions
                        .Where(s => s.SubscriptionStatus.Description == SubscriptionStatusEnums.Current))
                    .ThenInclude(s => s.SubscriptionType)
                    .FirstOrDefault();
            var userSubscriptionType = user != null
                ? user.Subscriptions.FirstOrDefault()?.SubscriptionType
                : _db.SubscriptionTypes
                    .FirstOrDefault(st => st.Description == SubscriptionTypeEnums.Free);
            var username = _userManager.GetUserName(User);
            var model = new BookViewModel
            {
                Book = book,
                ReadingStatus = readingStatus,
                UserId = userId,
                UserSubscriptionType = userSubscriptionType,
                Username = username
            };
            return View(model);
        }

        public IActionResult TextBook(string id)
        {
            var stream = new FileStream(@"C:\Users\user\Desktop\trash\англ\Head_First_Java_2nd_Edition.pdf",
                FileMode.Open);
            return File(stream, "application/pdf");
        }
    }
}
