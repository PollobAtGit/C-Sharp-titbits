using ASPPatterns.Chap8.MVP.Model;
using System.Collections.Generic;

namespace ASPPattern.Chap8.MVP.Presentation
{
    interface ICategoryProductsView
    {
        Category Category { set; }

        int CategoryId { get; }

        IEnumerable<Product> CategoryProductList { set; }

        IEnumerable<Category> CategoryList { set; }
    }
}
