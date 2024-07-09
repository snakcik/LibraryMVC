using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorInfo { get; set; }
        public ICollection<Book> Books { get; set; }

        [NotMapped]
        public string FullName { get => AuthorName + " " + AuthorLastName; } 
    }
}
