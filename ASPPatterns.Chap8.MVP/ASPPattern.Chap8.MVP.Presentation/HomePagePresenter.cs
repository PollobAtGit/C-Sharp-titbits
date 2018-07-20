using ASPPattern.Chap8.MVP.StubRepository;

namespace ASPPattern.Chap8.MVP.Presentation
{
    public class HomePagePresenter : IHomePagePresenter
    {
        IHomeView View { get; }

        ProductService Service { get; }

        public HomePagePresenter(IHomeView view, ProductService service)
        {
            View = view;
            Service = service;
        }

        public void Display()
        {
            View.TopSellingProducts = Service.GetBestSellingProducts(20);
            View.CategoryList = Service.GetAllCategories();
        }
    }
}
