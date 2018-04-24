
using System.Collections.Generic;

namespace app_0.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }

        public override string ToString() => $"URL : {Url} ~ {string.Join(", ", Posts)}";
    }
}