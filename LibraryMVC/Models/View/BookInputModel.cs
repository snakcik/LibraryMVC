using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMVC.Models.View
{
    public class BookInputModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public DateTime RelaseDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string ImagePath { get; set; }

    }
}
