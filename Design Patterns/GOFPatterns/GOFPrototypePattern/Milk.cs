namespace PrototypePattern
{
    public class Milk : Product
    {
        public FreezingProperty FreezingProp { get; set; }

        public Milk(FreezingProperty freezProp)
        {
            Type = ProductType.BEVERAGE;
            FreezingProp = freezProp;
        }

        public Milk(ProductType type)
        {
            Type = type;
        }

        public override Product Clone()
        {
            //POI: Shallow clone. After this assignment 'FreezingProp' of cloned instance will
            //refer to the same 'FreezingProp' of 'this' instance
            var clonedMilk = this.MemberwiseClone() as Milk;

            //POI: Deep Clone portion
            clonedMilk.FreezingProp = this.FreezingProp.Clone() as FreezingProperty;

            return clonedMilk as Product;
        }

        public override string ToString()
        {
            return "Product Type =>" + "\t" + Type + "\t" + FreezingProp;
        }
    }
}
