namespace Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Category: {Category}";
    }
}
