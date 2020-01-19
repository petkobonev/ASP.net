using CarsAplication.Helpers;
using CarsAplication.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsAplication.Controllers
{
    public class CarController : Controller
    {
        // GET: Car

        private CarsRepository repo = new CarsRepository();
        private ModelsRepository modelsRepo = new ModelsRepository();
        

        public ActionResult Index()
        {
            var cars = repo.GetAll();

            var carViews = cars.Select(car => new CarViewModel(car.ID, car.HorsePower, car.Color, car.Year, car.Models,
                new OwnerViewModel(car.User))).ToList();

            return View(carViews);
        }

        public ActionResult UserCars()
        {
            var cars = repo.GetByUserId(LoginSession.Current.UserID);

            var carViews = cars.Select(car => new CarViewModel(car.ID, car.HorsePower, car.Color, car.Year, car.Models,
                new OwnerViewModel(car.User))).ToList();

            return View(carViews);
        }

        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            var car = new CreateCarViewModel();

            car.Owner = LoginSession.Current.UserID;
            
            var models = modelsRepo.GetAll();

            ViewBag.Models = new SelectList(models, "ID", "Name");

            return View(car);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(CreateCarViewModel modelView)
        {
            var model = new DataAccess.Car();
            model.Color = modelView.Color;
            model.Year = modelView.Year;
            model.Owner = modelView.Owner;
            model.Model = modelView.Model;
            model.HorsePower = modelView.HorsePower;

            repo.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            var dbCar = repo.GetByID(id);

            if (dbCar.Owner != LoginSession.Current.UserID) return RedirectToAction("Car", "UserCars");
            var car = new CarViewModel();
            car.ID = id;

            var models = modelsRepo.GetAll();

            ViewBag.Models = new SelectList(models, "ID", "Name");

            return View(car);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(CarViewModel modelView)
        {
            var car = new DataAccess.Car();
            car.ID = modelView.ID;
            car.Color = modelView.Color;
            car.HorsePower = modelView.HorsePower;
            car.Model = modelView.Model.ID;
            car.Owner = LoginSession.Current.UserID;
            car.Year = modelView.Year;

            repo.Save(car);

            return RedirectToAction("Index");
        }


        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            var dbCar = repo.GetByID(id);

            if (dbCar.Owner != LoginSession.Current.UserID) return RedirectToAction("Car", "UserCars");

            repo.DeleteByID(id);
            return RedirectToAction("Index");
        }
    }
}