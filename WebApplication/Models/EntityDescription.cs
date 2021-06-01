using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class EntityDescription
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
