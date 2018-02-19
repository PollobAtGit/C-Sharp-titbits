namespace PrototypePattern
{
    public class PowerBank : CloneableProduct
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

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return "Product Type =>" + "\t" + Type + "\t" + Battery;
        }
    }
}
