using System.Linq;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    public interface IElectronicShopContext
    {
        IQueryable<Product> Products { get; }

        IQueryable<Category> Categories { get; }
    }
}