using System.Collections.Generic;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.Presentation.Basket
{
    public interface IBasketView
    {
        IEnumerable<Product> BasketItems { set; }
        IList<Category> CategoryList { set; }
    }
}