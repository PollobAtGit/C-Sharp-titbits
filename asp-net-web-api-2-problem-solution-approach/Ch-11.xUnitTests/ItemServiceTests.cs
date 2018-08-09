using Ch_11.Controllers;
using Ch_11.Tests;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ch_11.xUnitTests
{
    public class ItemServiceTests
    {
        IService Service { get; }

        public ItemServiceTests()
        {
            Service = new ItemsServiceFake();
        }

        [Fact]
        public void AddItem_Must_ReturnIncrementedId()
        {
            var newItem = new Item
            {
                ItemName = "xcv",
                Price = 89
            };

            Service.AddItem(newItem);

            Assert.False(newItem.Id == 0);
        }

        [Fact]
        public void InnerRepository_Must_BeInitialized()
        {
            Assert.NotNull(Service.Repository);
        }

        [Fact]
        public async Task GetById_Must_ReturnValidItemIfFound()
        {
            var foundItem = await Service.GetById(id: 10);

            Assert.NotNull(foundItem);
            Assert.NotNull(foundItem.ItemName);
            Assert.NotEmpty(foundItem.ItemName);
        }

        [Fact]
        public async Task GetById_Must_ThrowExceptionIfItemNotFound()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await Service.GetById(id: 20));
        }
    }
}
