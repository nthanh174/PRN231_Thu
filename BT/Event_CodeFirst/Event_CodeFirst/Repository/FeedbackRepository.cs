using Event_CodeFirst.DataAccess;
using Event_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public void Delete(Feedback feedback)
        {
            FeedbackDAO.DeleteFeedback(feedback);
        }

        public void DeleteByEvent(int eid)
        {
            FeedbackDAO.DeleteFeedbacksByEventId(eid);
        }

        public Feedback Get(int fid)
        {
            return FeedbackDAO.GetFeedbackById(fid);
        }

        public List<Feedback> GetAll()
        {
            return FeedbackDAO.GetAllFeedbacks();
        }

        public void Insert(Feedback feedback)
        {
            FeedbackDAO.CreateFeedback(feedback);
        }

        public void Update(Feedback feedback)
        {
            FeedbackDAO.UpdateFeedback(feedback);
        }
    }
}
