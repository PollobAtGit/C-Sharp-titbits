using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Context;
using Model.Product;

namespace WingtipToys
{
    public partial class ProductList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IList<Product> Products([QueryString("id")]int? categoryId)
        {
            using (var context = new Context())
            {
                if (!categoryId.HasValue) return context.Products.ToList();
                return context.Products.Where(x => x.CategoryId == categoryId).ToList();
            }
        }
    }
}