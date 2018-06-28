    namespace ASPPatterns.Chap8.MVP.Model
{
    public class Product
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }
    }
}