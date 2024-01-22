using Business.Abstract;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public readonly IPersonService _personService;
        public readonly IExperienceService _experienceService;
        public readonly ISkillDetailsService _skillDetailsService;
        public readonly IServiceService _serviceService;
        public readonly IWorkCategoryService _workCategoryService;
        public readonly IPortfolioService _portfolioService;

        public HomeController(IPersonService personService, IExperienceService experienceService, ISkillDetailsService skillDetailsService, IServiceService serviceService, IWorkCategoryService workCategoryService, IPortfolioService portfolioService)
        {
            _personService = personService;
            _experienceService = experienceService;
            _skillDetailsService = skillDetailsService;
            _serviceService = serviceService;
            _workCategoryService = workCategoryService;
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            var personData = _personService.GetAll().Data[0];
            var experienceData = _experienceService.GetAll().Data;
            var skilldetailsData = _skillDetailsService.GetAll().Data;
            var serviceData= _serviceService.GetAll().Data;
            var workcategoryData= _workCategoryService.GetAll().Data;
            var portfolioData= _portfolioService.GetAll().Data;

            HomeViewModel homeViewModel = new()
            { 
                Person = personData,
                Experiences = experienceData,
                SkillDetails = skilldetailsData,
                Services=serviceData,
                WorkCategories=workcategoryData,
                Portfolio=portfolioData
            };


            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}