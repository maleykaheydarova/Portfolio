using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        //    PositionManager _positionManager = new(new PositionEFDal());
        //    public IActionResult Index()
        //    {
        //        var experiences = _positionManager.GetAll();
        //        return View(experiences);
        //    }
        private readonly IPersonService _personService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PersonController(IPersonService personService, IPositionService positionService, IWebHostEnvironment webHostEnvironment)
        {
            _personService = personService;
            _positionService = positionService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var result = _personService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Persons"] = _positionService.GetAll().Data;   
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            string fileName = "";
            string download = "";
            fileName = Upload(person, fileName);
            download = Download(person, download);

            _personService.Add(person, fileName, download);
            return RedirectToAction("Index");

            //string fileName = Guid.NewGuid().ToString() + "_" + person.ImageFile.FileName;
            //string download = Guid.NewGuid().ToString() + "_" + person.CvFile.FileName;
            //if (person.ImageFile != null)
            //{
            //    string folder = "Image/";
            //    folder += fileName;
            //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            //    person.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            //}

           
            //if (person.CvFile != null)
            //{
            //    string folder = "Cv/";
            //    folder += download;
            //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            //    person.CvFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            //}
            //_personService.Add(person, fileName, download);

            ////return RedirectToAction("Index");

            //return Redirect("Index");

        }

        public IActionResult Edit(int id)
        {
            ViewData["Persons"] = _positionService.GetAll().Data;
            var person = _personService.GetById(id).Data;

            return View(person);
            //Position position = _positionService.GetById(id).Data;
            // return View(position);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            //_personService.Update(person);
            //return RedirectToAction("Index");
            //return RedirectToAction("Index");
            var exsistingProfile = _personService.GetById(person.ID).Data;
            string fileName = exsistingProfile.ImgPath;
            if (person.ImageFile == null)
            {
                person.ImgPath = exsistingProfile.ImgPath;
            }
            else
            {

                fileName = Upload(person, fileName);
            }
            string download = exsistingProfile.CVPath;
            if (person.CvFile == null)
            {
                person.CVPath = exsistingProfile.CVPath;
            }
            else
            {
                download = Download(person, download);
            }
            _personService.Update(person, fileName, download);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var person = _personService.GetById(id).Data;
            person.Deleted = person.ID;
            _personService.Update(person);
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //public IActionResult Delete(Position position)
        //{
        //    var data = _positionService.GetById(position.ID).Data;

        //    data.Deleted = data.ID;
        //    _positionService.Update(data);

        //    return RedirectToAction("Index");
        //}


        public string Upload(Person person, string filename)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + person.ImageFile.FileName;

            if (person.ImageFile != null)
            {
                string folder = "Image/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            return fileName;
        }

        public string Download(Person person, string filename)
        {
            string download = Guid.NewGuid().ToString() + "_" + person.CvFile.FileName;
            if (person.CvFile != null)
            {
                string folder = "CV/";
                folder += download;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.CvFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            return download;
        }
    }
}