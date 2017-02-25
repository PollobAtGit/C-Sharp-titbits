using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqDynamicQueryWithMutableVariable
{
    internal static class Client
    {
        private static ArrayList Publishers;

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
            SearchPublisherByDomainName(".org").IterateOverSequence<Publisher>();
            SearchPublisherByDomainName(".com").IterateOverSequence<Publisher>();
            SearchPublisherByDomainName(".me").IterateOverSequence<Publisher>();

            //Poi: Consider the above examples here too. In this case it's evident that the local variable value isn't har codedly bound to the
            //query

            string domainToSearchFor = ".org";
            IEnumerable<Publisher> dotPublishers = Publishers
                                                    .OfType<Publisher>()
                                                    .Where<Publisher>(publisher => publisher.WebSite.Contains(domainToSearchFor));

            dotPublishers.IterateOverSequence<Publisher>();

            domainToSearchFor = ".com";

            //Poi: dotPublishers has the same query but the only changed value is the variable value & based on that variable value
            //query result is different
            dotPublishers.IterateOverSequence<Publisher>();

            domainToSearchFor = ".me";
            dotPublishers.IterateOverSequence<Publisher>();
        }

        //Poi: Filtering is dependent on a local variable which is passed via argument
        private static IEnumerable<Publisher> SearchPublisherByDomainName(string domainToSearchFor)
        {
            return Publishers
                .OfType<Publisher>()
                .Where<Publisher>(publisher => publisher.WebSite.Contains(domainToSearchFor));
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
            public String Name {get; set;}
            public String WebSite {get; set;}

            public override string ToString()
            {
                return Name;
            }
        }
    }
}