using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BookDetailDto:IDto
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public bool BookState { get; set; }

        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }


    }
}
