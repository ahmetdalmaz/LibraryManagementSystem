using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.MemberModels;

namespace WebUI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        private readonly IValidator<Member> _validator;

        public MemberController(IMemberService memberService, IMapper mapper, IValidator<Member> validator)
        {
            _memberService = memberService;
            _mapper = mapper;
            _validator = validator;
        }

        public IActionResult Index()
        {
            List<MemberModel> memberModel = _mapper.Map<List<MemberModel>>(_memberService.GetAll());
            return View(memberModel);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateMemberModel model)
        {
            Member member = _mapper.Map<Member>(model);
            var result = _validator.Validate(member);
            if (result.IsValid)
            {
                _memberService.Add(member);
                return RedirectToAction("Index");
            }
            result.AddToModelState(ModelState);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            UpdateMemberModel model = _mapper.Map<UpdateMemberModel>(_memberService.GetById(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMemberModel model)
        {
            Member member = _mapper.Map<Member>(model);
            var result = _validator.Validate(member);
            if (result.IsValid)
            {
                _memberService.Update(member);
                return RedirectToAction("Index");
            }
            result.AddToModelState(ModelState);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Member member = _memberService.GetById(id);
            _memberService.Delete(member);
            return RedirectToAction("Index");
        }



    }
}
