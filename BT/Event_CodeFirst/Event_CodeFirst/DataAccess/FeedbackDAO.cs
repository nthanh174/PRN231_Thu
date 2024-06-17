using Event_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_CodeFirst.DataAccess
{
    public static class FeedbackDAO
    {
        public static List<Feedback> GetAllFeedbacks()
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {

                    var feedbacks = context.Feedbacks
/*                        .Include(f => f.Event)*/
                        .ToList();
                    return feedbacks;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static Feedback GetFeedbackById(int id)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    return context.Feedbacks
/*                        .Include(f => f.Event)*/
                        .FirstOrDefault(f => f.FId == id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void CreateFeedback(Feedback feedback)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    context.Feedbacks.Add(feedback);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void UpdateFeedback(Feedback feedback)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    context.Entry(feedback).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void DeleteFeedback(Feedback feedback)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    context.Feedbacks.Remove(feedback);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static void DeleteFeedbacksByEventId(int eventId)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    var feedbacks = context.Feedbacks
                        .Where(f => f.EventId == eventId)
                        .ToList();

                    context.Feedbacks.RemoveRange(feedbacks);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static bool FeedbackExists(int id)
        {
            using (var context = new Event_CodeFirstContext())
            {
                try
                {
                    return context.Feedbacks.Any(f => f.FId == id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

}
