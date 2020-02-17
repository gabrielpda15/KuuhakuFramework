using KuuhakuFramework.AspNetCore.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace KuuhakuFramework.AspNetCore.DependencyInjection
{
    public class DefaultUserContextLoader : IUserContextLoader
    {
        public DefaultUserContextLoader(IHttpContextAccessor contextAccessor)
        {
            this.ContextAccessor = contextAccessor;
        }
        
        public IHttpContextAccessor ContextAccessor { get; }

        public void Load(IUserContext userContext)
        {
            try
            {
                var httpContext = this.ContextAccessor.HttpContext;
                if (httpContext == null) return;

                userContext.Principal = httpContext.User;
                if (httpContext.Request != null)
                {
                    userContext.IP = httpContext.Connection.RemoteIpAddress.ToString();
                    userContext.Languages = httpContext.Request.GetTypedHeaders().AcceptLanguage.Select(x => x.Value.ToString()).ToArray();
                    userContext.Roles = httpContext.User.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Select(x => x.Value);
                    userContext.Claims = httpContext.User.Claims;
                }
            }
            catch { }
        }
    }
}
