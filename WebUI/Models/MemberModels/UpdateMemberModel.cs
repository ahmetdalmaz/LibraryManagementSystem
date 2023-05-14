namespace WebUI.Models.MemberModels
{
    public class UpdateMemberModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPhoneNumber { get; set; }
        public bool MemberState { get; set; }
    }
}
