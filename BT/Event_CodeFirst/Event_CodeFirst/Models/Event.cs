using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        [ForeignKey("EventTypeId")]
        public virtual EventType EventType { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual User User { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
