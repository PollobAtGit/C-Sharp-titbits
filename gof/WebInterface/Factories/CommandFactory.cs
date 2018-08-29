using System.Collections.Generic;
using WebInterface.Commands;
using WebInterface.Interfaces;

namespace WebInterface.Factories
{
    internal class CommandFactory
    {
        private Dictionary<BinaryOperation, ICalculatorCommand> BinaryOperationCommands { get; }

        public CommandFactory(Interface interfaceInstance)
        {
            BinaryOperationCommands = new Dictionary<BinaryOperation, ICalculatorCommand>
            {
                { BinaryOperation.ADD, new AddCommand(interfaceInstance) },
                { BinaryOperation.MULTIPLY, new MultiplyCommand(interfaceInstance) }
            };
        }

        internal ICalculatorCommand GetCommand(BinaryOperation operation)
        {
            try
            {
                return BinaryOperationCommands[operation];
            }
            catch (KeyNotFoundException exp)
            {
                return Default;
            }
        }

        internal static ICalculatorCommand Default => new DefaultCommand(null);
    }
}