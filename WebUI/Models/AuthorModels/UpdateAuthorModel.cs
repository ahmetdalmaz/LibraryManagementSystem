namespace WebUI.Models.AuthorModels
{
    public class UpdateAuthorModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public bool AuthorState { get; set; }
    }
}
