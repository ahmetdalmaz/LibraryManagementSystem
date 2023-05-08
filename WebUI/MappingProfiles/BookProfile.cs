using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using WebUI.Models.BookModels;

namespace WebUI.MappingProfiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookModel, Book>().ReverseMap();
            CreateMap<BookModel,BookDetailDto>().ReverseMap();
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<UpdateBookModel, Book>().ReverseMap();
        }

    }
}
