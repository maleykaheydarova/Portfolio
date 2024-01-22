using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public IActionResult Index()
        {
            var result = _serviceService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Service service)
        {
            _serviceService.Add(service);
            return Redirect("Index");
        }
        public IActionResult Edit(int id)
        {
            var position = _serviceService.GetById(id).Data;

            return View(position);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            var existingService = _serviceService.GetById(service.ID).Data;
            existingService.Title = service.Title;
            existingService.IconName = service.IconName;
            existingService.ShownOnPage = service.ShownOnPage;
            _serviceService.Update(existingService);
            return Redirect("Index");
        }
        public IActionResult Delete(int id)
        {
            var service = _serviceService.GetById(id).Data;
            service.Deleted = service.ID;
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }
    }
}
