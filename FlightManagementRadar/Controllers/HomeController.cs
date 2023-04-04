using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FlightManagementRadar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                ViewBag.some = 1;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult About()
        {
            if (Session["user"] != null)
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Contact()
        {
            if (Session["user"] != null)
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}