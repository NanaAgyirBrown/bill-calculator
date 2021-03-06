using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public class User
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserTypeID { get; set; }
        [Required]
        public DateTime MembershipDate { get; set; }

        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
