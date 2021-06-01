using System.Collections.Generic;
using WebApplication.Models;
using WebApplication.ViewModels.Book;

namespace WebApplication.ViewModels
{
    public class UserBookPartialsViewModel
    {
        public string Id { get; set; }
        public string ReadingStatus { get; set; }
        public bool IsNone { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }

        public UserBookPartialsViewModel(string id, string readingStatus, bool isNone,
            IEnumerable<BookViewModel> books)
        {
            Id = id;
            ReadingStatus = readingStatus;
            IsNone = isNone;
            Books = books;
        }
    }
}
