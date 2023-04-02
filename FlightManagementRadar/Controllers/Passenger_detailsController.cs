using FlightManagementRadar.Models;
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
        public ActionResult Book_pay(int FID)
        {
            Random obj1 = new Random();
            TempData["Board_ID"] = obj1.Next(11111,99999);
            TempData["FID"] = FID;
            return View();
        }

        [HttpPost]
        public ActionResult Book_pay(string Name, long PhoneNum, string Email )
        {
            int BID = (int)TempData["Board_ID"];
            ViewBag.bid = BID;
            ViewBag.nm = Name;
            ViewBag.pn = PhoneNum;
            ViewBag.eml = Email;
            Console.WriteLine(BID);
            
            
          
                CheckIn_Details obj2 = new CheckIn_Details()
                {
                    Boarding_ID = BID,
                    Flight_ID = (int)TempData["FID"]
                };
                context.CheckIn_Details.Add(obj2);
                context.SaveChanges();
            return View("Continue");
        }
    }
}
