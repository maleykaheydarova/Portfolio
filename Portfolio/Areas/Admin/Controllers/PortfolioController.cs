using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IWorkCategoryService _workcategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
       public PortfolioController(IPortfolioService portfolioService, IWorkCategoryService workcategoryService, IWebHostEnvironment webHostEnvironment)
        {
            _portfolioService = portfolioService;
            _workcategoryService = workcategoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var result = _portfolioService.GetAll().Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["WorkCategories"] = _workcategoryService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Portfoli portfoli)
        {
            string fileName = "";
         
            fileName = Upload(portfoli, fileName);

            _portfolioService.Add(portfoli, fileName);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewData["WorkCategories"] = _workcategoryService.GetAll().Data;
            var person = _portfolioService.GetById(id).Data;

            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Portfoli portfoli)
        {
            var exsistingProfile = _portfolioService.GetById(portfoli.ID).Data;
            string fileName = exsistingProfile.WorkImgPath;
            if (portfoli.WorkImageFile == null)
            {
                portfoli.WorkImageFile = exsistingProfile.WorkImageFile;
            }
            else
            {

                fileName = Upload(portfoli, fileName);
            }
            _portfolioService.Update(portfoli, fileName);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var portfolio = _portfolioService.GetById(id).Data;
            string filename=portfolio.WorkImgPath;
            portfolio.Deleted = portfolio.ID;
            _portfolioService.Update(portfolio,filename);
            return RedirectToAction("Index");
        }


        public string Upload(Portfoli portfoli, string filename)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + portfoli.WorkImageFile.FileName;

            if (portfoli.WorkImageFile != null)
            {
                string folder = "Image/WorkImage/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                portfoli.WorkImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            return fileName;
        }
    }
}
