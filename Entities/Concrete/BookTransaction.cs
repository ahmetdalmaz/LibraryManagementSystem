using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookTransaction:IEntity
    {
        public int BookTransactionId { get; set; }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public virtual Member Member { get; set; }
        public int MemberId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
