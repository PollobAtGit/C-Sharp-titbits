using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.Product;
using System.Web.ModelBinding;
using DAL.Context;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Product GetProductDetails([QueryString("productID")] int? id)
        {
            if (!id.HasValue) Response.Redirect("/");

            using (var context = new Context())
            {
                return context.Products.Where(x => x.ProductId == id.Value).Single();
            }
        }
    }
}