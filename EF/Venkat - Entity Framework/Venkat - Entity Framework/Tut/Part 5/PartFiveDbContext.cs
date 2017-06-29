using System.Data.Entity;
using Venkat___Entity_Framework.Tut.Part_5.Model;

namespace Venkat___Entity_Framework.Tut.Part_5
{
    //POI: DbContext resides in System.Data.Entity

    //TODO: Is System.Data.Entity available via EF nuget package?

    //POI: The context class must be public apparently. Any process in the EF 
    //pipe-line may be initializes the context class. When it's internal the pipeline can't access the 
    //instance & that's what causes the issue

    //TODO: How to deal with the above scenario? Making context class public doesn't seem to be desirable

    public class PartFiveDbContext : DbContext
    {
        public PartFiveDbContext()
        {

        }

        public DbSet<DepartmentPartFive> Departments { get; set; }
        public DbSet<EmployeePartFive> Employees { get; set; }
    }
}