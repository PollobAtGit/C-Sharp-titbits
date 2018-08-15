namespace Model
{
    public class Category
    {
        public string Name { get; set; }

        public override string ToString() => $"Category Name: {Name}";
    }
}