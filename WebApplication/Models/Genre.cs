using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Genre:EntityDescription
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
