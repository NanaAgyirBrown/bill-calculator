using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class RulesApplies
    {
        public RulesApplies()
        {
            DiscountRules = new HashSet<DiscountRule>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplyTo { get; set; }

        public ICollection<DiscountRule> DiscountRules { get; set; } = new List<DiscountRule>();
    }
}
