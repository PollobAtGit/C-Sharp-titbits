using System;
using Microsoft.Owin.Security;

namespace BookAPI.Authorization
{
    class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        string issuer;

        public CustomJwtFormat(string issuer)
        {
            this.issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}