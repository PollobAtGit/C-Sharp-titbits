using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    public class HelloService : IHelloService
    {
        public void DoAnotherWork()
        {
            throw new NotImplementedException();
        }

        public string Transform(string name) => name.ToUpper();
    }
}
