using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.BookTransactionModels;

namespace WebUI.Controllers
{
    public class BookTransactionController : Controller
    {
        private readonly IBookTransactionService _bookTransactionService;
        private readonly IMapper _mapper;
        private readonly IValidator<BookTransaction> _validator;


        public BookTransactionController(IBookTransactionService bookTransactionService, IMapper mapper, IValidator<BookTransaction> validator)
        {
            _bookTransactionService = bookTransactionService;
            _mapper = mapper;
            _validator = validator;
        }

        public IActionResult Index()
        {
            List<BookTransactionModel> model = _mapper.Map<List<BookTransactionModel>>(_bookTransactionService.GetBookTransactionDetails());
            return View(model);
        }
    }
}
