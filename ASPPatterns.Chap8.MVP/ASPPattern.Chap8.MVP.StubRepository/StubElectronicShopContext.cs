using System.Collections.Generic;
using System.Linq;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    public class DataElectronicShopContext : IElectronicShopContext
    {
        public IQueryable<Product> Products { get; }
        public IQueryable<Category> Categories { get; }

        public DataElectronicShopContext()
        {
            var categories = new List<Category>();

            var hatCategory = new Category { Id = 1, Name = "Hats" };
            var gloveCategory = new Category { Id = 2, Name = "Gloves" };
            var scarfCategory = new Category { Id = 3, Name = "Scarfs" };

            categories.Add(hatCategory);
            categories.Add(gloveCategory);
            categories.Add(scarfCategory);

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "BaseBall Cap",
                    Price = 9.99m,
                    Category = hatCategory
                },

                new Product
                {
                    Id = 2,
                    Name = "Flat Cap",
                    Price = 5.99m,
                    Category = hatCategory
                },

                new Product
                {
                    Id = 3,
                    Name = "Top Hat",
                    Price = 6.99m,
                    Category = hatCategory
                },

                new Product
                {
                    Id = 4,
                    Name = "Mitten",
                    Price = 10.99m,
                    Category = gloveCategory
                },

                new Product
                {
                    Id = 5,
                    Name = "Fingerless Glove",
                    Price = 13.99m,
                    Category = gloveCategory
                },
                new Product
                {
                    Id = 6,
                    Name = "Leather Glove",
                    Price = 7.99m,
                    Category = gloveCategory
                },
                new Product
                {
                    Id = 7,
                    Name = "Silk Scarf",
                    Price = 23.99m,
                    Category = scarfCategory
                },
                new Product
                {
                    Id = 8,
                    Name = "Woolen",
                    Price = 14.99m,
                    Category = scarfCategory
                }
            };

            Categories = categories.AsQueryable();
            Products = products.AsQueryable();
        }
    }
}