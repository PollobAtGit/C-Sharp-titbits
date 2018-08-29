using System.Collections.Generic;

namespace WebInterface.Receivers
{
    public interface IMultiplier
    {
        int Multiply(IList<int> numbersToMultiply);

        double Multiply(IList<double> numbersToMultiply);
    }
}