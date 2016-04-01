using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class AuthorizerExtensions
    {
        public static bool Grants<TResource, TAccess>(this IAuthorizer authorizer)
            where TAccess : Access =>
            authorizer.Grants<TResource, TAccess>(0, UserId.Authenticated);

        public static bool Grants<TResource, TAccess>(this IAuthorizer authorizer, UserId userId)
            where TAccess : Access =>
            authorizer.Grants<TResource, TAccess>(0, userId);

        public static bool Grants<TResource, TAccess>(this IAuthorizer authorizer, int resourceId)
            where TAccess : Access =>
            authorizer.Grants<TResource, TAccess>(resourceId, UserId.Authenticated);
    }
}
