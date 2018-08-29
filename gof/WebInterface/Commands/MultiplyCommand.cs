using WebInterface.Commands;
using WebInterface.Interfaces;

namespace WebInterface.Factories
{
    internal class MultiplyCommand : CalculatorCommand
    {
        public MultiplyCommand(Interface interfaceInstance) : base(interfaceInstance) { }

        public override double Execute() => Calculator.Multiply(Interface.Parse());
    }
}