using Ch_11.App_Start;
using Ch_11.Controllers;
using Model;
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
                //Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage
                {
                    //Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost/api/items")
                }
            };

            //Controller.Configuration.MapHttpAttributeRoutes();
            //Controller.Configuration.EnsureInitialized();
            //Controller.RequestContext.RouteData =
            //    new HttpRouteData(new HttpRoute(),
            //    new HttpRouteValueDictionary { { "controller", "items" } });
        }

        [Fact]
        public void GetActionWithGivenItemId_Must_ReturnItemIfFound()
        {
            var item = Controller.Get(id: 10);

            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetActionWithGivenItemId_Must_ThrowExceptionIfItemNotFound()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(() => Controller.Get(id: 56));
        }

        [Fact]
        public void PostAction_Must_RedirectToTheNewResource()
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
        public void PostAction_Must_ThrowExceptionIfTheresAnyModelError()
        {
            Controller.ModelState.AddModelError("Item Id", "Item id is given. It must not be given ");

            var response = Controller.Post(new Item
            {
                ItemName = "t",
                Price = 100.6m
            });

            Assert.IsType<InternalServerErrorResult>(response);
            Assert.IsNotType<RedirectResult>(response);
        }
    }
}
