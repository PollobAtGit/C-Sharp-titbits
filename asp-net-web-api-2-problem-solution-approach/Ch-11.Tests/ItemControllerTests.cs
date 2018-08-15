using Ch_11.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Xunit;

namespace Ch_11.Tests
{
    public class ItemControllerTests
    {
        ItemsController Controller { get; }

        public ItemControllerTests()
        {
            Controller = new ItemsController(new ItemsServiceFake())
            {
                Request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost/api/items")
                }
            };
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

        [Fact]
        public void PostActionMustCreateItemAndReturnARedirectUrl()
        {
            var response = Controller.Post(new Item
            {
                ItemName = "t",
                Price = 100.6m
            });
            var redirectResponse = response as RedirectResult;
            var redirectionUrl = "http://localhost/api/items/20";

            Assert.NotNull(redirectResponse);
            Assert.Equal(redirectResponse.Location.AbsoluteUri, redirectionUrl);
        }

        [Fact]
        public void PostActionMustThrowModelErrorIfExists()
        {
            Controller.ModelState.AddModelError("Item Id", "Item id is given. It must not be given ");

            var response = Controller.Post(new Item
            {
                ItemName = "t",
                Price = 100.6m
            });

            var redirectResponse = response as RedirectResult;

            Assert.Null(redirectResponse);
            Assert.True(false, "Complete error testing");
        }
    }
}
