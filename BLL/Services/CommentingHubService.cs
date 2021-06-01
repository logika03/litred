using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Services
{
    public class CommentingHubService : Hub
    {
        private readonly ApplicationContext _db;

        public CommentingHubService(ApplicationContext db)
        {
            _db = db;
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
