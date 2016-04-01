using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class AuthorizerGuards
    {
        public static void Authorize<TResource, TAccess>(this IAuthorizer authorizer)
            where TAccess : Access
        {
            if (!authorizer.Grants<TResource, TAccess>())
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TResource, TAccess>(this IAuthorizer authorizer, UserId userId)
            where TAccess : Access
        {
            if (!authorizer.Grants<TResource, TAccess>(userId))
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TResource, TAccess>(this IAuthorizer authorizer, int resourceId)
            where TAccess : Access
        {
            if (!authorizer.Grants<TResource, TAccess>(resourceId))
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TResource, TAccess>(this IAuthorizer authorizer, int resourceId, UserId userId)
            where TAccess : Access
        {
            if (!authorizer.Grants<TResource, TAccess>(resourceId, userId))
                throw new UnauthorizedAccessException();
        }
    }
}
