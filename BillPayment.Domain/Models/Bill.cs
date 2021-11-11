using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class Bill {
        [Key]
        [JsonPropertyName("Invoice #")]
        public Guid BillId { get; set; }
        public virtual User User { get; set; }
        [JsonPropertyName("Discount Rule")]
        public virtual DiscountRule DiscountRule { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountableAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal AmountPayable { get; set; }
    }
}
