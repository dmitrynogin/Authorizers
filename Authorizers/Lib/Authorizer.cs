using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public class Authorizer : IAuthorizer
    {
        public Authorizer(IEnumerable<IResourceAuthorizer> authorizers)
        {
            Authorizers = authorizers;
        }

        IEnumerable<IResourceAuthorizer> Authorizers { get; }

        public bool Grants<TResource, TAccess>(int resourceId, UserId userId) 
            where TAccess : Access
        {
            var authorizer = Authorizers
                .OfType<IResourceAuthorizer<TResource, TAccess>>()
                .SingleOrDefault();

            if (authorizer == null)
                throw new NotImplementedException();

            return authorizer.Grants(resourceId, userId);
        }
    }
}
