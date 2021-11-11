using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillPayment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillPayment.Domain.Models;
using FakeItEasy;

namespace BillPayment.Helpers.Tests
{
    [TestClass()]
    public class BillCalculatorTests
    {
        [TestMethod()]
        [Timeout(1500)]
        public void GetBillTest()
        { 
            var userDetails = new User
            {
                Id = 1,
                Name = "Kofi",
                UserTypeID = 1,
                MembershipDate = DateTime.Now
            };

            var invoice = new Invoice();
            var myCart = new Cart();

            myCart.User = userDetails.Id;

            // Fake User Discount rule
            var fakeDiscountRule = A.CollectionOfDummy<DiscountRule>(4).AsEnumerable();

            /*
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
             
             
             */
            Assert.Fail();
        }

        [TestMethod]
        [Timeout(500)]
        public void GetPercentageDicountBill()
        {
            Assert.Fail();
        }

        [TestMethod]
        [Timeout(500)]
        public void GetCashDiscountBill()
        {

        }

        [TestMethod]
        [Timeout(500)]
        private void GetMemberDuration()
        {
            /*int yearDuration = DateTime.Now.Year - membershipDate.Year;
            int monthDuration = DateTime.Now.Month - membershipDate.Month;

            return (yearDuration * 12) + monthDuration;*/

            Assert.Fail();
        }

        [TestMethod]
        [Timeout(500)]
        private void PrepItems()
        {
            Assert.Fail();
        }
    }
}