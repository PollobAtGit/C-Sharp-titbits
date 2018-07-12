using ASPPattern.Chap8.MVP.Presentation;
using ASPPatterns.Chap8.MVP.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using UI.Web.Views.Shared;

namespace UI.Web.Views.Home
{
    public partial class Index : Page
    {
        private IHomePagePresenter Presenter { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            Presenter = new HomePagePresenter(null, null);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Display();
        }

        public IList<Product> TopSellingProduct
        {
            set
            {
                if (value != null)
                    plBestSellingProducts.SetProductsToDisplay(value);
            }
        }

        public IList<Category> CategoryList
        {
            set
            {
                if (Page.Master is Shop)
                {
                    var masterPage = Page.Master as Shop;
                    masterPage.CategoryListControl
                        .SetCategoriesToDisplay(value);
                }
            }
        }
    }
}