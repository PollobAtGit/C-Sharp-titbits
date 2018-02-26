using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using BookAPI.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BookAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new Initializer());

            ConfigureJsonFormatter();
        }

        void ConfigureJsonFormatter()
        {
            var jsonSetting = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;

            jsonSetting.Formatting = Formatting.Indented;
            jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
