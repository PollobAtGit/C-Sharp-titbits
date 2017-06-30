using System;
using System.Web.UI.WebControls;

namespace Venkat___Entity_Framework.Tut.Part_7
{
    public partial class PartSeven : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmployeeInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            //POI: Just after insertion of data is done in SQL Server we are refreshing 
            //(via further DataBind) Grid View

            EmployeeGridView.DataBind();
        }
    }
}