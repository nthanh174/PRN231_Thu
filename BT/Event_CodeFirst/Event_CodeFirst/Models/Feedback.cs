using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FId { get; set; }
        public string Description { get; set; }

        public string UserName { get; set; }
        //[ForeignKey("UserName")]
        //public virtual User User { get; set; }

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        public int Rate { get; set; }
    }

}
