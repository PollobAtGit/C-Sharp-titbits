using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemRepository : IItemRepository
    {
        ItemDbContext Context { get; }

        public ItemRepository()
        {
            Context = new ItemDbContext();
        }

        public async Task<Item> GetById(int id) => await Context.Items.SingleAsync(x => x.Id == id);

        public void AddItem(Item newItem)
        {
            if (newItem.Id != 0) throw new InvalidOperationException();

            Context.SaveItem(newItem);
        }
    }
}