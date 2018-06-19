using System.Threading.Tasks;

namespace Ch_3
{
    class BaseClass : IBaseClass
    {
        public virtual async Task<string> DoSomethingImportantAsync()
        {
            return await Task.Run(() => "");
        }
    }
}
