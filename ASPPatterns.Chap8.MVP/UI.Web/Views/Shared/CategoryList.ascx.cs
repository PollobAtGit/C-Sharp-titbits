using ASPPatterns.Chap8.MVP.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace UI.Web.Views.Shared
{
    public partial class CategoryList : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetCategoriesToDisplay(IList<Category> categories)
        {
            this.rptCategoryList.DataSource = categories;
            this.rptCategoryList.DataBind();
        }
    }
}