using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstApproach
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DbEntities())
            {
                Post post = new Post
                {
                    //TODO: Make PostID Auto Generated because in DB table it's auto-generated
                    PostID = 2,

                    Body = "JUST BODY",
                    DatePublished = DateTime.Now,
                    Title = "JUST TITLE"
                };

                ctx.Posts.Add(post);
                ctx.SaveChanges();
            }
        }
    }
}
