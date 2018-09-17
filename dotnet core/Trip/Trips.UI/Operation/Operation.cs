using System;

namespace Trips.UI.Operation
{
    public class Operation : IOperation, IScopedOperation, ISingletonOperation
    {
        public Guid OperationId { get; }

        public Operation()
        {
            OperationId = Guid.NewGuid();
        }

        //public Operation(Guid id)
        //{
        //    OperationId = id;
        //}
    }
}
