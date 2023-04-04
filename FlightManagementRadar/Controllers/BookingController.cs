using FlightManagementRadar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FlightManagementRadar.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        FlightManagementContext cont = new FlightManagementContext();
        public ActionResult GetDetails()
        {
            if (Session["user"] != null)
            {
                List<string> beg = cont.Flight_Data.Select(x => x.Beginning).Distinct().ToList();
                List<string> dest = cont.Flight_Data.Select(x => x.Destination).Distinct().ToList();
                ViewBag.Beginning = beg;
                ViewBag.Dest = dest;
                return View();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        [HttpPost]
        public ActionResult BookFlight(string Source, string Destination,DateTime Date)
        {
            if (Session["user"] != null)
            {
                List<Flight_Data> list = cont.Flight_Data.Where(x => x.Beginning.Equals(Source) && x.Destination.Equals(Destination) && DbFunctions.TruncateTime(x.Boarding_Time) == Date.Date).OrderBy(x => x.Boarding_Time).ToList();
                ViewBag.dets = list;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}