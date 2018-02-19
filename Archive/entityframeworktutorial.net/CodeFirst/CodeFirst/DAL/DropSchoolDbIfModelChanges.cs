namespace CodeFirst.DAL
{
    using CodeFirst.Model;
    using System.Collections.Generic;
    using System.Data.Entity;

    // POI: DropCreateDatabaseIfModelChanges is a generic Type & DropSchoolDbIfModelChanges is not generic
    // So the context has to be passed as the Open Type

    class DropSchoolDbAlways : DropCreateDatabaseAlways<SchoolContext>
    {
        // POI: SchoolContext is passed as argument
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
