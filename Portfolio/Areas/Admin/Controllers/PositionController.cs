﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
    //    PositionManager _positionManager = new(new PositionEFDal());
    //    public IActionResult Index()
    //    {
    //        var experiences = _positionManager.GetAll();
    //        return View(experiences);
    //    }
        private readonly IPositionService _positionService;
    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }
    public IActionResult Index()
    {
        var result = _positionService.GetAll().Data;
        return View(result);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Position position)
    {
        _positionService.Add(position);

        //return RedirectToAction("Index");

        return Redirect("Index");

    }

    public IActionResult Edit(int id)
    {
        var position = _positionService.GetById(id).Data;

        return View(position);
        //Position position = _positionService.GetById(id).Data;
        // return View(position);
    }

    [HttpPost]
    public IActionResult Edit(Position position)
    {
        _positionService.Update(position);
        //return RedirectToAction("Index");
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var position = _positionService.GetById(id).Data;
        position.Deleted = position.ID;
        _positionService.Update(position);
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
}
}
