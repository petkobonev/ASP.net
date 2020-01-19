using CarsAplication.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using CarsAplication.Helpers;

namespace CarsAplication.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (LoginSession.Current.IsAuthenticated) return RedirectToAction("Index", "Home");
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUserByNameAndPassword(model.Username, model.Password);
            if (user != null)
            {
                LoginSession.Current.SetCurrentUser(user.ID, user.Username, user.Name);
                return RedirectToAction("Index", "Home");
            }
            return Login();
        }
        [HttpGet]
        public ActionResult Register()
        {

            if (LoginSession.Current.IsAuthenticated) return RedirectToAction("Index", "Home");
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUserByName(model.Username);
            if (user == null)
            {
                user = new User();
                user.Username = model.Username;
                user.Name = model.Name;
                repo.RegisterUser(user, model.Password);
                LoginSession.Current.SetCurrentUser(user.ID, user.Username, user.Name);

                
                return RedirectToAction("Index", "Home");

            }
            return Register();
        }

        [CustomAuthorize]
        public ActionResult Logout()
        {
            LoginSession.Current.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}