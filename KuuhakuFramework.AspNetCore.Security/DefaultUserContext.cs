using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Security
{
    public class DefaultUserContext : IUserContext
    {
        public DefaultUserContext()
        {
            Roles = new List<string>();
            Languages = new string[0];
            Claims = new List<Claim>();
        }

        public IPrincipal Principal { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string IP { get; set; }
        public string[] Languages { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
