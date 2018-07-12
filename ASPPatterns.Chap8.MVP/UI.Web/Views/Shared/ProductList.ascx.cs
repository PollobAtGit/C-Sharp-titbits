using ASPPatterns.Chap8.MVP.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace UI.Web.Views.Shared
{
    public partial class ProductList : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetProductsToDisplay(IList<Product> products)
        {
            this.rptProducts.DataSource = products;
            this.rptProducts.DataBind();
        }
    }
}