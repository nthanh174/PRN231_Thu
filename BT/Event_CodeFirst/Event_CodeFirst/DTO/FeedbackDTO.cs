using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.DTO
{
    public class FeedbackDTO
    {
        public int FId { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int Rate { get; set; }
        public int EventId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
