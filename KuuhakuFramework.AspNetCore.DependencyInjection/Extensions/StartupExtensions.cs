using KuuhakuFramework.AspNetCore.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KuuhakuFramework.AspNetCore.DependencyInjection.Extensions
{
    public static class StartupExtensions
    {
        public static void AddUserContext(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserContextLoader, DefaultUserContextLoader>();
            services.AddScoped<IUserContext>(x =>
            {
                var userContext = new DefaultUserContext();
                x.GetService<IUserContextLoader>()?.Load(userContext);
                return userContext;
            });
        }

        public static void AddEvents(this IServiceCollection services)
        {
            var types = Microsoft.Extensions.DependencyInjection.AssemblyExtensions
                            .GetAllLoadedAssembliesTypes(x => x.GetCustomAttribute<InjectAttribute>() != null)
                            .Where(x => typeof(IEvent<>));
        }
    }
}
