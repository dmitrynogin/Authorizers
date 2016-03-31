using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public class Authorizer : IAuthorizer
    {
        public Authorizer(IEnumerable<IAuthorizer<object, Permission>> authorizers)
        {
            Authorizers = authorizers;
        }

        IEnumerable<IAuthorizer<object, Permission>> Authorizers { get; }

        public bool Grants<TData, TPermission>(int id, User user) where TPermission : Permission
        {
            var authorizer = Authorizers.OfType<IAuthorizer<TData, TPermission>>().SingleOrDefault();
            if (authorizer == null)
                throw new NotImplementedException();

            return authorizer.Grants(id, user);
        }
    }
}
