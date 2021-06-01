using System.Collections.Generic;

namespace PL.ViewModels.Book
{
    public class UserBooksViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
        public IEnumerable<string> ReadingStatus { get; set; }
        public string UserId { get; set; }
    }
}
