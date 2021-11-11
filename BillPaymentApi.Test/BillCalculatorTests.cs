using BillPayment.Domain.Models;
using BillPayment.Helpers;
using BillPayment.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BillPaymentApi.Test
{
    public class BillCalculatorTests : FakeData
    {
        private readonly BillCalculator _billCalculator;
        private readonly Mock<IBillerRepository> _billRepo = new Mock<IBillerRepository>();
        private readonly ILogger<BillCalculator> _logger;

        public BillCalculatorTests()
        {
            _billCalculator = new BillCalculator(_billRepo.Object, _logger);
        }

        [Fact]
        public void GetBill_ShouldReturn_Invoice_Affliate()
        {
            // Fake Data
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();

            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);

            // Arrange
            var userDetails = new User { Id = 3 };

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem { Item = 1, Quantity = 2 });
            cartItem.Add(new CartItem { Item = 2, Quantity = 4 });
            cartItem.Add(new CartItem { Item = 4, Quantity = 8 });

            var cart = new Cart
            {
                User = userDetails.Id,
                CartItem = cartItem.ToArray()
            };           

            //Act
            var invoiceResult = _billCalculator.GetBill(cart);
            var invoice = new Invoice();

            //Assert
            Assert.Equal(invoiceResult.User.Id, cart.User);
            Assert.NotNull(invoiceResult);
            Assert.Equal(invoiceResult.PrepItems.Count, cartItem.Count);
            Assert.True(invoiceResult.TotalAmount > 0);
        }

        [Fact]
        public void GetBill_ShouldReturn_Invoice_Employee()
        {
            // Fake Repo
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();
           
            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);

            // Arrange
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

            //Act
            var invoiceResult = _billCalculator.GetBill(cart);
            var invoice = new Invoice();

            //Assert
            Assert.Equal(invoiceResult.User.Id, cart.User);
            Assert.NotNull(invoiceResult);
            Assert.Equal(invoiceResult.PrepItems.Count, cartItem.Count);
            Assert.True(invoiceResult.TotalAmount > 0);
        }

        [Fact]
        public void GetBill_ShouldReturn_Invoice_Customer_Percentage()
        {
            // Fake Repo
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();

            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);

            // Arrange
            var userDetails = new User { Id = 4 };

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem { Item = 1, Quantity = 2 });
            cartItem.Add(new CartItem { Item = 2, Quantity = 4 });
            cartItem.Add(new CartItem { Item = 4, Quantity = 8 });

            var cart = new Cart
            {
                User = userDetails.Id,
                CartItem = cartItem.ToArray()
            };

            //Act
            var invoiceResult = _billCalculator.GetBill(cart);
            var invoice = new Invoice();

            //Assert
            Assert.Equal(invoiceResult.User.Id, cart.User);
            Assert.NotNull(invoiceResult);
            Assert.Equal(invoiceResult.PrepItems.Count, cartItem.Count);
            Assert.True(invoiceResult.TotalAmount > 0);
        }

        [Fact]
        public void GetBill_ShouldReturn_Invoice_Customer_Cash()
        {
            // Fake Repo
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();

            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);

            // Arrange
            var userDetails = new User { Id = 2 };

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem { Item = 1, Quantity = 2 });
            cartItem.Add(new CartItem { Item = 2, Quantity = 4 });
            cartItem.Add(new CartItem { Item = 4, Quantity = 8 });

            var cart = new Cart
            {
                User = userDetails.Id,
                CartItem = cartItem.ToArray()
            };

            //Act
            var invoiceResult = _billCalculator.GetBill(cart);
            var invoice = new Invoice();

            //Assert
            Assert.Equal(invoiceResult.User.Id, cart.User);
            Assert.NotNull(invoiceResult);
            Assert.Equal(invoiceResult.PrepItems.Count, cartItem.Count);
            Assert.True(invoiceResult.TotalAmount > 0);
        }

        [Fact]
        public void GetBill_ShouldReturn_NoInvoice()
        {
            // Fake Repo
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();

            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);

            // Arrange
            var userDetails = new User { Id = 16 };

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem { Item = 1, Quantity = 2 });
            cartItem.Add(new CartItem { Item = 2, Quantity = 4 });
            cartItem.Add(new CartItem { Item = 4, Quantity = 8 });

            var cart = new Cart
            {
                User = userDetails.Id,
                CartItem = cartItem.ToArray()
            };

            //Act
            var invoiceResult = _billCalculator.GetBill(cart);
            var invoice = new Invoice();

            //Assert
            Assert.Null(invoiceResult.DiscountRule);
            Assert.Null(invoiceResult.User);
        }
    }
}