using BillPayment.Domain.Models;

namespace BillPayment.Helpers
{
    public class PrepItems : Items
    {
        public int Quantity { get; set; }
        public decimal TotalCost {  get; set;}
    }
}
