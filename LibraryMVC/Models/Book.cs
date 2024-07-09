using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public DateTime RealseDate { get; set; }

        public string? ImagePath { get; set; } = "nobook.jpg";
       [NotMapped]
        public IFormFile? Image { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        //NavProp
        public Category? Category { get; set; }        
        public Author? Author { get; set; }
    }
}
