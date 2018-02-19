namespace PrototypePattern
{
    public class FreezingProperty : CloneableProduct
    {
        public double FreezingPoint { get; set; }

        public override object Clone()
        {
            //POI: If this type had any reference type than we would need to perform a deep copy 
            //on that member also
            return this.MemberwiseClone() as CloneableProduct;
        }

        public override string ToString()
        {
            return "\t" + "FreezingPoint => " + "\t" + FreezingPoint;
        }
    }
}
