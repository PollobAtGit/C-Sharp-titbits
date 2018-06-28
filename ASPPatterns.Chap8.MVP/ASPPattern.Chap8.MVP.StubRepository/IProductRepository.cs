using System.Collections.Generic;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    public interface IProductRepository : IRepository
    {
        IList<Product> FindAll();

        Product FindBy(int id);
    }
}