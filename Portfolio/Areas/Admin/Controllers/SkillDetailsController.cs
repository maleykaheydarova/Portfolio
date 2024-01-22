using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillDetailsController : Controller
    {
      
        private readonly ISkillDetailsService _skilldetailsService;
        private readonly ISkillService _skillService;
        public SkillDetailsController(ISkillDetailsService skilldetailsService, ISkillService skillService)
        {
            _skilldetailsService = skilldetailsService;
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            var result = _skilldetailsService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {

            ViewData["Skills"] = _skillService.GetAll().Data;
            return View();
        }
        [HttpPost]
        public IActionResult Add(SkillDetails skilldetails)
        {
            _skilldetailsService.Add(skilldetails);
            return Redirect("Index");
        }
        public IActionResult Edit(int id) 
        {
            ViewData["Skills"] = _skillService.GetAll().Data;
            var skilldetail= _skilldetailsService.GetById(id).Data;
            return View(skilldetail);
        }
        [HttpPost]
        public IActionResult Edit(SkillDetails skilldetails)
        {
            var existingSkillDetail=_skilldetailsService.GetById(skilldetails.ID).Data;
            existingSkillDetail.Skill = skilldetails.Skill;
            existingSkillDetail.Level= skilldetails.Level;
            existingSkillDetail.SkillID= skilldetails.SkillID;
            _skilldetailsService.Update(existingSkillDetail);
            return Redirect("Index");
        }
        public IActionResult Delete(int id) 
        {
            var skilldetails = _skilldetailsService.GetById(id).Data;
            skilldetails.Deleted = skilldetails.ID;
            _skilldetailsService.Update(skilldetails);
            return RedirectToAction("Index");
        }


    }
}
