using Ch_11.Controllers;
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

        public Item GetById(int id) => Repository.GetById(id: id);
    }
}
