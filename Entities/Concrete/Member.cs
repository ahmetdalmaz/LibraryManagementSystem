using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Member:IEntity
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPhoneNumber { get; set;}
        public bool MemberState { get; set; }

        public virtual ICollection<BookTransaction> BookTransactions { get; set; }

    }
}
