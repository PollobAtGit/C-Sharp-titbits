using WebInterface.Interfaces;

namespace WebInterface.Commands
{
    internal class AddCommand : CalculatorCommand
    {
        public AddCommand(Interface interfaceInstance) : base(interfaceInstance) { }

        // TODO: execute should be void (i think)
        public override double Execute() => Calculator.Add(Interface.Parse());
    }
}