using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBookDetails();
            return View(books);
        }

        public IActionResult Edit(int id)
        {
            Book book = _bookService.GetById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                Book bookForUpdate = _bookService.GetById(book.BookId);
                bookForUpdate.BookState = book.BookState;
                bookForUpdate.BookName = book.BookName;
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
            return View();
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
                return View("Add", book);
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
