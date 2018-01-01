using Basic.Model;
using System.Collections.Generic;

namespace Basic.Repository
{
    public class PostRepository : Repository<Post>
    {
        public List<Post> FindByTitle(string title) => null;

        public List<Post> FindByContent(string title) => null;
    }
}
