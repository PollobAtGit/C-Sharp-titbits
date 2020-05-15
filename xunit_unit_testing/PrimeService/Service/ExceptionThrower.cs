using System;
using System.Collections.Generic;
using System.Linq;
using PrimeService.Exception;

namespace PrimeService.Service
{
    public class ExceptionThrower
    {
        public void Throw() => throw new GameException(new NotImplementedException());

        public IEnumerable<int> ThrowExceptionOn_7_During_Yielding()
        {
            foreach (var i in Enumerable.Range(0, 10))
            {
                if (i == 7)
                    throw new GameException(new IndexOutOfRangeException());

                yield return i;
            }
        }

        public IEnumerable<int> ThrowExceptionOn_7()
        {
            var items = new List<int>();

            foreach (var i in Enumerable.Range(0, 10))
            {
                if (i == 7)
                    throw new GameException(new IndexOutOfRangeException());

                items.Add(i);
            }

            return items;
        }
    }
}
