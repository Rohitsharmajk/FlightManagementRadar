using FlightManagementRadar.Models;
using System.Collections.Generic;
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
            List<string> beg = cont.Flight_Data.Select(x => x.Beginning).Distinct().ToList();
            List<string> dest = cont.Flight_Data.Select(x => x.Destination).Distinct().ToList();
            ViewBag.Beginning = beg;
            ViewBag.Dest = dest;
            return View();
        }
        [HttpPost]
        public ActionResult BookFlight(string Source, string Destination)
        {
            ViewBag.dets = cont.Flight_Data.Where(x => x.Beginning.Equals(Source) && x.Destination.Equals(Destination)).OrderBy(x=>x.Boarding_Time).ToList();
            return View();
        }
    }
}