using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch_11.Controllers
{
    internal class ItemRepository : IItemRepository
    {
        ItemDbContext Context { get; }

        public ItemRepository()
        {
            Context = new ItemDbContext();
        }

        public Item GetById(int id) => Context.Items.ToList().Single(x => x.Id == id);
    }
}