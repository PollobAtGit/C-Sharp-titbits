using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    // Originator
    public class HumanResourceService
    {
        private EmployeeRepository Repository { get; }
        private HumanResourceLedger CareTaker { get; }

        public IList<EmployeeSalary> FetchAllEmployeeSalary =>
            Repository.GetAll().Select(EmployeeSalary.Create).ToList();

        public HumanResourceService()
        {
            Repository = new EmployeeRepository();
            CareTaker = new HumanResourceLedger();
        }

        public EmployeeSalary FetchEmployeeSalaryById(int id) => EmployeeSalary.Create(Repository.GetById(id: id));

        public void ChangeEmployeeSalary(EmployeeSalary employeeSalary)
            => HumanResourceLedger.TrackEmployeeState(ChangeEmployeeSalary(employeeSalary.Id, employeeSalary.Salary));

        public bool RestoreEmployeeSalary(int id) => RestoreEmployeeSalary(HumanResourceLedger.PreviousState(id: id));

        private EmployeeMomento ChangeEmployeeSalary(int employeeId, decimal salary)
        {
            var employee = Repository.GetById(id: employeeId);

            var employeeMomento = EmployeeMomento.Create(employee: employee);

            employee.Salary = salary;

            return employeeMomento;
        }

        private bool RestoreEmployeeSalary(EmployeeMomento momento)
        {
            try
            {
                var employee = Repository.GetById(id: momento.Id);
                employee.NationalId = momento.NatinalId;
                employee.Salary = momento.Salary;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
