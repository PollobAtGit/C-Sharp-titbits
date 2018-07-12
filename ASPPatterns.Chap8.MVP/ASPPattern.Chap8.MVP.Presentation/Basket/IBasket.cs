using ASPPatterns.Chap8.MVP.Model;
using System.Collections.Generic;

namespace ASPPattern.Chap8.MVP.Presentation.Basket
{
    interface IBasket
    {
        IEnumerable<Product> Items { get; }

        void Add(Product product);
    }
}
