using System;
using System.Collections.Generic;
using System.Linq;
using app_0.Context;
using app_0.Model;

namespace app_0
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                Console.WriteLine($"Old Blog Count : {context.Blogs.Count()}");

                var blog = new Blog
                {
                    Url = "https://www.google.com",
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "New Title",
                            Content = "New Content"
                        },
                        new Post
                        {
                            Title = "Another Title",
                            Content = "Another Content"
                        }
                    }
                };

                context.Blogs.Add(blog);
                context.SaveChanges();

                Console.WriteLine($"Current Blog Count : {context.Blogs.Count()}");

                context.Blogs.ToList().ForEach(x =>
                {
                    // Explicit Loading. Lazy loading is supported in upgraded dotnet core sdk
                    context.Entry(x).Collection(y => y.Posts).Load();

                    Console.WriteLine(x);
                });
            }
        }
    }
}
