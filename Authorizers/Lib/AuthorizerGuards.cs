using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class AuthorizerGuards
    {
        public static void Authorize<TResource, TPermission>(this IAuthorizer authorizer)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TResource, TPermission>())
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TResource, TPermission>(this IAuthorizer authorizer, UserId userId)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TResource, TPermission>(userId))
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TResource, TPermission>(this IAuthorizer authorizer, int resourceId)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TResource, TPermission>(resourceId))
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TResource, TPermission>(this IAuthorizer authorizer, int resourceId, UserId userId)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TResource, TPermission>(resourceId, userId))
                throw new UnauthorizedAccessException();
        }
    }
}
