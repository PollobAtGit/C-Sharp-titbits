using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Product
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Required, StringLength(100), DisplayName("Name")]
        public string CategoryName { get; set; }

        [Required, StringLength(1000), DataType(DataType.MultilineText), DisplayName("Description")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}