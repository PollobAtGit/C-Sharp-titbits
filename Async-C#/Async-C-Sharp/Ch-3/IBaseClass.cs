using System.Threading.Tasks;

namespace Ch_3
{
    internal interface IBaseClass
    {
        // No async in interface. Implementer can provide that
        Task<string> DoSomethingImportantAsync();
    }
}