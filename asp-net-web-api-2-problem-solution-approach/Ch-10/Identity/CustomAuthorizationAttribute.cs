using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ch_10.Identity
{
    // POI: FilterAttribute makes it a filter and an attribute
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        private IList<string> Users { get; }
        private IList<string> Roles { get; }

        public CustomAuthorizationAttribute()
        {
            Users = new List<string>();
            Roles = new List<string>();
        }

        public bool AllowMultiple => false;

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            throw new NotImplementedException();
        }

        // POI: virtual(s) can't be private
        protected virtual bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

#pragma warning disable CC0001 // You should use 'var' whenever possible.
            IPrincipal user = actionContext.RequestContext.Principal;
#pragma warning restore CC0001 // You should use 'var' whenever possible.

            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
                return false;

            // POI: Why IPrincipal doesn't name name rather IIdentity has name?
            if (!Users.Any() || !Users.Any(x => string.Equals(x, user.Identity.Name, StringComparison.InvariantCultureIgnoreCase)))
                return false;

            // POI: IPrincipal doesn't have name but has role on the other hand IIdentity 
            //doesn't have role but has user name

            if (!Roles.Any() || !Roles.Any(user.IsInRole))
                return false;

            return true;
        }
    }
}