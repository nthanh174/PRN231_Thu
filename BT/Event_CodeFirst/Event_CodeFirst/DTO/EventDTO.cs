using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.DTO
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
