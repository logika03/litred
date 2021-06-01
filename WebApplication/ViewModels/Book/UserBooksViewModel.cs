using System.Collections.Generic;
using WebApplication.Models;
using WebApplication.ViewModels.Book;

namespace WebApplication.ViewModels
{
    public class UserBooksViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
        public IEnumerable<string> ReadingStatus { get; set; }
        public string UserId { get; set; }
    }
}
