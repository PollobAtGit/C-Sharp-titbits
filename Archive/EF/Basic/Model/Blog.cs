using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic.Model
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public double Rating { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
