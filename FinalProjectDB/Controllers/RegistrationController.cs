using EventBLL;
using EventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectDB.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index() { return View(); }

        [HttpGet]
        public ActionResult Index(int eventId)
        {
            RegistrationService regService = new RegistrationService();
            EventService evService = new EventService();
            var registrations = regService.GetRegistrations(eventId);

            TempData["EventID"] = eventId;
            TempData["EventsList"] = evService.GetEvents();

            return View(registrations);
        }

        public ActionResult DeleteRegistration(int registrationId)
        {
            RegistrationService regService = new RegistrationService();
            if (regService.DeleteRegistration(registrationId))
                ViewBag.Message = "Deleted successfuly";

            return RedirectToAction("Index", "Event");
        }
        
        public ActionResult AddRegistration()
        {
            Registration registration = null;
            int eventId = (int)TempData["eventId"];

            if(eventId > 0)
                registration = new Registration { EventID = eventId};

            return View(registration);
        }

        [HttpPost]
        public ActionResult AddRegistration(Registration registration)
        {
            RegistrationService regService = new RegistrationService();
            if (regService.AddRegistration(registration))
                ViewBag.Message = "Added successfuly";

            return RedirectToAction("Index", "Event");
        }
        
        public ActionResult UpdateRegistration(int registrationId, int eventId)
        {
            RegistrationService registration = new RegistrationService();

            var events = registration.GetRegistrations(eventId).Find(x => x.RegistrationID == registrationId);

            return View(events);
        }

        [HttpPost]
        public ActionResult UpdateRegistration(Registration registration)
        {
            RegistrationService regService = new RegistrationService();
            if (regService.UpdateRegistration(registration))
                ViewBag.Message = "Added successfuly";

            return RedirectToAction("Index", "Event");
        }


    }
}