using DAL.Entities;

namespace PL.ViewModels.Book
{
    public class BookViewModel
    {
        public DAL.Entities.Book Book { get; set; }
        public string ReadingStatus { get; set; }
        public string UserId { get; set; }
        public SubscriptionType UserSubscriptionType { get; set; }
        public string Username { get; set; }
    }
}
