using Event_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_CodeFirst.DataAccess
{
    public static class EventDAO
    {
        public static List<Event> GetAllEvents()
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    return context.Events
/*                        .Include(e => e.EventType)
                        .Include(e => e.User)
                        .Include(e => e.Feedbacks)*/
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static Event GetEventById(int id)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    return context.Events
/*                        .Include(e => e.EventType)
                        .Include(e => e.User)
                        .Include(e => e.Feedbacks)*/
                        .FirstOrDefault(e => e.EventId == id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void CreateEvent(Event events)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    context.Events.Add(events);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void UpdateEvent(Event events)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    context.Entry(events).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void DeleteEvent(Event events)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    context.Events.Remove(events);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static bool EventExists(int id)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    return context.Events.Any(e => e.EventId == id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

}
