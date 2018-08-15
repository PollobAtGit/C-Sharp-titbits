using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        public decimal Price { get; set; }
    }
}