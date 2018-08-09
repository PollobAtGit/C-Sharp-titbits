using Ch_11.Controllers;
using DAL;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_11.Tests
{
    class ItemsServiceFake : IService
    {
        public IItemRepository Repository { get; }

        public ItemsServiceFake()
        {
            Repository = new ItemRepositoryFake();
        }

        public async Task<Item> GetById(int id) => await Repository.GetById(id: id);

        public void AddItem(Item newItem)
        {
            Repository.AddItem(newItem);
        }
    }
}
