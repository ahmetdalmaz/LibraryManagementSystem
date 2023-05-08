using Entities.Concrete;
using Entities.DTOs;

namespace WebUI.Models.BookModels
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public bool BookState { get; set; }

    }
}
