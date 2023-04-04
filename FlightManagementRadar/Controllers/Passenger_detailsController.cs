using FlightManagementRadar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Flight_Management.Controllers
{
    public class Passenger_detailsController : Controller
    {
        // GET: Passenger_details
        FlightManagementContext context= new FlightManagementContext();
        public ActionResult Book_pay(int FID)
        {
            //if (Session["user"] != null)
            //{
                Random obj1 = new Random();
                TempData["Board_ID"] = obj1.Next(11111, 99999);
            String user= (string)Session["user"];
                List < CheckIn_Details > list= context.CheckIn_Details.Where(x => x.username.Equals(user)).ToList();
                ViewBag.list = list;
                ViewBag.fid = FID;
                TempData.Keep();
                TempData["FID"] = FID;
                return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Account");
            //}
        }

        [HttpPost]
        public ActionResult Book_pay(string Name, long PhoneNum, string Email )
        {
            //if (Session["user"] != null)
            //{
                int BID = (int)TempData["Board_ID"];
                ViewBag.bid = BID;
                ViewBag.nm = Name;
                ViewBag.pn = PhoneNum;
                ViewBag.eml = Email;



                CheckIn_Details obj2 = new CheckIn_Details()
                {
                    Boarding_ID = BID,
                    Flight_ID = (int)TempData["FID"]
                };
                context.CheckIn_Details.Add(obj2);
                context.SaveChanges();
                return View("Continue");
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Account");
            //}
        }
    }
}
