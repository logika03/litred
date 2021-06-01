using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Translator:People
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
