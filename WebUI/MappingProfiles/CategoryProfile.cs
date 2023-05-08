using AutoMapper;
using Entities.Concrete;
using WebUI.Models.CategoryModels;

namespace WebUI.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<CreateCategoryModel, Category>().ReverseMap();
            CreateMap<UpdateCategoryModel, Category>().ReverseMap();
        }

    }
}
