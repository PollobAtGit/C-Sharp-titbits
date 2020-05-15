namespace Moqs
{
    public class FooInvoker
    {
        private readonly IFoo _foo;

        public FooInvoker(IFoo foo)
        {
            _foo = foo;
        }

        public void Invoke()
        {
            _foo.FooMethod();
            _foo.BarMethod();
            _foo.BazMethod();
        }

        public int InvokeAndReturn() => _foo.FooMethodWithReturn();
    }
}
