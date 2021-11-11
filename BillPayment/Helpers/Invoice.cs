using BillPayment.Domain.Models;
using System.Text.Json.Serialization;

namespace BillPayment.Helpers
{
    public class Invoice : Bill
    {
        [JsonPropertyName("Cart Items")]
        public List<PrepItems> PrepItems { get; set; }
    }
}
