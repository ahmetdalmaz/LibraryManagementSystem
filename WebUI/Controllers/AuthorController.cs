using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var authors = _authorService.GetAll();
            return View(authors);
        }

        public IActionResult Edit(int id)
        {
            Author author = _authorService.GetById(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            Author authorForUpdate = _authorService.GetById(author.AuthorId);
            authorForUpdate.AuthorState = author.AuthorState;
            authorForUpdate.AuthorName = author.AuthorName;
            authorForUpdate.AuthorSurname = author.AuthorSurname;

            _authorService.Update(authorForUpdate);
            return RedirectToAction("Index");
        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _authorService.Add(author);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int authorId)
        {
            _authorService.Delete(_authorService.GetById(authorId));
            return RedirectToAction("Index");
        }

    }
}
