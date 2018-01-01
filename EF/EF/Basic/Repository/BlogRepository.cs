using Basic.Model;
using System.Collections.Generic;

namespace Basic.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public List<Blog> FindByUrl(string url) => null;

        public List<Blog> FindByRating(double rating) => null;

    }
}
