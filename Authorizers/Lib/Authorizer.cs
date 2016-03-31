using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public class Authorizer : IAuthorizer
    {
        public Authorizer(IEnumerable<IPermissionAuthorizer> authorizers)
        {
            Authorizers = authorizers;
        }

        IEnumerable<IPermissionAuthorizer> Authorizers { get; }

        public bool Grants<TData, TPermission>(int id, User user) where TPermission : Permission
        {
            var authorizer = Authorizers.OfType<IPermissionAuthorizer<TData, TPermission>>().SingleOrDefault();
            if (authorizer == null)
                throw new NotImplementedException();

            return authorizer.Grants(id, user);
        }
    }
}
