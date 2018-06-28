using System.Collections.Generic;
using System.Linq;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPattern.Chap8.MVP.StubRepository
{
    class CategoryRepository : ICategoryRepository
    {
        public IElectronicShopContext Context { get; }

        public CategoryRepository(IElectronicShopContext context)
        {
            Context = context;
        }

        public IList<Category> FindAll()
        {
            return Context.Categories.ToList();
        }

        public Category FindById(int id)
        {
            return Context.Categories.FirstOrDefault(x => x.Id == id);
        }
    }
}