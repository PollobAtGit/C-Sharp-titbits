using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqCreateDynamicQueryByConcat
{
    internal static class Client
    {
        private static readonly ArrayList Publishers;

        static Client()
        {
            Publishers = new ArrayList
            {
                new Publisher { Name="Fun Books Publisher", WebSite = "https://www.funbooks.com" },
                new Publisher { Name="Joe Publishing", WebSite = "https://www.joe-publishing.org" },
                new Publisher { Name="I Publisher", WebSite = "http://i.org/me" },
            };
        }

        public static void Main()
        {
            IEnumerable<Publisher> publishers = Publishers.OfType<Publisher>();

            //LINQ query can be build more flexibly

            publishers.ByName("Fun").IterateOverSequence<Publisher>();
            publishers.ByName("Publis").IterateOverSequence<Publisher>();

            publishers.ByWebSite(".com").IterateOverSequence<Publisher>();

            publishers.ByName("Publis").ByWebSite(".org").IterateOverSequence<Publisher>();

            publishers.ByName("Publis").ByWebSite(null).IterateOverSequence<Publisher>();
            publishers.ByWebSite(null).ByName("Publis").IterateOverSequence<Publisher>();

            publishers.ByName("Publis").ByWebSite("http:").IterateOverSequence<Publisher>();

            //Build the query from GROUND UP & incrementally

            IEnumerable<Publisher> filteredPublishers = Publishers.OfType<Publisher>();

            //Poi: In the following scenario, suppose based on some condition from UI/Query Parameter 1st condition has been made
            //to search by website. Based on another condition, A NEW CRITERIA (ByName) for search is added here
            filteredPublishers = filteredPublishers.ByWebSite(".org");
            filteredPublishers = filteredPublishers.ByName("Joe");

            filteredPublishers.IterateOverSequence<Publisher>();
        }

        private static IEnumerable<Publisher> ByName(this IEnumerable<Publisher> source, string nameToSearch)
        {
            //Poi: If '!source.Any()' then function shouldn't return. Because the sequence might be populated after the query is created
            //Poi: In case of invalid argument ORIGINAL query is returned

            if(source == null || nameToSearch == null) return source;
            return source.Where<Publisher>(publisher => publisher.Name.Contains(nameToSearch));
        }

        private static IEnumerable<Publisher> ByWebSite(this IEnumerable<Publisher> source, string webSiteToSearch)
        {
            //Poi: If '!source.Any()' then function shouldn't return. Because the sequence might be populated after the query is created
            //Poi: In case of invalid argument ORIGINAL query is returned

            if(source == null || webSiteToSearch == null) return source;
            return source.Where<Publisher>(publisher => publisher.WebSite.Contains(webSiteToSearch));
        }

        private static void IterateOverSequence<TModel>(this IEnumerable<TModel> source)
        {
            if(source == null || !source.Any()) return;

            try
            {
                Console.WriteLine();
                foreach(TModel model in source)
                {
                    Console.WriteLine(model);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private class Publisher
        {
            //Poi: EMPTY name is allowed for Publisher
            public String Name {get; set;}

            //Poi: EMPTY WebSite is allowed for Publisher
            public String WebSite {get; set;}

            public override string ToString() => "Name => " + Name + "\tWebsite => " + WebSite;
        }
    }
}