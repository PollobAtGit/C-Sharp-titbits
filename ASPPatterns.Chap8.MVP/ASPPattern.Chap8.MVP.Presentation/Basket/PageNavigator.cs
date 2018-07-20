using System;
using System.Web;

namespace ASPPattern.Chap8.MVP.Presentation.Basket
{
    class PageNavigator : IPageNavigator
    {
        public void NavigateTo(PageDirectory page)
        {
            switch (page)
            {
                case PageDirectory.Basket:
                    HttpContext.Current.Response.Redirect(AppSettings.BasketPage);
                    break;
                default:
                    throw new ApplicationException($"Can't navigate to {page.ToString()}");
            }
        }
    }
}
