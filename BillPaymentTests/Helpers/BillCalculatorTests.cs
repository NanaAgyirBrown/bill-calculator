using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BillPayment.Domain.Models;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using BillPayment.Interfaces.Repository;

namespace BillPayment.Helpers.Tests
{
    [TestClass]
    public class BillCalculatorTests
    {
        [TestMethod()]
        public void GetBillTestAs()
        {
            // Arrange
            ILogger<BillCalculator> _logger = null;

            var fakeStore = A.Fake<IBillerRepository>();
            A.CallTo(() => fakeStore.GetDiscountRules);
            A.CallTo(() => fakeStore.GetUsers);
            A.CallTo(() => fakeStore.GetItems);

            var userDetails = new User { Id = 1 };

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem { Item = 1, Quantity = 2 });
            cartItem.Add(new CartItem { Item = 2, Quantity = 4 });
            cartItem.Add(new CartItem { Item = 4, Quantity = 8 });

            var cart = new Cart
            {
                User = userDetails.Id,
                CartItem = cartItem.ToArray()
            };


            // Act
            var _billCalculator = new BillCalculator(fakeStore, _logger);
            var returnResult = _billCalculator.GetBill(cart);
            var newInvoice = new Invoice();


            // Assert
            Assert.IsNotNull(returnResult);
            Assert.AreSame(returnResult, newInvoice);
            Assert.AreEqual(returnResult.User.Id, userDetails.Id);
            Assert.AreEqual(returnResult.PrepItems.Count, cartItem.Count);
            Assert.IsTrue(returnResult.TotalAmount > 0);
        }
    }
}