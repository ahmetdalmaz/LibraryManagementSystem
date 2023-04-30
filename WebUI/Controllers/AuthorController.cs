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

        [HttpPost]
        public IActionResult Delete(int authorId)
        {
            _authorService.Delete(_authorService.GetById(authorId));
            return RedirectToAction("Index");
        }

    }
}
