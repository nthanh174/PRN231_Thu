using Event_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Repository
{
    public interface IEventTypeRepository
    {
        List<EventType> GetAll();
        EventType Get(int etid);
        void Insert(EventType eventType);
        void Update(EventType eventType);
        void Delete(int etid);
    }
}
