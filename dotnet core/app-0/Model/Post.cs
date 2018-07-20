using System.Xml.Serialization;

namespace app_0.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }

        // POI: Resolves circular dependency
        [XmlIgnore]
        public virtual Blog Blog { get; set; }

        public override string ToString() => $"Post Title = {Title} ~ Post Content = {Content}";
    }
}