using System.Collections.Generic;

namespace WebInterface.Interfaces
{
    public interface Interface
    {
        IList<double> Parse();

        BinaryOperation Operation { get; }
    }
}