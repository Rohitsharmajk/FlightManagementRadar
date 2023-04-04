using FlightManagementRadar.Models;
using System.Linq;
using System.Web.Mvc;

namespace FlightManagementRadar.Controllers
{
    public class ValidateBookingIDController : Controller
    {
        // GET: ValidateBookingID
        FlightManagementContext context=new FlightManagementContext();
        
        public ActionResult CheckIn()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        
        public ActionResult CheckInSuccess()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult ValidateCheck(CheckIn_Details obj)
        {
            if (Session["user"] != null)
            {
                if (ModelState.IsValid)
                {
                    bool isValid = context.CheckIn_Details.Any(m => m.Boarding_ID == obj.Boarding_ID);
                    if (isValid)
                    {
                        TempData["ID"] = obj.Boarding_ID;
                        context.CheckIn_Details.Remove(context.CheckIn_Details.SingleOrDefault(m => m.Boarding_ID == obj.Boarding_ID));
                        context.SaveChanges();
                        return RedirectToAction("CheckInSuccess");
                    }
                }
                ModelState.AddModelError("IdNotFound", "Your ID is Invalid! Please Re-check");
                return View("CheckIn");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            //return Content("<h1></h1>");
        }
    }
}
