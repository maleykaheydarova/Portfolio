using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IPositionService _positionService;
        public ExperienceController(IPositionService positionService, IExperienceService experienceService)
        {
            _positionService = positionService;
            _experienceService = experienceService;
        }
        public IActionResult Index()
        {
            var result = _experienceService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Experience experience)
        {
            _experienceService.Add(experience);

            //return RedirectToAction("Index");

            return Redirect("Index");

        }

        public IActionResult Edit(int id)
        {
            var experience = _experienceService.GetById(id).Data;
            ViewData["Positions"] = _positionService.GetAll().Data;

            return View(experience);
            //Position position = _positionService.GetById(id).Data;
            // return View(position);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            _experienceService.Update(experience);
            //return RedirectToAction("Index");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var experience = _experienceService.GetById(id).Data;
            experience.Deleted = experience.ID;
            _experienceService.Update(experience);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(Experience experience)
        {
            var data = _experienceService.GetById(experience.ID).Data;

            data.Deleted = data.ID;
            _experienceService.Update(data);
            return RedirectToAction("Index");
        }
    }
}

