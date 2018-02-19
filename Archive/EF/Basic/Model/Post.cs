using System.ComponentModel.DataAnnotations.Schema;

namespace Basic.Model
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        // POIL Primary key by convention
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        // POI: Helps EF to determine which entity is principle
        public int BlogId { get; set; }

        // POI: virtual supports lazy loading
        public virtual Blog Blog { get; set; }
    }
}