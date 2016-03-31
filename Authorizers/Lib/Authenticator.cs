using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class Authenticator
    {
        public static bool IsAuthenticated(this IAuthenticator authenticator) =>
            authenticator.UserId(User.Authentificated) != User.Anonymous.Id;

        public static bool IsImpersonated(this IAuthenticator authenticator) =>
            authenticator.IsAuthenticated() &&
            authenticator.UserId(User.Authentificated) != authenticator.UserId(User.Impersonator);
    }
}
