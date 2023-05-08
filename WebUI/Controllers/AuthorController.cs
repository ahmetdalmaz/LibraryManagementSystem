using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.AuthorModels;

namespace WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IValidator<Author> _validator;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IValidator<Author> validator, IMapper mapper)
        {
            _authorService = authorService;
            _validator = validator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var authors = _authorService.GetAll();
            var authorModel = _mapper.Map<List<AuthorModel>>(authors);
            return View(authorModel);
        }

        public IActionResult Edit(int id)
        {
            Author author = _authorService.GetById(id);
            UpdateAuthorModel model = _mapper.Map<UpdateAuthorModel>(author);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateAuthorModel model)
        {
            Author author = _mapper.Map<Author>(model);
            var result = _validator.Validate(author);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(model);
            }
            Author authorForUpdate = _authorService.GetById(model.AuthorId);
            authorForUpdate = _mapper.Map<Author>(model);
            _authorService.Update(authorForUpdate);
            return RedirectToAction("Index");

        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateAuthorModel model)
        {
            Author author = _mapper.Map<Author>(model);

            var result = _validator.Validate(author);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(model);
            }
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
