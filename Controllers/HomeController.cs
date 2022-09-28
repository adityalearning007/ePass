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
        public ActionResult Login()
        {
            tbladmin obj = new tbladmin();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Login(tbladmin Obj)
        {
            //tbladmin Objadmin = new tbladmin();
            List<tbladmin> LstAdmin = null;
            using (ePassEntities ObjContext = new ePassEntities())
            {
               LstAdmin = ObjContext.tbladmins.Where(x => x.Username == Obj.Username && x.Password == Obj.Password).ToList();                
               
            }
            if (LstAdmin.Count > 0)
            {
                Session["username"] = LstAdmin[0].Id;
                return RedirectToAction("AdminDashboard", "Home");
            }
            else
            {
                return View(Obj);
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
            if (Session["username"] != null)//set session
            {
                List<Passenger> LstPassenger = null;
                using (ePassEntities ObjContext = new ePassEntities())
                {
                    LstPassenger = ObjContext.Passengers.ToList();
                }
                return View(LstPassenger);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult updatePassengerStatus(string Status,int Id)
        {
            using (ePassEntities ObjContext = new ePassEntities())
            {
                var Passenger = ObjContext.Passengers.Where(x => x.Id == Id).FirstOrDefault();
                if (Passenger != null)
                {
                    Passenger.Status = Status;
                    ObjContext.SaveChanges();
                }

            }
            return RedirectToAction("AdminDashboard","Home");
        }
















    }
}