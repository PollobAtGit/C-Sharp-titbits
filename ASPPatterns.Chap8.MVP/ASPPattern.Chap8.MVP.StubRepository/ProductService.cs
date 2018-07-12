using System.Collections.Generic;
using System.Linq;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    public class ProductService
    {
        private ICategoryRepository CategoryRepository { get; set; }

        private IProductRepository ProductRepository { get; set; }

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

        // TODO: Notice the difference in naming between Repository & Service
        public IList<Product> GetAllProducts() => ProductRepository.FindAll().ToList();

        public Product GetProductById(int id) => ProductRepository.FindBy(id);

        public IList<Category> GetAllCategories() => CategoryRepository.FindAll().ToList();

        public Category GetCategoryById(int id) => CategoryRepository.FindById(id);

        public IList<Product> GetBestSellingProducts(int takeCount) =>
            ProductRepository.FindAll().OrderBy(x => x.Rating).Take(takeCount).ToList();

        public IList<Product> GetProductsIn(int categoryId) =>
            ProductRepository
            .FindAll()
            .Where(x => x.Category.Id == categoryId)
            .ToList();
    }
}
