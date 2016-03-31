using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public static class AuthorizerExtensions
    {
        public static bool Grants<TData, TPermission>(this IAuthorizer authorizer)
            where TPermission : Permission =>
            authorizer.Grants<TData, TPermission>(0, User.Authenticated);

        public static bool Grants<TData, TPermission>(this IAuthorizer authorizer, User user)
            where TPermission : Permission =>
            authorizer.Grants<TData, TPermission>(0, user);

        public static bool Grants<TData, TPermission>(this IAuthorizer authorizer, int id)
            where TPermission : Permission =>
            authorizer.Grants<TData, TPermission>(id, User.Authenticated);
    }
}
