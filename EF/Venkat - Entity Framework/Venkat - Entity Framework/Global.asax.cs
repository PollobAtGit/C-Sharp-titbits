using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Venkat___Entity_Framework.Tut.Part_5;

namespace Venkat___Entity_Framework
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //POI: As the type parameter the context class had been provided

            //POI: Any change is tracked against the context class. One application (like this one)
            //might have multiple contex class & in that case each one context class will manage & track
            //the connection/DB & everything else separately. For instance the strategy mentioned here is
            //applicable only for PartFiveDbContext class. This strategy will not work for others. Other
            //context class's will still throw Exception if EF detects any changes in the schema

            //TODO: What are the other regular usages of Database class?

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PartFiveDbContext>());
        }
    }
}