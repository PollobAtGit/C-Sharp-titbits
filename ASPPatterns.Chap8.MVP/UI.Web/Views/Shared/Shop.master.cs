using System;
using System.Web.UI;

namespace UI.Web.Views.Shared
{
    public partial class Shop : MasterPage
    {
        public CategoryList CategoryListControl => this.CategoryListUiControl;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}