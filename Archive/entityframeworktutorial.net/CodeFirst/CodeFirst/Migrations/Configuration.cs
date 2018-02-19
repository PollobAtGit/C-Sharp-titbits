namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    // POI: Relative import statement is valid. It works because we are currently in 'CodeFirst.Migrations'
    using DAL;
    using CodeFirst.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            // POI: AddRange takes a List as argument
            context.Students.AddRange(new List<Student>
            {
                new Student
                {
                    StudentName = "Master",
                    Standard = new Standard
                    {
                        StandardName = "V"
                    }
                },
                new Student
                {
                    StudentName = "Conan",
                    Standard = new Standard
                    {
                        StandardName = "VI"
                    }
                }
            });

            context.Employees.AddRange(new List<Employee>
            {
                new Employee
                {
                    EmployeeName = "Shinna",
                    Email = "shinna@some.com",
                    PhoneNumber = "01234567989"
                }
            });

            context.SaveChanges();

            // POI: Best approach is to pass the context to base method
            base.Seed(context);
        }
    }
}
