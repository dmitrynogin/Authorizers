using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public interface IAuthorizer
    {
        bool Grants<TResource, TPermission>(int resourceId, UserId userId)
            where TPermission : Permission;
    }
}
