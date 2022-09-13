using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePass.Models;

namespace ePass.Controllers
{
    public class PassengerController : Controller
    {
        [HttpGet]
        public ActionResult GetStatusByMobile()
        {
            PassengerDataViewModel obj = new PassengerDataViewModel();
            return View(obj);
        }
        [HttpPost]
        public ActionResult GetStatusByMobile(PassengerDataViewModel ObjViewModel)
        {
            List<Passenger> LstPassenger = null;
            using (ePassEntities objContext = new ePassEntities())
            {
                LstPassenger = objContext.Passengers.Where(x => x.MobileNo == ObjViewModel.MobileNo).ToList();
            }
            return View("PassengerStatus", LstPassenger);
        }
    }
}