using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Add(Category category) 
        {
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            _categoryService.Delete(_categoryService.GetById(categoryId));
            return RedirectToAction("Index");
        }
    }
}
