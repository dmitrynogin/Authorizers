using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib
{
    public interface IAuthenticator
    {
        int CurrentUserId { get; }
        int InteractiveUserId { get; }
    }
}
