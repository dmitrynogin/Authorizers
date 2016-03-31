using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class AuthorizerGuards
    {
        public static void Authorize<TData, TPermission>(this IAuthorizer authorizer)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TData, TPermission>())
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TData, TPermission>(this IAuthorizer authorizer, User user)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TData, TPermission>(user))
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TData, TPermission>(this IAuthorizer authorizer, int id)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TData, TPermission>(id))
                throw new UnauthorizedAccessException();
        }

        public static void Authorize<TData, TPermission>(this IAuthorizer authorizer, int id, User user)
            where TPermission : Permission
        {
            if (!authorizer.Grants<TData, TPermission>(id, user))
                throw new UnauthorizedAccessException();
        }
    }
}
