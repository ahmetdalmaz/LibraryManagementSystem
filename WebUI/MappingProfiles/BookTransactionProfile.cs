using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using WebUI.Models.BookTransactionModels;

namespace WebUI.MappingProfiles
{
    public class BookTransactionProfile:Profile
    {
        public BookTransactionProfile()
        {
            CreateMap<BookTransactionModel, BookTransaction>().ReverseMap();
            CreateMap<BookTransactionModel, BookTransactionDto>().ReverseMap();
            CreateMap<CreateBookTransactionModel, BookTransaction>().ReverseMap();
            CreateMap<UpdateBookTransactionModel, BookTransaction>().ReverseMap();
        }
    }
}
