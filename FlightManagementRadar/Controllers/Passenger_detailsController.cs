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
            if (Session["user"] != null)
            {
                Random obj1 = new Random();
                TempData["Board_ID"] = obj1.Next(11111, 99999);
                String user= (string)Session["user"];
                List < CheckIn_Details > list= context.CheckIn_Details.Where(x => x.username.Equals(user)).ToList();
                ViewBag.list = list;
                Session["FID"] = FID;
                return View();
        }
            else
            {
                return RedirectToAction("Login", "Account");
    }
}

        public ActionResult Book_Del(int Boarding_ID)
        {
            if (Session["user"] != null)
            {

                context.CheckIn_Details.Remove(context.CheckIn_Details.SingleOrDefault(x=>x.Boarding_ID==Boarding_ID));
                context.SaveChanges();
                return Redirect($"/Passenger_details/Book_pay?FID={Session["FId"]}");
        }
            else
            {
                return RedirectToAction("Login", "Account");
    }
}
        public ActionResult Book_Add(String Name, int PhoneNum, string Email,String Gender,int Age)
        {
            if (Session["user"] != null)
            {
                int BID = (int)TempData["Board_ID"];
            ViewBag.bid = BID;
            ViewBag.nm = Name;
            ViewBag.pn = PhoneNum;
            ViewBag.eml = Email;



            CheckIn_Details obj2 = new CheckIn_Details()
            {
                Boarding_ID = BID,
                Flight_ID = (int)Session["FId"],
                Name= Name,
                PhoneNum = PhoneNum,
                Email = Email,
                Gender = Gender,
                Age = Age,
                username = (String)Session["user"],
            };
            context.CheckIn_Details.Add(obj2);
            context.SaveChanges();
            return Redirect($"/Passenger_details/Book_pay?FID={Session["FId"]}");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Continue()
        {
            String user = (string)Session["user"];
            int id = (int)Session["FID"];
            List<CheckIn_Details> list1 = context.CheckIn_Details.Where(x => x.username.Equals(user)).ToList();
            Flight_Data fl = context.Flight_Data.SingleOrDefault(x => x.Flight_ID==id);
            ViewBag.list1 = list1;
            ViewBag.fl = fl;
            return View();
        }
    }
}
