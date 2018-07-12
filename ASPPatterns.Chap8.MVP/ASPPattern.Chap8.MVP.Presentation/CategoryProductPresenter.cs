using ASPPattern.Chap8.MVP.StubRepository;

namespace ASPPattern.Chap8.MVP.Presentation
{
    class CategoryProductPresenter : ICategoryProductsPresenter
    {
        ProductService Service { get; }

        ICategoryProductsView View { get; }

        public CategoryProductPresenter(ICategoryProductsView view, ProductService service)
        {
            View = view;
            Service = service;
        }

        public void Display()
        {
            View.CategoryProductList = Service.GetProductsIn(View.CategoryId);
            View.Category = Service.GetCategoryById(View.CategoryId);
            View.CategoryList = Service.GetAllCategories();
        }
    }
}
