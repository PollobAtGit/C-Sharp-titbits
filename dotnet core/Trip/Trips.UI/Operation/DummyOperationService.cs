namespace Trips.UI.Operation
{
    public class DummyOperationService
    {
        public IOperation TransientOperation { get; }

        public IScopedOperation ScopedOperation { get; }

        public ISingletonOperation SingletonOperation { get; }

        public DummyOperationService(IOperation transientOperation,
            IScopedOperation scopedOperation,
            ISingletonOperation singletonOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
        }
    }
}
