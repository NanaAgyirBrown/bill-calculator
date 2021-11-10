using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public record struct Cart
    {
        [Key]
        private Guid Id {  get; set; }
        [Required]
        public Guid User { get; set; }  
        [Required]
        public CartItem[]? CartItem { get; set; }
        
    }

    public class CartItem
    {
        [Required]
        public int Item { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
