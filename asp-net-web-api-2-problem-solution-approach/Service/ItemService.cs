using DAL;
using Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class ItemService : IService
    {
        public IItemRepository Repository { get; }

        public ItemService()
        {
            Repository = new ItemRepository();
        }

        public Task<Item> GetById(int id) => Repository.GetById(id: id);

        public void AddItem(Item newItem)
        {
            Repository.AddItem(newItem);
        }
    }
}