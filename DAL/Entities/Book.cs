using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Enums;

namespace DAL.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublicationYear { get; set; }
        public string Rating { get; set; }
        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<Translator> Translators { get; set; }
        public IEnumerable<CopyrightHolder> CopyrightHolders { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Theme> Themes { get; set; }
        public string BookCover { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<ReaderDiary> ReaderDiaries { get; set; }
    }
}
