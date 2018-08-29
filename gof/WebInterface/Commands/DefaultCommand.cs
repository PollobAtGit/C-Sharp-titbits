using System;
using WebInterface.Interfaces;

namespace WebInterface.Commands
{
    internal class DefaultCommand : CalculatorCommand
    {
        public DefaultCommand(Interface interfaceInstance) : base(interfaceInstance) { }

        public override double Execute()
        {
            throw new NotImplementedException();
        }
    }
}