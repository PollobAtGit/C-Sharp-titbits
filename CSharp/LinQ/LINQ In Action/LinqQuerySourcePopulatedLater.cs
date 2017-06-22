using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqQuerySourcePopulatedLater
{
    internal static class Client
    {
        private static IList<Publisher> _publishers;

        static Client()
        {
            _publishers = new List<Publisher>();
        }

        public static void Main()
        {
            IEnumerable<Publisher> filteredPublisherByName = _publishers.ByName("Publisher");
            IEnumerable<Publisher> filteredPublisherByWebSite = _publishers.ByWebSite("http://");
            IEnumerable<Publisher> filteredPublisherByWebSiteAndName = filteredPublisherByName.ByWebSite("https://");

            filteredPublisherByName.IterateOverSequence<Publisher>();
            filteredPublisherByWebSite.IterateOverSequence<Publisher>();
            filteredPublisherByWebSiteAndName.IterateOverSequence<Publisher>();

            PopulatePublisherList();

            filteredPublisherByName.IterateOverSequence<Publisher>();
            filteredPublisherByWebSite.IterateOverSequence<Publisher>();
            filteredPublisherByWebSiteAndName.IterateOverSequence<Publisher>();
        }

        private static void PopulatePublisherList()
        {
            _publishers.Add(new Publisher { Name="Fun Books Publisher", WebSite = "https://www.funbooks.com" });
            _publishers.Add(new Publisher { Name="Joe Publishing", WebSite = "https://www.joe-publishing.org" });
            _publishers.Add(new Publisher { Name="I Publisher", WebSite = "http://i.org/me" });
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

        private static IEnumerable<Publisher> ByName(this IEnumerable<Publisher> source, string nameToSearch = null)
        {
            if(source == null || nameToSearch == null) return source;
            return source.Where<Publisher>(publisher => publisher.Name.Contains(nameToSearch));
        }

        private static IEnumerable<Publisher> ByWebSite(this IEnumerable<Publisher> source, string webSiteToSearch = null)
        {
            if(source == null || webSiteToSearch == null) return source;
            return source.Where<Publisher>(publisher => publisher.WebSite.Contains(webSiteToSearch));
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