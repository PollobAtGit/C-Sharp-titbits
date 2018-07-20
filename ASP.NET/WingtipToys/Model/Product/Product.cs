using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Product
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required, StringLength(100), DisplayName("Name")]
        public string ProductName { get; set; }

        [Required, StringLength(1000), DisplayName("Description"), DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }

        [DisplayName("Price")]
        public decimal? UnitPrice { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}