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

        public HomeController(IPersonService personService)
        {
           _personService= personService;
        }

        public IActionResult Index()
        {
            var personData = _personService.GetAll().Data[0];

            HomeViewModel homeViewModel = new()
            {
                Person = personData
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