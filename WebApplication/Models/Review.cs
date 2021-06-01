using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Review
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public User Author { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }
        public Book Book { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.Date;
}
}
