using System.Collections.Generic;
using System.Linq;
using WebInterface.Extensions;

namespace WebInterface.Receivers
{
    // assume scientific's calculation is done with even higher precision compared to 
    //general/programmer calculator

    public class ScientificCalculator : ICalculator
    {
        public double Add(IList<double> numbersToAdd) => numbersToAdd.Sum();

        public int Add(IList<int> numbersToAdd) => numbersToAdd.Sum();

        public double Multiply(IList<double> numbersToMultiply) => numbersToMultiply.Multiply();

        public int Multiply(IList<int> numbersToMultiply) => numbersToMultiply.Multiply();
    }
}