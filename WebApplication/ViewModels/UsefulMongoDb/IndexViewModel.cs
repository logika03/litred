using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels.UsefulMongoDb
{
    public class IndexViewModel
    {
        public FilterViewModel Filter { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
