using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trips.UI.Operation
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }
}
