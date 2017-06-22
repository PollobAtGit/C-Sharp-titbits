
#define CONTRACTS_FULL

using System;
using System.Data.Linq;
using System.Diagnostics.Contracts;
using System.Linq;
using LINQ_Tutorial.Data;

namespace LINQ_Tutorial.Repository
{
    public class ApplicationContext
    {
        private readonly string _connection;
        private readonly LinqToSqlDataContext _ctx;

        public string ConnectionString => _connection;
        public Table<Department> Departments => _ctx.Departments;

        public ApplicationContext()
        {
            Contract.Requires<Exception>(
                !string.IsNullOrEmpty(
                    System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString()));

            Contract.Ensures(
                !string.IsNullOrEmpty(
                    System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString()));

            _connection =
                System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();

            _ctx = new LinqToSqlDataContext(ConnectionString);
        }

        public ApplicationContext(string connection)
        {
            Contract.Requires<Exception>(!string.IsNullOrEmpty(connection));
            Contract.Ensures(!string.IsNullOrEmpty(_connection));

            _connection = connection;
            _ctx = new LinqToSqlDataContext(ConnectionString);
        }

        public void InsertDepartment(Department department)
        {
            Contract.Requires<Exception>(department != null);
            Contract.Requires<Exception>(!string.IsNullOrEmpty(department.DepartmentName));

            department.DepartmentId = Departments.Count() + 1;
            Departments.InsertOnSubmit(department);
            SubmitChanges();
        }

        public void UpdateDepartment(Department department)
        {
            //Even though local variable department is not being used, there are some business logic relevant 
            //validation is here. So it's worth passing department object

            Contract.Requires<Exception>(department != null);
            Contract.Requires<Exception>(!string.IsNullOrEmpty(department.DepartmentName));
            Contract.Requires<Exception>(department.DepartmentId != 0);

            SubmitChanges();
        }

        public void InsertEmployee(Employee employee)
        {
            Contract.Requires<Exception>(employee != null);
            Contract.Requires<Exception>(!string.IsNullOrEmpty(employee.EmployeeName));
            Contract.Requires<Exception>(employee.DepartmentId != 0);

            employee.EmployeeId = _ctx.Employees.Count() + 1;
            _ctx.Employees.InsertOnSubmit(employee);
            SubmitChanges();
        }

        private void SubmitChanges()
        {
            _ctx.SubmitChanges();
        }

        [ContractInvariantMethod]
        private void Invariant()
        {
            //In case of constructor, Invariant method will be invoked after constructor is invoked
            Contract.Invariant(_ctx != null);
            Contract.Invariant(_ctx.Employees != null);
            Contract.Invariant(Departments != null);
        }
    }
}
