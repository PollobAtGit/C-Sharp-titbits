using ASPPatterns.Chap8.MVP.Model;
using System.Collections.Generic;

namespace ASPPattern.Chap8.MVP.Presentation
{
    interface IProductDetailsView
    {
        int ProductId { get; }

        string Name { set; }

        decimal Price { set; }

        string Description { set; }

        IEnumerable<Category> CategoryList { set; }
    }
}
