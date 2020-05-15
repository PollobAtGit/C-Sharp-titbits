using System.Threading.Tasks;

namespace Moqs
{
    public class EmailSender
    {
        private readonly IOffice _office;
        private readonly IEmailServer _emailServer;

        public EmailSender(IOffice office, IEmailServer emailServer)
        {
            _office = office;
            _emailServer = emailServer;
        }

        public async Task SendAsync() => await _emailServer.SendAsync(_office.ChiefExecutiveOfficer.Email.Address);
    }

    public interface IEmailServer
    {
        Task SendAsync(string emailAddress);
    }
}
