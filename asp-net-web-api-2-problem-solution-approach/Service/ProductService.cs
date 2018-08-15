using DAL;
using Model;
using System.Collections.Generic;

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

        public IList<Product> FindAll => Repository.GetAll;
    }
}
