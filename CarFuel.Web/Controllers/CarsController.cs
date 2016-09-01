using CarFuel.Models;
using CarFuel.Services.Bases;
using CarFuel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity; // + 
using CarFuel.Services;

namespace CarFuel.Web.Controllers {
  public class CarsController : AppControllerBase {

    private readonly ICarService _carService;

    public CarsController(ICarService carService,
                          IUserService userService)
      : base(userService) {
      _carService = carService;
    }

    public ActionResult Index() {
      if (User.Identity.IsAuthenticated) { 
        var cars = _carService.All();

        ViewBag.AppUser = _userService.CurrentUser;

        return View("IndexForMember", cars);
      }
      else { 
        return View("IndexForAnonymous");
      }
    }

    public ActionResult Add() {
      return View();
    }

    [HttpPost]
    public ActionResult Add(Car item) {
      ModelState.Remove("Owner");

      if (ModelState.IsValid) {

        User u = _userService.Find(new Guid(User.Identity.GetUserId()));
        item.Owner = u;

        _carService.Add(item);
        _carService.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(item);
    }

    public ActionResult AddFillUp(Guid id) {
      var q = (from c in _carService.All()
               where c.Id == id
               select c.Name);

      var name = q.SingleOrDefault();

      ViewBag.CarName = name;
      return View();
    }

    [HttpPost]
    public ActionResult AddFillUp(Guid id,
                                //  [Bind(Exclude = "Id")]
                                FillUp item) {
      ModelState.Remove("Id");

      if (ModelState.IsValid) {

        var c = _carService.Find(id);
        //db.Entry(c).Collection(x => x.FillUps).Load(); // Manual Load
        c.AddFillUp(item.Odometer, item.Liters);
        _carService.SaveChanges();

        return RedirectToAction("Index");
      }
      return View(item);
    }
  }
}