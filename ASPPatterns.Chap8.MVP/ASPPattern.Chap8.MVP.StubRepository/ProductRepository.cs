using System;
using System.Collections.Generic;
using System.Linq;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    class ProductRepository : IProductRepository
    {
        public IElectronicShopContext Context { get; }

        public ProductRepository(IElectronicShopContext context)
        {
            Context = context;
        }

        public IList<Product> FindAll()
        {
            return Context.Products.ToList();
        }

        public Product FindBy(int id)
        {
            var product = Context
                .Products

                // TODO: Single or SingleOrDefault?
                .SingleOrDefault(x => x.Id == id);

            if (product != null) product.Description = "some random text";

            return product;
        }
    }
}