using System.Threading.Tasks;

namespace Moqs
{
    public interface ICommunicator
    {
        Task<IEmail> ConfirmEmailAsync(IEmployee employee);
    }
}