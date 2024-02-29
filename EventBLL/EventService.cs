using EventDAL;
using EventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBLL
{
    public class EventService
    {
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
            EventRepository eventRepository = new EventRepository();

            events = eventRepository.GetEvents();
            return events;
        }

        public bool AddEvent(Event eventParam)
        {
            EventRepository eventRepository = new EventRepository();
            return eventRepository.AddEvent(eventParam);
        }

        public bool RemoveEvent(int eventId)
        {
            EventRepository eventRepository= new EventRepository();
            return eventRepository.RemoveEvent(eventId);
        }

        public bool UpdateEvent(Event eventParam)
        {
            EventRepository eventRepository= new EventRepository();
            return eventRepository.UpdateEvent(eventParam);
        }
    }
}
