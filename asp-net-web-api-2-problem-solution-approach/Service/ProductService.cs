using DAL;
using Model;

namespace Service
{
    public class ProductService
    {
        private ProductRepository Repository { get; }

        public ProductService(ProductRepository repository)
        {
            Repository = repository;
        }

        public Product FindById(int id) => Repository.FindBy(x => x.Id == id);
    }
}
