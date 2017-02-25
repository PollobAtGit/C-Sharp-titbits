using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqDynamicQueryByLambda
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
            string nameToSearch = "Publisher";
            string webSiteToSearch = "http://";

            Func<Publisher, bool> predicateForNameSearch = pub => pub.Name.Contains(nameToSearch);
            Func<Publisher, bool> predicateForWebSiteSearch = pub => pub.WebSite.Contains(webSiteToSearch);

            IEnumerable<Publisher> filteredPublisherByName = _publishers.SearchBy(predicateForNameSearch);
            IEnumerable<Publisher> filteredPublisherByWebSite = _publishers.SearchBy(predicateForWebSiteSearch);

            IEnumerable<Publisher> filteredPublisherByWebSiteAndName = filteredPublisherByName
                                                                        .SearchBy(pub => pub.WebSite.Contains("https://"));

            PopulatePublisherList();

            filteredPublisherByName.IterateOverSequence<Publisher>();
            filteredPublisherByWebSite.IterateOverSequence<Publisher>();
            filteredPublisherByWebSiteAndName.IterateOverSequence<Publisher>();

            nameToSearch = "Fun";

            //Poi: Changing bound variable value changes the resultset
            filteredPublisherByName.IterateOverSequence<Publisher>();

            //Poi: Changing bound variable value changes the resultset
            webSiteToSearch = "https://";
            filteredPublisherByWebSite.IterateOverSequence<Publisher>();
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

        private static IEnumerable<Publisher> SearchBy(this IEnumerable<Publisher> source, Func<Publisher, bool> predicate)
        {
            if(source == null || predicate == null) return source;
            return source.Where<Publisher>(predicate);
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