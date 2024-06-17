using Event_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Repository
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAll();
        Feedback Get(int fid);
        void Insert(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
        void DeleteByEvent(int eid);
    }
}
