using AutoMapper;
using Entities.Concrete;
using WebUI.Models;

namespace WebUI.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
        }

    }
}
