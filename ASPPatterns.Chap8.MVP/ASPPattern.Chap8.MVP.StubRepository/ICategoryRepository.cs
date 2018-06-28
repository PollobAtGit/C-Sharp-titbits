using System.Collections.Generic;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    public interface ICategoryRepository : IRepository
    {
        IList<Category> FindAll();

        Category FindById(int id);
    }
}
