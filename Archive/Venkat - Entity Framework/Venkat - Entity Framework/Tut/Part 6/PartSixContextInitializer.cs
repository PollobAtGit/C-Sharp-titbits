using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using Venkat___Entity_Framework.Tut.Part_6.Model;

namespace Venkat___Entity_Framework.Tut.Part_6
{
    public class PartSixContextInitializer : DropCreateDatabaseIfModelChanges<PartSixDbContext>
    {
        protected override void Seed(PartSixDbContext context)
        {
            var itDepartmentName = "IT";

            var itDepartment = new PartSixDepartment
            {
                Name = itDepartmentName,
                Location = "NY",
                Employees = new List<PartSixEmployee>
                {
                    new PartSixEmployee
                    {
                        //POI: Not setting Id property because that is an Identity column which will be
                        //populated by EF

                        FirstName = "Mark"
                        , LastName = "Mulali"
                        , Gender = "Male"
                        , Salary = 1000m
                        , JobPosition = "IT Consultant"

                        //POI: Not setting Department or DepartmentId property because they are related
                        //to navigation & so EF will handle the responsibility of populating Department
                        //DepartmentId column

                        //POI: The above may be works only because here we are nesting the entities, 
                        //if they were not nested may be we would have needed to set the 
                        //DepartmentId/Department property
                    },
                    new PartSixEmployee
                    {
                        FirstName = "Mark"
                        , LastName = "Hasting"
                        , Gender = "Male"
                        , Salary = 2000m
                        , JobPosition = "IT Head"
                    }
                }
            };

            var hrDepartment = new PartSixDepartment
            {
                Name = "HR",
                Location = "YS",
                Employees = new List<PartSixEmployee>
                {
                    new PartSixEmployee
                    {
                        FirstName = "Mark"
                        , LastName = "Cuban"
                        , Gender = "Male"
                        , Salary = 3000m
                        , JobPosition = "HR Head"
                    }
                }
            };

            var devDepartment = new PartSixDepartment
            {
                Name = "DEV",
                Employees = new List<PartSixEmployee>
                {
                    new PartSixEmployee
                    {
                        FirstName = "Hishe"
                        , LastName = "Cuban"
                        , Gender = "Male"
                        , Salary = 500m
                        , JobPosition = "HR Junior"
                    }
                }
            };


            //POI: Adding the entities into the context will be enough to add new rows to Db table

            context.Departments.Add(itDepartment);
            context.Departments.Add(hrDepartment);
            context.Departments.Add(devDepartment);

            //POI: Base class will handle the task of inserting the rows into Db table by retrieving
            //entities from context's DbSet

            //TODO: But when exactly is the insertion occurring? Apparently it is not 
            //occurring immediately. If were the commented code below would have worked properly after
            //the base Seed invocation

            base.Seed(context);
        }

        /*
            var itDepartmentId = context.Departments.Single(dept => dept.Name == itDepartmentName).Id;

            var employee = new PartSixEmployee
            {
                FirstName = "All",
                LastName = "The Computer Guy",
                Gender = "Male",
                Salary = 500m,
                JobPosition = "IT Professional",
                DepartmentId = itDepartmentId
            };

            context.Employees.Add(employee);

            base.Seed(context);
         */
    }
}