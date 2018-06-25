using System;
using System.Linq;
using Model;

namespace DAL
{
    public class ProductRepository
    {
        public Product FindBy(Func<Product, bool> cond)
        {
            // TODO: Change Single may be 
            return ProductContext.Products.Single(cond);
        }
    }
}
