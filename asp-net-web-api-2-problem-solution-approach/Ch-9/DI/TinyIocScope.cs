using Ch_9.DomainException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Ch_9.DI
{
    public class TinyIocScope : IDependencyScope
    {
        protected TinyIocContainer Container { get; private set; }

        public TinyIocScope(TinyIocContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            Container = container;
        }

        public void Dispose()
        {
            Container = null;
            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            if (Container == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            try
            {
                return Container.Resolve(serviceType);
            }
            catch (TinyIocResolutionException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (Container == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (TinyIocResolutionException)
            {
                return Enumerable.Empty<object>();
            }
        }
    }
}