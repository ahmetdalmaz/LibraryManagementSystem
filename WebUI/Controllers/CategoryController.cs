using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

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
            
            return View(new CategoryListViewModel { Categories = categories});
        }

        public IActionResult Edit(int id)
        {
            Category category = _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category categoryForUpdate = _categoryService.GetById(category.CategoryId);
            categoryForUpdate.CategoryState = category.CategoryState;
            categoryForUpdate.CategoryName = category.CategoryName;
            _categoryService.Update(categoryForUpdate);
            return RedirectToAction("Index");
        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add",category);
            }
            
        }

        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            _categoryService.Delete(_categoryService.GetById(categoryId));
            return RedirectToAction("Index");
        }
    }
}
