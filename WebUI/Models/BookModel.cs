using Entities.Concrete;
using Entities.DTOs;

namespace WebUI.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public bool BookState { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }

    }
}
