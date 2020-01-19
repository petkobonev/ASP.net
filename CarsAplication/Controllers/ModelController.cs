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
    public class ModelController : Controller
    {

        private ModelsRepository repo = new ModelsRepository();
        private BrandRepository brandsRepo = new BrandRepository();

        public ActionResult Index()
        {
            var models = repo.GetAll();

            var modelViews = models.Select(model => new ModelViewModel(model.ID, model.Name, model.Brands)).ToList();

            return View(modelViews);
        }

        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            var brand = new CreateModelViewModel();
            var brands = brandsRepo.GetAll();

            ViewBag.Brands = new SelectList(brands, "ID", "Name");
            return View(brand);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(CreateModelViewModel modelView)
        {
            var model = new DataAccess.Model();
            model.Name = modelView.Name;
            model.Brand = modelView.Brand;
            repo.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            var brand = new ModelViewModel();
            brand.ID = id;

            var brands = brandsRepo.GetAll();

            ViewBag.Brands = new SelectList(brands, "ID", "Name");
            return View(brand);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(ModelViewModel modelView)
        {
            var brand = new DataAccess.Model();
            brand.Name = modelView.Name;
            brand.Brand = modelView.Brand.ID;
            brand.ID = modelView.ID;
            repo.Save(brand);

            return RedirectToAction("Index");
        }


        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            repo.DeleteByID(id);
            return RedirectToAction("Index");
        }
    }
}