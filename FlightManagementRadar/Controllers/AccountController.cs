using FlightManagementRadar.Models;
using System.Linq;
using System.Web.Mvc;

namespace FlightManagementRadar.Controllers
{
   
    public class AccountController : Controller
    {
        FlightManagementContext ctx = new FlightManagementContext();
        // GET: Account
        public ActionResult LogIn()
        {
            Session["user"] = null;
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
                    Session["user"]= u.username;
                    return RedirectToAction("Index", "Home");
                    //return View("ViewInput");
                }

            }
            ModelState.AddModelError("userNameOrPass", "Incorrect username/password!");
            return View();

        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp( string username,string password,string confirmpass)
        {
            bool same = password.Equals(confirmpass);
            if (!same)
            {
                ModelState.AddModelError("notsame", "Password and Confirm Password doesn't match");
            }
            if (ModelState.IsValid && same)
            {
                bool IsValid = ctx.User_Details.Any(usr => usr.username == username);


                if (!IsValid)
                {
                    ctx.User_Details.Add(new User_Details() { username=username,password=password});
                    ctx.SaveChanges();
                    
                    return RedirectToAction("LogIn");
                   
                }

            }
            else
            {
                ModelState.AddModelError("usernameExists", "Username already exists!");
            }
            
            return View();


        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}