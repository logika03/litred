using System.Collections.Generic;
using DAL.Entities;

namespace PL.ViewModels.UsefulMongoDb
{
    public class IndexViewModel
    {
        public FilterViewModel Filter { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
