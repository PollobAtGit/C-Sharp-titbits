using ASPPattern.Chap8.MVP.Presentation.Basket;
using ASPPattern.Chap8.MVP.StubRepository;

namespace ASPPattern.Chap8.MVP.Presentation
{
    class ProductDetailPresenter : IProductDetailsPresenter
    {
        public ProductService Service { get; }

        public IProductDetailsView View { get; }

        public IPageNavigator Navigator { get; }

        public IBasket Basket { get; }

        public ProductDetailPresenter(
            IProductDetailsView view,
            ProductService service,
            IBasket basket,
            IPageNavigator navigator)
        {
            Service = service;
            View = view;
            Basket = basket;
            Navigator = navigator;
        }

        public void AddProductToBasketAndShowBasketPage()
        {
            Basket
                .Add(Service
                    .GetProductById(View.ProductId));

            Navigator.NavigateTo(PageDirectory.Basket);
        }

        public void Display()
        {
            var product = Service.GetProductById(View.ProductId);

            View.Name = product.Name;
            View.Description = product.Description;
            View.Price = product.Price;

            View.CategoryList = Service.GetAllCategories();
        }
    }
}
