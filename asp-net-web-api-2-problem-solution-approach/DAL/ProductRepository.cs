using System;
using System.Linq;
using Model;
using System.Collections.Generic;

namespace DAL
{
    public class ProductRepository
    {
        public Product FindBy(Func<Product, bool> cond)
        {
            // TODO: Change Single may be 
            return ProductContext.Products.Single(cond);
        }

        public IList<Product> GetAll => ProductContext.Products.ToList();
    }
}
