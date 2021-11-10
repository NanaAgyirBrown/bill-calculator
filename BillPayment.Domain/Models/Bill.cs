using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class Bill {
        [Key]
        public Guid BillId { get; set; }
        public Guid User { get; set; }
        public Items Items { get; set; }
        public DiscountRule DiscountRule { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DicountAmount { get; set; }
        public decimal AmountPayable { get; set; }
    }
}
