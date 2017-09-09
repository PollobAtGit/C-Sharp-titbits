namespace EF_102
{
    using EF_102.Context;
    using System.Linq;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFContext())
            {
                if(context.Categories.Any())
                {
                    WriteLine("Categoy Exists");
                }
                else
                {
                    WriteLine("Categoy Doesn't Exist");
                }
            }
        }
    }
}
