using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

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
            BookModel model = new BookModel()
            {
             
                Authors = _authorService.GetAll(),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                Book bookForUpdate = _bookService.GetById(book.BookId);
                bookForUpdate.BookState = book.BookState;
                bookForUpdate.BookName = book.BookName;
                bookForUpdate.AuthorId = book.AuthorId;
                bookForUpdate.CategoryId = book.CategoryId;
                bookForUpdate.PageCount = book.PageCount;
                _bookService.Update(bookForUpdate);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", book);
            }

        }



        public IActionResult Add()
        {
            BookModel bookDetailListViewModel = new BookModel() { Authors = _authorService.GetAll(), Categories = _categoryService.GetAll()};
            return View(bookDetailListViewModel);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(book);
  
                return RedirectToAction("Index");
            }
            else
            {
                return View(new BookModel {
                    Authors = _authorService.GetAll(),
                    Categories = _categoryService.GetAll()
                });
            }
        }


        [HttpPost]
        public IActionResult Delete(int bookId)
        {
            _bookService.Delete(_bookService.GetById(bookId));
            return RedirectToAction("Index");
        }

    }
}
