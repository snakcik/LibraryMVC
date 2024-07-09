namespace LibraryMVC.Models.View
{
    public class BookViewModel
    {
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public string CategoryName { get; set; }

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }


    }
}
