using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class ReadingStatus : EntityDescription
    {
        public IEnumerable<ReaderDiary> ReaderDiaries { get; set; }
    }
}
