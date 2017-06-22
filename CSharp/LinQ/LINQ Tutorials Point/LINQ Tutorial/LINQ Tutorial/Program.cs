using System;
using System.Diagnostics.Contracts;
using System.Linq;
using LINQ_Tutorial.Data;
using LINQ_Tutorial.Repository;

namespace LINQ_Tutorial
{
    static class Program
    {
        private static readonly ApplicationContext Ctx;

        static Program()
        {
            //This will work
            Ctx = new ApplicationContext();
        }

        static void Main(string[] args)
        {
            //InsertEntities();
            UpdateEntities();
        }

        private static void UpdateEntities()
        {
            Contract.Requires<Exception>(Ctx != null);
            Contract.Requires<Exception>(Ctx.Departments != null);
            Contract.Requires<Exception>(Ctx.Departments.Any());

            Department department = Ctx.Departments.SingleOrDefault(dept => dept.DepartmentName == "CSE");

            if (department == null) return;
            department.DepartmentName = "Computer Science Engineering";

            Ctx.UpdateDepartment(department);
        }

        private static void InsertEntities()
        {
            Contract.Requires<Exception>(Ctx != null);
            Contract.Requires<Exception>(Ctx.Departments != null);
            Contract.Requires<Exception>(Ctx.Departments.Any());

            //TODO: Can DepartmentId be made private?
            Ctx.InsertDepartment(new Department { DepartmentId = 0, DepartmentName = "CE" });

            int deptId = Ctx.Departments.First().DepartmentId;
            Ctx.InsertEmployee(new Employee { EmployeeName = "Joe", DepartmentId = deptId });
        }
    }
}
