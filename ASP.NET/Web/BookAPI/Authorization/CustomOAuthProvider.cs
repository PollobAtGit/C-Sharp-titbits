using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace BookAPI.Authorization
{
    class CustomOAuthProvider : IOAuthAuthorizationServerProvider
    {
        public Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            throw new NotImplementedException();
        }

        public Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            throw new NotImplementedException();
        }
    }
}