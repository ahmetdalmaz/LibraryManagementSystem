using WebUI.Models.BookModels;
using WebUI.Models.MemberModels;

namespace WebUI.Models.BookTransactionModels
{
    public class UpdateBookTransactionModel
    {
        public int BookTransactionId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public List<MemberModel> Members { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
