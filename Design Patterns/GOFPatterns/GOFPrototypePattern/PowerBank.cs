namespace PrototypePattern
{
    public class PowerBank : Product
    {
        public PowerBank()
        {
            Type = ProductType.ELECTRONIC;
        }

        public PowerBank(ProductType type)
        {
            Type = type;
        }

        public override Product Clone()
        {
            return this.MemberwiseClone() as Product;
        }
    }
}
