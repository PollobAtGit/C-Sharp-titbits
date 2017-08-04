namespace CodeFirst
{
    using System.Linq;
    using CodeFirst.DAL;
    using CodeFirst.Model;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var name = "Conan";

                if (!context.Students.Any(s => s.StudentName == name))
                {
                    context.Students.Add(new Student
                    {
                        StudentName = "Conan",
                        Standard = new Standard
                        {
                            StandardName = "IV"
                        }
                    });

                    // TODO: Use 'SaveChangesAsync'
                    context.SaveChanges();
                }

                foreach (var student in context.Students)
                {
                    WriteLine(student);
                }
            }
        }
    }
}
