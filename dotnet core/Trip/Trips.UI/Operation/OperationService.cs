namespace Trips.UI.Operation
{
    public class OperationService
    {
        //public IOperation TransientOperation { get; }

        //public IScopedOperation ScopedOperation { get; }

        //public ISingletonOperation SingletonOperation { get; }

        public Operation Operation { get; }

        public OperationService(
            //IOperation transientOperation,
            //IScopedOperation scopedOperation,
            //ISingletonOperation singletonOperation
            Operation operation
            )
        {
            Operation = operation;
            //TransientOperation = transientOperation;
            //ScopedOperation = scopedOperation;
            //SingletonOperation = singletonOperation;
        }
    }
}
