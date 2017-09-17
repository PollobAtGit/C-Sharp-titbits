using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    // POI: internal interface not public

    [ServiceContract]
    interface IHelloService
    {
        [OperationContract]
        string Transform(string name);

        // POI: Not marked as operation contract
        void DoAnotherWork();
    }
}
