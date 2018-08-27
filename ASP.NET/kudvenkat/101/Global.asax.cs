using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace _101
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Session is not working. Make it work!
            if (Application != null)
                Application.SetToStorage(AppSettings.AppTotalUser, 1);

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Session_Start is being invoked eahch time there's no associated session id
        void Session_Start(object sender, EventArgs e)
        {
            if (Application == null) return;

            var appUserCount = Application.GetFromStorage(AppSettings.AppTotalUser);
            if (appUserCount != null)
                Application[AppSettings.AppTotalUser] = (int)appUserCount + 1;
        }

        // Session_End is never invoked. Why?
        void Session_End(object sender, EventArgs e)
        {
            if (Application == null) return;

            var appUserCount = Application.GetFromStorage(AppSettings.AppTotalUser);
            if (appUserCount != null)
                Application[AppSettings.AppTotalUser] = (int)appUserCount - 1;
        }
    }
}