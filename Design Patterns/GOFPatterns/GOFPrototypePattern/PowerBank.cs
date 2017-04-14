namespace PrototypePattern
{
    public class PowerBank : Product
    {
        public Battery Battery { get; set; }

        public PowerBank(Battery battery)
        {
            Type = ProductType.ELECTRONIC;
            Battery = battery;
        }

        //POI: Default parameter must be a compile time constant
        public PowerBank(ProductType type)
        {
            Type = type;
        }

        public override Product Clone()
        {
            return this.MemberwiseClone() as Product;
        }

        public override string ToString()
        {
            return "Product Type =>" + "\t" + Type + "\t" + Battery;
        }
    }
}
