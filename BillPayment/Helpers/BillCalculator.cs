using BillPayment.Domain.Models;
using BillPayment.Interfaces.Repository;
using System.Linq;

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

        public Invoice GetBill(Cart cart)
        {
            Invoice invoice = new Invoice { };
            //Search for user
            var user = _billerRepository.GetUsers.FirstOrDefault(u => u.Id == cart.User);

            if (user == null)
                return invoice;            

            // Retrieve User dicount type and rule
            var userDiscountRule = _billerRepository.GetDiscountRules.Where(d => d.UserTypeId == user.UserTypeID);

            if (userDiscountRule == null)
                return invoice;
            
            if(userDiscountRule.Count() > 1)
            {
                int memDuration = (user.UserTypeID == 3) ? GetMemberDuration(user.MembershipDate) : 0;


                if (memDuration >= 24)
                {
                    var customerRule = userDiscountRule.FirstOrDefault(d => d.DiscountTypeId == 2);
                    invoice = GetPercentageDicountBill(PrepItems(cart.CartItem), customerRule);
                    invoice.User = user;
                }
                else
                {
                    var customerRule = userDiscountRule.FirstOrDefault(d => d.DiscountTypeId == 1);
                    invoice = GetCashDiscountBill(PrepItems(cart.CartItem), customerRule);
                    invoice.User = user;
                }

                return invoice;
            }

            var ruleType = userDiscountRule.FirstOrDefault();

            if (ruleType == null)
                return invoice;

            switch (ruleType.DiscountTypeId)
            {
                case 2:
                    invoice = GetPercentageDicountBill(PrepItems(cart.CartItem), ruleType);
                    break;
                case 1:
                    invoice = GetCashDiscountBill(PrepItems(cart.CartItem), ruleType);
                    break;
            }

            invoice.User = user;
            return invoice;
        }

        private Invoice GetPercentageDicountBill(List<PrepItems> items, DiscountRule rule)
        {
            decimal totalAmount  = items.Select(i => i.TotalCost).Sum();
            decimal dicountableAmount = items.Where(i => i.CategoryId == rule.RuleAppliesToId).Sum(i => i.TotalCost);
            decimal discountAmount = dicountableAmount * (rule.DiscountValue / 100);
            decimal amountPayable = totalAmount - discountAmount;

            return new Invoice
            {
                BillId = Guid.NewGuid(),
                DiscountRule = rule,
                TotalAmount = totalAmount,
                DiscountableAmount = dicountableAmount,
                DiscountAmount = discountAmount,
                AmountPayable = amountPayable,
                PrepItems = items
            };
        }

        private Invoice GetCashDiscountBill(List<PrepItems> items, DiscountRule rule)
        {
            decimal totalAmount = items.Select(i => i.TotalCost).Sum();
            decimal dicountableAmount = totalAmount - (totalAmount % 100);
            decimal discountAmount = (dicountableAmount/100) * rule.DiscountValue;
            decimal amountPayable = totalAmount - discountAmount;

            return new Invoice
            {
                BillId = Guid.NewGuid(),
                DiscountRule = rule,
                TotalAmount = totalAmount,
                DiscountableAmount = dicountableAmount,
                DiscountAmount = discountAmount,
                AmountPayable = amountPayable,
                PrepItems = items
            };
        }

        private int GetMemberDuration(DateTime membershipDate)
        {
            int yearDuration = DateTime.Now.Year - membershipDate.Year;
            int monthDuration = DateTime.Now.Month - membershipDate.Month;

            return (yearDuration * 12) + monthDuration;
        }

        private List<PrepItems> PrepItems(CartItem[] cartItem)
        {
            List<PrepItems> preppedItems = new List<PrepItems>();

            if (cartItem == null || cartItem.Count() == 0)
                return preppedItems;

            foreach (var item in cartItem)
            {
                if(item.Item == 0)
                    return null;

                var newItem = _billerRepository.GetItems.FirstOrDefault(i => i.Id == item.Item);

                preppedItems.Add(new PrepItems
                {
                    Id = newItem.Id,
                    ItemName = newItem.ItemName,
                    CategoryId = newItem.CategoryId,
                    UnitPrice = newItem.UnitPrice,
                    Quantity = item.Quantity,
                    TotalCost = item.Quantity * newItem.UnitPrice
                });
            }

            return preppedItems;
        }
    }
}
