using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }

    }
}
