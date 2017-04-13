namespace PrototypePattern
{
    public abstract class Product
    {
        private ProductType _productTypeEnum = ProductType.NONE;

        public ProductType Type
        {
            get
            {
                return _productTypeEnum;
            }
            set
            {
                _productTypeEnum = value;
            }
        }

        public abstract Product Clone();
    }
}
