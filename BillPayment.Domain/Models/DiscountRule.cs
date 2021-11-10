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
        public UserType UserType { get; set; }
        [Required]
        public DiscountType DiscountType { get; set; }
        [Required]
        public decimal DiscountValue { get; set; }
        [Required]
        public RuleApplication RuleAppliesTo { get; set; }
    }

    public enum DiscountType
    {
        Cash = 1,
        Percentage
    }

    public enum RuleApplication
    {
        Groceries = 1,
        Electronics,
        All
    }

    public class DiscountsType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class RulesApplies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplyTo { get; set; }
    }
}
