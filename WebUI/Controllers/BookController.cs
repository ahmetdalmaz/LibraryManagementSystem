using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.AuthorModels;
using WebUI.Models.BookModels;
using WebUI.Models.CategoryModels;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Book> _validator;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,IAuthorService authorService,ICategoryService categoryService, IValidator<Book> validator, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBookDetails();
            List<BookModel> model = _mapper.Map<List<BookModel>>(books);
            
            return View(model);
        }
        
        public IActionResult Edit(int id)
        {
            Book book = _bookService.GetById(id);
            UpdateBookModel model = _mapper.Map<UpdateBookModel>(book);
            model.Categories = _mapper.Map<List<CategoryModel>>(_categoryService.GetAll());
            model.Authors = _mapper.Map<List<AuthorModel>>(_authorService.GetAll());
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBookModel bookModel)
        {
            Book book = _mapper.Map<Book>(bookModel);
            var result = _validator.Validate(book);
            if (result.IsValid)
            {
                Book bookForUpdate = _bookService.GetById(bookModel.BookId);
                bookForUpdate = _mapper.Map<Book>(bookModel);
                _bookService.Update(bookForUpdate);
                return RedirectToAction("Index");
            }
            result.AddToModelState(ModelState);
            bookModel.Categories = _mapper.Map<List<CategoryModel>>(_categoryService.GetAll());
            bookModel.Authors = _mapper.Map<List<AuthorModel>>(_authorService.GetAll());
            return View(bookModel);
        }



        public IActionResult Add()
        {
            CreateBookModel model = new CreateBookModel() { 
                Categories = _mapper.Map<List<CategoryModel>>(_categoryService.GetAll()),
                Authors = _mapper.Map<List<AuthorModel>>(_authorService.GetAll()),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CreateBookModel bookModel)
        {
            Book book = _mapper.Map<Book>(bookModel);
            var result = _validator.Validate(book);

            if (result.IsValid)
            {
                _bookService.Add(book);
                return RedirectToAction("Index");
            }
            result.AddToModelState(ModelState);
            bookModel.Categories = _mapper.Map<List<CategoryModel>>(_categoryService.GetAll());
            bookModel.Authors = _mapper.Map<List<AuthorModel>>(_authorService.GetAll());
            return View(bookModel);
        }


        [HttpPost]
        public IActionResult Delete(int bookId)
        {
            _bookService.Delete(_bookService.GetById(bookId));
            return RedirectToAction("Index");
        }

    }
}
