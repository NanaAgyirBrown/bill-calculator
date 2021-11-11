using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class DiscountRule
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        [Required]
        public int DiscountTypeId { get; set; }
        [Required]
        public decimal DiscountValue { get; set; }
        [Required]
        public int RuleAppliesToId { get; set; }     
    }
}
