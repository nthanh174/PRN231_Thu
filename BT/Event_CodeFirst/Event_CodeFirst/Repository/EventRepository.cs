using Event_CodeFirst.DataAccess;
using Event_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Repository
{
    public class EventRepository : IEventRepository
    {
        public void Delete(Event evt)
        {
            EventDAO.DeleteEvent(evt);
        }

        public Event Get(int eid)
        {
            return EventDAO.GetEventById(eid);
        }

        public List<Event> GetAll()
        {
            return EventDAO.GetAllEvents();
        }

        public void Insert(Event evt)
        {
            EventDAO.CreateEvent(evt);
        }

        public void Update(Event evt)
        {
            EventDAO.UpdateEvent(evt);
        }
    }
}
