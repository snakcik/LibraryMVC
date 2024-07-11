namespace LibraryMVC.Models.View
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public DateTime RealaseDate { get; set; }
        public string Keyword { get; set; }


    }
}
