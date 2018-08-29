using System.Collections.Generic;

namespace WebInterface.Receivers
{
    public interface IAddable
    {
        int Add(IList<int> numbersToAdd);

        double Add(IList<double> numbersToAdd);
    }
}