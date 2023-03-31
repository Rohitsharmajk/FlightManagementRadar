using FlightManagementRadar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManagementRadar.Controllers
{
   
    public class AccountController : Controller
    {
        FlightManagementContext ctx = new FlightManagementContext();
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User_Details u)
        {
            if (ModelState.IsValid)
            {
                bool IsValid = ctx.User_Details.Any(usr => usr.username == u.username && usr.password == u.password);

                if (IsValid)
                {
                    ViewBag.un = u.username;
                    return RedirectToAction("Index", "Home");
                    //return View("ViewInput");
                }

            }
            ModelState.AddModelError("", "Invalid UserName or Password");
            return View();

        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User_Details u)
        {
            if (ModelState.IsValid)
            {
                bool IsValid = ctx.User_Details.Any(usr => usr.username == u.username);

                if (!IsValid)
                {
                    ctx.User_Details.Add(u);
                    ctx.SaveChanges();

                    return RedirectToAction("LogIn");
                   
                }

            }
            ModelState.AddModelError("", "UserName Not Available. Try Different One");
            return View(u);


        }
        public ActionResult LogOut()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}