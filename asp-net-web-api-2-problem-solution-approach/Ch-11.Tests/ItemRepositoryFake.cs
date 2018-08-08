using System;
using Ch_11.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Ch_11.Tests
{
    internal class ItemRepositoryFake : IItemRepository
    {
        IList<Item> Items { get; }

        public ItemRepositoryFake()
        {
            Items = new Item[]
            {
                new Item
                {
                    Id = 10,
                    ItemName = "X",
                    Price = 56m
                }
            };
        }

        public Item GetById(int id) => Items.Single(x => x.Id == id);
    }
}