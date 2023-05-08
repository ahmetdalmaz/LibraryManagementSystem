using AutoMapper;
using Entities.Concrete;
using WebUI.Models.AuthorModels;

namespace WebUI.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorModel, Author>().ReverseMap();
            CreateMap<CreateAuthorModel, Author>().ReverseMap();
            CreateMap<UpdateAuthorModel, Author>().ReverseMap();
        }
    }
}
