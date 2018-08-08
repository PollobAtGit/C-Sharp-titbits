using Ch_11.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ch_11.Tests
{
    public class ItemControllerTests
    {
        ItemsController Controller { get; }

        public ItemControllerTests()
        {
            Controller = new ItemsController(new ItemsServiceFake());
        }

        [Fact]
        public void ActionMustReturnItemById()
        {
            var item = Controller.Get(id: 10);

            Assert.NotNull(item);
        }

        [Fact]
        public void ActionMustThrowExceptionWhenItemIdIsInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => Controller.Get(id: 56));
        }
    }
}
