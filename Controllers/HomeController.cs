using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePass.Models;

namespace ePass.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult DummyApi()
        {
            return View();
        }
        [HttpPost]
        public int ValidateMyData(int FirstNumber,int SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }




        public ActionResult Login()
        {
            //using (ePassEntities ObjContext = new ePassEntities())
            //{
            //   var StudentData = ObjContext.Passengers.Where(x => x.Id == 1).FirstOrDefault();

            //    if (StudentData != null)
            //    {
            //        StudentData.firstName = "Sunny";       
            //        ObjContext.SaveChanges();
            //    }
            //}

                return View();
        }
        //string Username,string Password
        public ActionResult ValidateUser(string Username, string Password)
        {
            if (Username == "admin" & Password == "123")
            {
                return View("Dashboard");
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        //Passenger

        [HttpGet]
        public ActionResult Passenger()
        {
            PassengerViewModel Obj = new PassengerViewModel();
            return View(Obj);
        }
        [HttpPost]
        public ActionResult Passenger(PassengerViewModel ObjViewModel)
        {
            Passenger ObjModel = new Passenger();
            using (ePassEntities ObjContext = new ePassEntities())
            {
                ObjModel.firstName = ObjViewModel.firstName;
                ObjModel.LastName = ObjViewModel.LastName;
                ObjModel.EmailId = ObjViewModel.EmailId;
                ObjModel.SourcePlace = ObjViewModel.SourcePlace;
                ObjModel.DestinationPlace = ObjViewModel.DestinationPlace;
                ObjModel.DateOfTravel = ObjViewModel.DateOfTravel;
                ObjModel.CreatedDt = DateTime.Now;
                ObjModel.Status = "Pending";
                ObjContext.Passengers.Add(ObjModel);
                ObjContext.SaveChanges();
            }

            return View();
        }
        public ActionResult AdminDashboard()
        {
            List<Passenger> LstPassenger = null;

            using (ePassEntities ObjContext = new ePassEntities())
            {
                LstPassenger = ObjContext.Passengers.ToList();
            }

            return View(LstPassenger);
        }
















    }
}