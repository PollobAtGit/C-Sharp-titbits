using System.Threading.Tasks;

namespace Moqs
{
    public class EmailFixer
    {
        private readonly IOffice _office;
        private readonly ICommunicator _communicator;

        public EmailFixer(IOffice office, ICommunicator communicator)
        {
            _office = office;
            _communicator = communicator;
        }

        public async Task FixEmailAsync()
        {
            foreach (var employee in _office.Employees)
            {
                var newEmail = await _communicator.ConfirmEmailAsync(employee);
                employee.Email = newEmail;
            }
        }
    }
}
