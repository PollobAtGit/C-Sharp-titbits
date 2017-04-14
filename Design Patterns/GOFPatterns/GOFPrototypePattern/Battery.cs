namespace PrototypePattern
{
    public class Battery
    {
        public decimal Price { get; set; }

        public override string ToString()
        {
            return "\t" + "Battery => " + "\t" + Price;
        }
    }
}
