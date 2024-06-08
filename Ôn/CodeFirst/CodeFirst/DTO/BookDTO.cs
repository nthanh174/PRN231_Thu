using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public DateTime? CreateAt { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
