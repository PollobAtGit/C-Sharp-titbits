using WebInterface.Interfaces;
using WebInterface.Receivers;

namespace WebInterface.Commands
{
    internal interface ICalculatorCommand
    {
        ICalculator Calculator { get; }

        Interface Interface { get; }

        double Execute();
    }
}