namespace EF_102.Model
{
    using System.Collections.Generic;

    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
