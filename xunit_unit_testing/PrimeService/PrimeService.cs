using System;

namespace PrimeService
{
    public class PrimeFinderService
    {
        public bool IsPrime(int candidate)
        {
            if (candidate == 1)
                return false;

            if (candidate == 2)
                return true;

            throw new NotImplementedException(message: "not implemented ...");
        }
    }
}
