using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ReadingStatus : EntityDescription
    {
        public IEnumerable<ReaderDiary> ReaderDiaries { get; set; }
    }
}
