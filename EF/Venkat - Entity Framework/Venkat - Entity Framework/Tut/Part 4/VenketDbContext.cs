using System.Data.Entity;
using Venkat___Entity_Framework.Tut.Part_4.Model;

namespace Venkat___Entity_Framework.Tut.Part_4
{
    //POI: DbContext is in System.Data.Entity

    public class VenketDbContext : DbContext
    {
        //POI: If Web.config doesn't contain any associated connection string, then EF will create a connection
        //string for this context class & will use that but the connection string will not be posted in
        //Web.config file. In this case the DB name will be 
        //'Venkat___Entity_Framework.Tut.Part_4.VenketDbContext'

        public VenketDbContext()
        {

        }

        public DbSet<EmployeePartFour> Employees { get; set; }
        public DbSet<DepartmentPartFour> Departments { get; set; }

        //POI: Ambiguity resolution failure exception will be thrown if & only if the same named entity
        //is placed as DbSet<TModel>
        //public DbSet<Department> MyProperty { get; set; }

        //POI: Otherwise the same named entities can co-exist whithout any issue at-all. So if the same named
        //model has no association with EF then they can co-exist

        public Department MyProperty { get; set; }
    }
}