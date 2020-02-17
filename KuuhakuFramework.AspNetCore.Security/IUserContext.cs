using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace KuuhakuFramework.AspNetCore.Security
{
    public interface IUserContext
    {
        IPrincipal Principal { get; set; }

        IEnumerable<string> Roles { get; set; }

        string IP { get; set; }

        string[] Languages { get; set; }

        IEnumerable<Claim> Claims { get; set; }
    }
}
