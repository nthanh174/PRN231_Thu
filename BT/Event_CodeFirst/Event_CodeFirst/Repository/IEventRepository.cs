using Event_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Repository
{
    public interface IEventRepository
    {
        List<Event> GetAll();
        Event Get(int eid);
        void Insert(Event evt);
        void Update(Event evt);
        void Delete(Event evt);
    }
}
