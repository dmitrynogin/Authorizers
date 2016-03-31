using Authorizers.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Demo
{
    class CompanyAuthorizer : IAuthorizer<Company, Update>
    {
        public bool Grants(int id, User user) => id % 2 != 0;
    }
}
