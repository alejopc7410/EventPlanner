using EventBLL;
using EventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectDB.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            EventService eventService = new EventService();
            var events = eventService.GetEvents();
            return View(events);
        }

        public ActionResult AddEvent() { return View(); }

        [HttpPost]
        public ActionResult AddEvent(Event eventParam) 
        {
            EventService eventService = new EventService();
            if (eventService.AddEvent(eventParam))
                ViewBag.Message = "Event added successfuly";

            return RedirectToAction("Index");
        }

        public ActionResult RemoveEvent(int eventId)
        {
            EventService eventService = new EventService();
            if (eventService.RemoveEvent(eventId))
                return RedirectToAction("Index");

            return null;
        }

        public ActionResult UpdateEvent(int eventId)
        {
            EventService eventService = new EventService();
            var events = eventService.GetEvents().Find(x => x.EventID == eventId);
            return View(events);
        }

        [HttpPost]
        public ActionResult UpdateEvent(Event eventParam)
        {
            EventService eventService = new EventService();
            if(eventService.UpdateEvent(eventParam))
                ViewBag.Message = "Event added successfuly";

            return View();
        }
    }
}