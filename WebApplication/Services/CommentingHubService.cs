using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Services
{
    public class CommentingHubService : Hub
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;

        public CommentingHubService(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task Send(string message, string rating, string bookId, string userName, bool addDb)
        {
            if (addDb)
            {
                AddReviewDb(message, rating, bookId, userName);
            }

            await Clients.All.SendAsync("Send", message, userName);
        }

        private void AddReviewDb(string message, string rating, string bookId, string userName)
        {
            var author = _db.User.FirstOrDefault(u => u.UserName == userName);
            var book = _db.Books.FirstOrDefault(b => b.Id == bookId);
            var review = new Review
            {
                Author = author,
                Book = book,
                Description = message,
                Rating = Convert.ToInt32(rating)
            };
             _db.Reviews.Add(review);
             _db.SaveChanges();
        }
    }
}
