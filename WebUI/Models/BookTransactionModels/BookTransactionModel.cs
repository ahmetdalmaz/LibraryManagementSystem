namespace WebUI.Models.BookTransactionModels
{
    public class BookTransactionModel
    {
        public int BookTransactionId { get; set; }
        public string BookName { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberEmail { get; set; }
        public string ISBN { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
