using System;
using System.Collections.Generic;
using System.Linq;
using AsEnumerable_and_AsQueryable_in_LINQ.Data;

namespace AsEnumerable_and_AsQueryable_in_LINQ
{
    internal static class Program
    {
        private static readonly EmployeeDbDataContext Ctx;

        static Program()
        {
            Ctx = new EmployeeDbDataContext();
        }

        static void Main(string[] args)
        {
            //Poi: This operates as LINQ to SQL
            IQueryable<Employee> filteredEmployees = Ctx.Employees.Where<Employee>(employee => employee.Salary > 200);
            filteredEmployees.IterateOverSequence();

            //Poi: This operates as LINQ to objects
            IEnumerable<Employee> filteredEmployeesEnum = Ctx.Employees
                .AsEnumerable()
                .Where<Employee>(employee => employee.Salary > 200);

            filteredEmployeesEnum.IterateOverSequence();
        }
    }

    //Poi: Extension method must be defined in a TOP LEVEL class
    //Poi: Extension method must be declared in a NON-GENERIC static class
    internal static class QueryableExtension
    {
        public static void IterateOverSequence<TModel>(this IEnumerable<TModel> source)
        {
            Console.WriteLine();
            foreach (TModel model in source)
            {
                Console.WriteLine(model);
            }
        }
    }
}
