using System;
using Ch_11.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Model;

namespace Ch_11.Tests
{
    internal class ItemRepositoryFake : IItemRepository
    {
        IList<Item> Items { get; }

        public ItemRepositoryFake()
        {
            Items = new List<Item>
            {
                new Item
                {
                    Id = 10,
                    ItemName = "X",
                    Price = 56m
                }
            };
        }

        public async Task<Item> GetById(int id) => await Task.FromResult(Items.Single(x => x.Id == id));

        public void AddItem(Item newItem)
        {
            if (newItem.Id != 0) throw new InvalidOperationException();

            newItem.Id = Items.Max(x => x.Id) + 10;
            Items.Add(newItem);
        }
    }
}