namespace PrototypePattern
{
    public class Milk : Product
    {
        public Milk()
        {
            Type = ProductType.BEVERAGE;
        }

        public Milk(ProductType type)
        {
            Type = type;
        }

        public override Product Clone()
        {
            return this.MemberwiseClone() as Product;
        }
    }
}
