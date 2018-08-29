using WebInterface.Extensions;
using WebInterface.Interfaces;
using WebInterface.Receivers;
using WebInterface.Storage;

namespace WebInterface.Commands
{
    internal abstract class CalculatorCommand : ICalculatorCommand
    {
        public ICalculator Calculator { get; }

        public Interface Interface { get; }

        protected CalculatorCommand(Interface interfaceInstance)
        {
            Calculator = Cache.Get<ICalculator>(AppSettings.CalculatorObjectKey);

            if (Calculator.IsNull())
            {
                Calculator = new GeneralCalculator();
                Cache.Set(AppSettings.CalculatorObjectKey, Calculator);
            }

            Interface = interfaceInstance;
        }

        public abstract double Execute();
    }
}