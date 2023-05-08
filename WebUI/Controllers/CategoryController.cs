using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.CategoryModels;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;
        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper)
        {
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            var categoryModel = _mapper.Map<List<CategoryModel>>(categories);
            return View(categoryModel);
        }

        public IActionResult Edit(int id)
        {
            Category category = _categoryService.GetById(id);
            UpdateCategoryModel model = _mapper.Map<UpdateCategoryModel>(category);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryModel categoryModel)
        {
            Category category = _mapper.Map<Category>(categoryModel);
            var result = _validator.Validate(category);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return View(categoryModel);

            }
            Category categoryForUpdate = _categoryService.GetById(categoryModel.CategoryId);
            categoryForUpdate = _mapper.Map<Category>(categoryModel);
            _categoryService.Update(categoryForUpdate);
            return RedirectToAction("Index");
        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCategoryModel categoryModel)
        {
            Category category = _mapper.Map<Category>(categoryModel);
            var result = _validator.Validate(category);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return View(categoryModel);
                
            }
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
