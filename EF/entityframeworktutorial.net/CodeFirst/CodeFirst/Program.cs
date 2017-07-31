using CodeFirst.DAL;
using CodeFirst.Model;
using System.Linq;
using static System.Console;

namespace CodeFirst
{
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
                        StudentName = "Conan"
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
