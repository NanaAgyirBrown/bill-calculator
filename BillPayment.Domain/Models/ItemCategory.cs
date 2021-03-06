using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class ItemsCategory
    {
        public ItemsCategory()
        {
            this.Items = new HashSet<Items>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        public ICollection<Items> Items { get; set; } = new List<Items>();
    }
}
