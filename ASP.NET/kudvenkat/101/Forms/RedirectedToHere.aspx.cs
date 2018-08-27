using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _101.Forms
{
    public partial class RedirectedToHere : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var secretKeyValue = ViewState[AppSettings.SecretKeyKeyName];
                if (secretKeyValue != null)
                    secretKeyKeyValueFromViewStateWebForm.Text = secretKeyValue.ToString();
                else
                    secretKeyKeyValueFromViewStateWebForm.Text = "secret key not set";

                var nid = Session.GetFromStorage(AppSettings.UserNationalId);
                if (nid != null)
                    txtSessionIdFromOriginalPage.Text = nid.ToString();
                else
                    txtSessionIdFromOriginalPage.Text = "national id is not set";
            }
        }
    }
}