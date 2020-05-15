using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moqs
{
    public interface IEmployeeRepository
    {
        Task SaveAsync(IEmployee employee);

        Task<IReadOnlyCollection<IEmployee>> GetAllAsync();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<IEmployee> _employees = new List<IEmployee>();

        public async Task SaveAsync(IEmployee employee) => await Task.Run(() => _employees.Add(employee));

        public async Task<IReadOnlyCollection<IEmployee>> GetAllAsync() => await Task.Run(() => _employees.AsReadOnly());
    }
}
