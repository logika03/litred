using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CopyrightHolder:EntityDescription
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
