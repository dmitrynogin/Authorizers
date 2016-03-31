using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public interface IAuthorizer
    {
        bool Grants<TData, TPermission>(int id, User user)
            where TPermission : Permission;
    }
}
