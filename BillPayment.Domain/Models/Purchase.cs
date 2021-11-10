using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [Required]
        public Items? Item { get; set; }
        [Required(ErrorMessage = "Please input quantity purchased"), NotNull]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
    }
}
