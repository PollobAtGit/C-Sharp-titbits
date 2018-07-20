using System.Collections.Generic;
using Model;

namespace DAL
{
    public class ProductContext
    {
        public static List<Product> Products { get; }

        static ProductContext()
        {
            Products = new List<Product>
            {
                new Product {Id = 1, Name = "Paste"},
                new Product {Id = 2, Name = "Book"}
            };
        }
    }
}