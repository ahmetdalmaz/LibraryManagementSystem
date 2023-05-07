using AutoMapper;
using Entities.Concrete;
using WebUI.Models;

namespace WebUI.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorModel, Author>().ReverseMap();
        }
    }
}
