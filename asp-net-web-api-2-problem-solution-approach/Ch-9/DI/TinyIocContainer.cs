using System;
using System.Collections.Generic;

namespace Ch_9.DI
{
    // Not sure: TinyIocScope & TinyIocResolver are adapters for TinyIocContainer?
    public class TinyIocContainer
    {
        public object Resolve(Type serviceType)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<object> ResolveAll(Type serviceType)
        {
            throw new NotImplementedException();
        }

        internal TinyIocContainer GetChildContainer()
        {
            throw new NotImplementedException();
        }
    }
}