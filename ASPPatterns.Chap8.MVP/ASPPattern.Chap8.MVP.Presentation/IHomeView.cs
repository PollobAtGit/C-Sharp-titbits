using ASPPatterns.Chap8.MVP.Model;
using System.Collections.Generic;

namespace ASPPattern.Chap8.MVP.Presentation
{
    public interface IHomeView
    {
        IEnumerable<Product> TopSellingProducts { get; set; }

        IEnumerable<Category> CategoryList { get; set; }
    }
}
