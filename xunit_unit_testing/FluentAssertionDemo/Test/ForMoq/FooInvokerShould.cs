using FluentAssertions;
using Moq;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class FooInvokerShould
    {
        [Fact]
        public void Return_What_IFoo_Returns()
        {
            var fooMock = new Mock<IFoo>();

            var fooInvoker = new FooInvoker(fooMock.Object);

            fooMock
                .SetupSequence(x => x.FooMethodWithReturn())
                .Returns(0)
                .Returns(1)
                .Returns(2);

            fooInvoker.InvokeAndReturn().Should().Be(0);
            fooInvoker.InvokeAndReturn().Should().Be(1);
            fooInvoker.InvokeAndReturn().Should().Be(2);
        }

        [Fact]
        public void Invoke_IFoo_Methods_In_Sequence()
        {
            var fooMock = new Mock<IFoo>(MockBehavior.Strict);

            var sequence = new MockSequence();

            fooMock.InSequence(sequence).Setup(x => x.FooMethod());
            fooMock.InSequence(sequence).Setup(x => x.BarMethod());
            fooMock.InSequence(sequence).Setup(x => x.BazMethod());

            var fooInvoker = new FooInvoker(fooMock.Object);

            fooInvoker.Invoke();
        }
    }
}
