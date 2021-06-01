using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> User { get; set; }
        IRepository<Book> Books { get; set; }
        IRepository<Author> Authors { get; set; }
        IRepository<CopyrightHolder> CopyrightHolders { get; set; }
        IRepository<FAQ> FAQs { get; set; }
        IRepository<Genre> Genres { get; set; }
        IRepository<Review> Reviews { get; set; }
        IRepository<Theme> Themes { get; set; }
        IRepository<Translator> Translators { get; set; }
        IRepository<ReaderDiary> ReaderDiaries { get; set; }
        IRepository<SubscriptionType> SubscriptionTypes { get; set; }
        IRepository<ReadingStatus> ReadingStatuses { get; set; }
        IRepository<SubscriptionStatus> SubscriptionStatuses { get; set; }
        IRepository<Subscription> Subscriptions { get; set; }
        void Save();
    }
}
