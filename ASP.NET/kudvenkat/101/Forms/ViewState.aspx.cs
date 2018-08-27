using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _101.Forms
{
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                incrementedValue.Text = "-1";

                /*
                    value from view state will be passed from one request to another
                    request by asp.net
                    essentially the values of view state are passed to client which
                    in turn sends back the data to server for further request(s)
                    so it's like cookie but not using cookie at all
                    data is passed as base64 encoded to client in a hidden field
                */

                ViewState[AppSettings.SecretKeyKeyName] = Guid.NewGuid();

                if (Session != null)
                {
                    var nationalId = Session.GetFromStorage(AppSettings.UserNationalId);
                    if (nationalId == null)
                        Session.SetToStorage(AppSettings.UserNationalId, Guid.NewGuid());
                }
            }

            nid.Text = Session.GetFromStorage(AppSettings.UserNationalId).ToString();
        }

        protected void btnIncr_Click(object sender, EventArgs e)
        {
            var previousInt = incrementedValue.Text;
            if (!string.IsNullOrWhiteSpace(previousInt))
            {
                var nextInt = int.Parse(previousInt) + 1;
                incrementedValue.Text = nextInt.ToString();

                lblPreviousInt.Text = previousInt;

                var secretKey = ViewState[AppSettings.SecretKeyKeyName];

                if (!string.IsNullOrWhiteSpace(secretKey?.ToString()))
                    lblSecretKey.Text = secretKey.ToString();
            }
        }

        protected void redirectTo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./RedirectedToHere");
        }
    }
}