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
        [Required(ErrorMessage = "Please provide User's name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please specify type of user")]
        public UserType UserType { get;set; }
        [Required(ErrorMessage = "Please provide membership date")]
        public DateTime MembershipDate { get; set; }
    }
}
