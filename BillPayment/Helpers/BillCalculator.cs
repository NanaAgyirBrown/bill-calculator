using BillPayment.Domain.Models;
using BillPayment.Interfaces.Repository;

namespace BillPayment.Helpers
{
    public class BillCalculator
    {
        private readonly IBillerRepository _billerRepository;
        private readonly ILogger<BillCalculator> _logger;

        public BillCalculator(IBillerRepository billerRepository, ILogger<BillCalculator> logger)
        {
            _billerRepository = billerRepository;
            _logger = logger;
        }

        public Bill GetBill(Cart cart)
        {
            return new Bill { };
        }
    }
}
