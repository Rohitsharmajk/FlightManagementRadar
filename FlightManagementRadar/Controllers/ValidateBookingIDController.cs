using Flight_Management.Models;
using System.Linq;
using System.Web.Mvc;

namespace Flight_Management.Controllers
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
                    return RedirectToAction("CheckInSuccess");
                }
            }

            return Content(obj.Boarding_ID.ToString());
        }
    }
}
