using BillPayment.Controllers;
using BillPayment.Domain;
using BillPayment.Domain.Models;
using BillPayment.Helpers;
using BillPayment.Interfaces.Repository;
using FakeItEasy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BillPaymentControllers
{
    public class ItemsControllerTests
    {
        [Fact]
        public async Task Get_Items()
        {
            // Instances and fakes 
            var itemList = new List<Items>();

            var fakeItems = A.CollectionOfDummy<Items>(5).AsEnumerable();

            // Arrange
            var fakeStore = A.Fake<IBillerRepository>();
            A.CallTo(() => fakeStore.GetItems);

            var controller = new BillerController(null, null, fakeStore, null, null);


            // Action
            var asyncResults = await controller.GetItems();

            // Assert
            var result = asyncResults as ApiResponse;
            Assert.NotNull(result);
            Assert.Contains(result.Data, fakeItems);
        }

        [Fact]
        public async Task Get_Bill()
        {
            // Instances and fakes 
            var myCart = new Cart();
            var myInvoice = new Invoice();

            var fakeItems = A.CollectionOfDummy<Items>(5).AsEnumerable();

            // Arrange
            var fakeStore = A.Fake<IBillerRepository>();
            A.CallTo(() => fakeStore.GetItems);

            var controller = new BillerController(null, null, fakeStore, null, null);


            // Action
            var asyncResults = await controller.MyShopingCart(myCart);

            // Assert
            var result = asyncResults as ApiResponse;
            Assert.NotNull(result);
            Assert.Contains(result.Data, (IEnumerable<object>)myInvoice.User);
            Assert.Contains(result.Data, (IEnumerable<object>)myInvoice.PrepItems);
        }
    }
}