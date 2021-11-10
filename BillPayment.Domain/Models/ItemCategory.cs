using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public enum ItemCategory
    {
        Groceries,
        Electronics
    }

    public class ItemsCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
