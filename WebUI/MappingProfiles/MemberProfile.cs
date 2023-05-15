using AutoMapper;
using Entities.Concrete;
using WebUI.Models.MemberModels;

namespace WebUI.MappingProfiles
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            CreateMap<MemberModel, Member>().ReverseMap();
            CreateMap<CreateMemberModel, Member>().ReverseMap();
            CreateMap<UpdateMemberModel, Member>().ReverseMap();
        }
    }
}
