using BillPayment.Controllers;
using BillPayment.Data.Validations;
using BillPayment.Domain.Models;
using BillPayment.Helpers;
using BillPayment.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BillPaymentApi.Test
{
    public class BillControllerTests : FakeData
    {
        private readonly BillerController _billApi;
        private readonly Mock<IBillerRepository> _billRepo = new Mock<IBillerRepository>();
        private readonly Mock<ILogger<BillerController>> _controllerlogger = new Mock<ILogger<BillerController>>();
        private readonly Mock<ILogger<ItemValidation>> _itemVlogger = new Mock<ILogger<ItemValidation>>();
        private readonly Mock<ILogger<CartValidation>> _carLogger = new Mock<ILogger<CartValidation>>();
        private readonly Mock<ILogger<BillCalculator>> _calLogger = new Mock<ILogger<BillCalculator>>();

        public BillControllerTests()
        {
            _billApi = new BillerController(_controllerlogger.Object, _calLogger.Object, _billRepo.Object, _itemVlogger.Object, _carLogger.Object);
        }

        [Fact]
        public void GetItems_HasItems()
        {
            // Arrange
            var items = GetFakeShopItems();
            _billRepo.Setup(x => x.GetItems).Returns(items);

            // Act
            var returnedItems = _billApi.GetItems();

            // Assert
            Assert.NotNull(returnedItems);
        }

        [Fact]
        public async Task GetInvoice()
        {
            // Arrange
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();

            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);


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

            // Act
            var returnedItems = await _billApi.MyShopingCart(cart);

            // Assert
            Assert.NotNull(returnedItems.Data);
        }

        [Fact]
        public async Task GetInvoice_Noinvoice()
        {
            // Arrange
            var users = GetFakeUsers();
            var discountRules = GetFakeDiscountRule();
            var items = GetFakeShopItems();

            _billRepo.Setup(x => x.GetUsers).Returns(users);
            _billRepo.Setup(x => x.GetDiscountRules).Returns(discountRules);
            _billRepo.Setup(x => x.GetItems).Returns(items);


            var userDetails = new User { Id = 3 };

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem { Item = 1, Quantity = 2 });
            cartItem.Add(new CartItem { Item = 2, Quantity = 4 });
            cartItem.Add(new CartItem { Item = 4, Quantity = 8 });

            var cart = new Cart
            {
                CartItem = cartItem.ToArray()
            };

            // Act
            var returnedItems = await _billApi.MyShopingCart(cart);

            // Assert
            Assert.Equal(returnedItems.IsSuccessful, false);
        }
    }
}
