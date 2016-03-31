using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class AuthorizerExtensions
    {
        public static bool Grants<TResource, TPermission>(this IAuthorizer authorizer)
            where TPermission : Permission =>
            authorizer.Grants<TResource, TPermission>(0, UserId.Authenticated);

        public static bool Grants<TResource, TPermission>(this IAuthorizer authorizer, UserId userId)
            where TPermission : Permission =>
            authorizer.Grants<TResource, TPermission>(0, userId);

        public static bool Grants<TResource, TPermission>(this IAuthorizer authorizer, int resourceId)
            where TPermission : Permission =>
            authorizer.Grants<TResource, TPermission>(resourceId, UserId.Authenticated);
    }
}
