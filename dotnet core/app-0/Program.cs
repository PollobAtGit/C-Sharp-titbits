using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using app_0.Context;
using app_0.Model;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace app_0
{
    class Program
    {
        static void Main(string[] args)
        {
            // SerializeBlogs();
            // XmlSerializer();
            // DeserializeBlogs();
            // FilterBlogs();
            // FilterBlogsByMethodInvocation();
            // AsNoTracking();
            // ContextTrackerConfig();
            // TrackingIfUsedSomeWhereElse();

            WillBeTrackedIfSameValue();
        }

        private static void WillBeTrackedIfSameValue()
        {
            using (var context = new BloggingContext())
            {
                var b = context.Blogs.First();

                Console.WriteLine(context.Entry(b).State);// Unchanged

                b.Url = "https://www.google.com";

                // POI: Tracked by content
                Console.WriteLine(context.Entry(b).State);// Unchanged
            }
        }

        private static void TrackingIfUsedSomeWhereElse()
        {
            using (var context = new BloggingContext())
            {
                // POI: 1st Blog will be Tracked even though that's not being stored directly (rather indirectly!)
                var a = new { Blog = context.Blogs.First() };

                // Console.WriteLine(context.Entry(new Blog { BlogId = 1 }).State);
                Console.WriteLine(context.Entry(context.Blogs.Local.First()).State);// UnChanged

                // POI: Exception because another Blog with Id 1 already exists
                // context.Blogs.Add(new Blog { BlogId = 1 });
            }
        }

        private static void ContextTrackerConfig()
        {
            using (var context = new BloggingContext())
            {
                // Context level tracking configuration
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var b = context.Blogs.First();
                var p = context.Posts.First();

                Console.WriteLine(context.Entry(b).State);// [Detached]
                Console.WriteLine(context.Entry(p).State);// [Detached]
            }
        }

        private static void ModifyUrl(Blog b) => b.Url = "";

        private static void AsNoTracking()
        {
            using (var context = new BloggingContext())
            {
                var b = context.Blogs.AsNoTracking().First();

                ModifyUrl(b);

                Console.WriteLine(context.Entry(b).State);// [AsNoTracking]: Detached

                context.SaveChanges();

                context.Blogs.ToList().ForEach(x =>
                {
                    context.Entry(x).Collection(y => y.Posts).Load();

                    Console.WriteLine(x);
                });
            }
        }

        private static bool ByName(string url) => new Regex(@".").Match(url).Success;

        private static void FilterBlogsByMethodInvocation()
        {
            using (var context = new BloggingContext())
            {
                // Is the query processed in client?
                // This query is performed in client. If a query can't be transformed to SQL then it will be
                // client side evaluation
                var query = context.Blogs.Where(x => ByName(x.Url));

                Console.WriteLine("Cached blog count: " + context.Blogs.Local.Count);// 0

                query.ToList();

                Console.WriteLine("Cached blog count: " + context.Blogs.Local.Count);// 15
            }
        }

        private static void FilterBlogs()
        {
            using (var context = new BloggingContext())
            {
                var query = context.Blogs.Where(x => x.Url.Contains("https:"));

                Console.WriteLine("Cached blog count: " + context.Blogs.Local.Count);// 0

                query.ToList();

                Console.WriteLine("Cached blog count: " + context.Blogs.Local.Count);// 15
            }
        }

        private static void XmlSerializer()
        {
            using (var context = new BloggingContext())
            {
                Console.WriteLine($"Blog Count : {context.Blogs.Count()}");

                var xmlFormatter = new XmlSerializer(typeof(Blog));
                var xmlWriterStream = new FileStream("blogs.xml", FileMode.Create, FileAccess.Write, FileShare.None);

                context.Blogs.ToList().ForEach(x =>
                {
                    // Explicit Loading. Lazy loading is supported in upgraded dotnet core sdk
                    context.Entry(x).Collection(y => y.Posts).Load();

                    xmlFormatter.Serialize(xmlWriterStream, x);
                });

                Console.WriteLine("DONE");
            }
        }

        private static void DeserializeBlogs()
        {
            var formatter = new BinaryFormatter();

            var readerStream = new FileStream("blogs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);

            var blogs = formatter.Deserialize(readerStream) as List<Blog>;
            readerStream.Close();

            blogs.ForEach(x => Console.WriteLine(x));
        }

        static void SerializeBlogs()
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

                var formatter = new BinaryFormatter();
                var writerStream = new FileStream("blogs.bin", FileMode.Create, FileAccess.Write, FileShare.None);

                context.Blogs.ToList().ForEach(x =>
                {
                    // Explicit Loading. Lazy loading is supported in upgraded dotnet core sdk
                    context.Entry(x).Collection(y => y.Posts).Load();

                    formatter.Serialize(writerStream, x);

                    Console.WriteLine(x);
                });
            }
        }
    }
}
