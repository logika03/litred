using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Author:People
    {
        public string Biography { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
