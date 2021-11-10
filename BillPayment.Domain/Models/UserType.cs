using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Domain.Models
{
    public enum UserType
    {
        Employee = 1,
        Affliate,
        Customer        
    }

    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserType { get; set; }
    }
}
