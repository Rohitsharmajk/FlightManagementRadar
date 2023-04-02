using Flight_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flight_Management.Controllers
{
    public class Passenger_detailsController : Controller
    {
        // GET: Passenger_details
        FlightManagementContext context= new FlightManagementContext();
        public ActionResult Book_pay()
        {
            Random obj1 = new Random();
            TempData["Board_ID"] = obj1.Next();
            return View();
        }
        [HttpPost]
        public ActionResult Book_pay(string Name, long PhoneNum, string Email )
        {
            
            ViewBag.bid = TempData["Board_ID"];
            ViewBag.nm = Name;
            ViewBag.pn = PhoneNum;
            ViewBag.eml = Email;
            CheckIn_Details obj2 = new CheckIn_Details()
            {
                Boarding_ID = ViewBag.bid,
                Flight_ID = 2
            };
            context.CheckIn_Details.Add(obj2);
            return View("Continue");
        }
    }
}
