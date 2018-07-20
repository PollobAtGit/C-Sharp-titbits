using System.Collections.Generic;
using ASPPatterns.Chap8.MVP.Model;
using System.Web;

namespace ASPPattern.Chap8.MVP.Presentation.Basket
{
    class WebBasket : IBasket
    {
        public IEnumerable<Product> Items => GetBasketProducts();

        private IList<Product> GetBasketProducts()
        {
            var basketSession = HttpContext.Current.Session[AppSettings.SessionKeys.Basket];

            if (!(basketSession is IList<Product>))
                // TODO: Check if it works
                basketSession = new List<Product>();

            // TODO: Check if it works
            return basketSession as IList<Product>;
        }

        public void Add(Product product) =>
            GetBasketProducts().Add(product);
    }
}
