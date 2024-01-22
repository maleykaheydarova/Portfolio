using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkCategoryController : Controller
    {
        public readonly IWorkCategoryService _workcategoryService;
        public WorkCategoryController(IWorkCategoryService workcategoryService)
        {
            _workcategoryService = workcategoryService;
        }
        public IActionResult Index()
        {
            var result=_workcategoryService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(WorkCategory workcategory)
        {
            _workcategoryService.Add(workcategory);
            return Redirect("Index");
        }
        public IActionResult Edit(int id)
        {
            var workcategory = _workcategoryService.GetById(id).Data;
            return View(workcategory);
        }
        [HttpPost]
        public IActionResult Edit(WorkCategory workcategory)
        {
            var existingworkcategory = _workcategoryService.GetById(workcategory.ID).Data;
            existingworkcategory.Name=workcategory.Name;
            _workcategoryService.Update(existingworkcategory);
            return Redirect("Index");
        }
        public IActionResult Delete(int id) 
        {
            var workcategory = _workcategoryService.GetById(id).Data;
            workcategory.Deleted = workcategory.ID;
            _workcategoryService.Update(workcategory);
            return RedirectToAction("Index");
        }
    }
}
