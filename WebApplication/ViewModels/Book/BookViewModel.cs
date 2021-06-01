using WebApplication.Models;

namespace WebApplication.ViewModels.Book
{
    public class BookViewModel
    {
        public  Models.Book Book { get; set; }
        public string ReadingStatus { get; set; }
        public string UserId { get; set; }
        public SubscriptionType UserSubscriptionType { get; set; }
        public string Username { get; set; }
    }
}
