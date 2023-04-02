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
            return View();
        }
        
        public ActionResult CheckInSuccess()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ValidateCheck(CheckIn_Details obj)
        {
            if(ModelState.IsValid)
            {
                bool isValid=context.CheckIn_Details.Any(m=>m.Boarding_ID==obj.Boarding_ID);
                if(isValid)
                {
                    TempData["ID"]=obj.Boarding_ID;
                    context.CheckIn_Details.Remove(context.CheckIn_Details.SingleOrDefault(m=>m.Boarding_ID==obj.Boarding_ID));
                    context.SaveChanges();
                    return RedirectToAction("CheckInSuccess");
                }
            }
            ModelState.AddModelError("IdNotFound", "Your ID is Invalid! Please Re-check");
            return View("CheckIn");
            //return Content("<h1></h1>");
        }
    }
}
