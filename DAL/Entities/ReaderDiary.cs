namespace DAL.Entities
{
    public class ReaderDiary
    {
        public string Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
    }
}
