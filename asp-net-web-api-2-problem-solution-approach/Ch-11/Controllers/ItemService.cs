using System;
using System.Linq;

namespace Ch_11.Controllers
{
    public class ItemService : IService
    {
        public IItemRepository Repository { get; }

        public ItemService()
        {
            Repository = new ItemRepository();
        }

        public Item GetById(int id) => Repository.GetById(id: id);
    }
}