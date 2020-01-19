using CarsAplication.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsAplication.Controllers
{
    public class BrandController : Controller
    {
        private BrandRepository repo = new BrandRepository();

        // GET: Brand
        public ActionResult Index()
        {
            var brands = repo.GetAll();

            var brandModel = brands.Select(brand => new BrandViewModel(brand)).ToList();

            return View(brandModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var brand = new CreateBrandViewModel();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Create(CreateBrandViewModel model)
        {
            var brand = new DataAccess.Brand();
            brand.Name = model.Name;
            brand.Country = model.Country;
            repo.Create(brand);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var brand = new BrandViewModel();
            brand.ID = id;
            return View(brand);


        }

        [HttpPost]
        public ActionResult Edit(BrandViewModel model)
        {
            var brand = new DataAccess.Brand();
            brand.Name = model.Name;
            brand.Country = model.Country;
            brand.ID = model.ID;
            repo.Save(brand);

            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            repo.DeleteByID(id);
            return RedirectToAction("Index");
        }
    }
}