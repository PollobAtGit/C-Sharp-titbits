using ASPPattern.Chap8.MVP.StubRepository;

namespace ASPPattern.Chap8.MVP.Presentation.Basket
{
    class BasketPresenter : IBasketPresenter
    {
        public IBasketView View { get; }
        public ProductService Service { get; }
        public IBasket Basket { get; }

        public BasketPresenter(IBasketView view,
            ProductService service,
            IBasket basket)
        {
            View = view;
            Service = service;
            Basket = basket;
        }

        public void Display()
        {
            View.BasketItems = Basket.Items;
            View.CategoryList = Service.GetAllCategories();
        }
    }
}
