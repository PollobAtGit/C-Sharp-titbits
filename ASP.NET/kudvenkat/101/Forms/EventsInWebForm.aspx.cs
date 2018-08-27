using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _101.Forms
{
    public partial class EventsInWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Application (...HttpApplicationState...) is available for all users
            var userCount = Application.GetFromStorage(AppSettings.AppTotalUser);
            if (userCount != null)
                txtApplicationUserCount.Text = userCount.ToString();
        }
    }
}