using System.Threading.Tasks;

namespace Ch_3
{
    class DerivedClass : BaseClass
    {
        // Overriden method doesn't contain async. So that's not part of the signature itself
        public override Task<string> DoSomethingImportantAsync()
        {
            return base.DoSomethingImportantAsync();
        }
    }
}