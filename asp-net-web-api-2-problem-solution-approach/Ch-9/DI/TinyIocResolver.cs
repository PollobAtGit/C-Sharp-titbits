using System;
using System.Web.Http.Dependencies;

namespace Ch_9.DI
{
    public class TinyIocResolver : TinyIocScope, IDependencyResolver
    {
        public TinyIocResolver(TinyIocContainer container) : base(container) { }

        public IDependencyScope BeginScope()
        {
            return new TinyIocScope(Container.GetChildContainer());
        }
    }
}