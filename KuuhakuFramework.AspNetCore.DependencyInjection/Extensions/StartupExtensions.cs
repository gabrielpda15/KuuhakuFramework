using KuuhakuFramework.AspNetCore.DependencyInjection.Validation;
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
            var types = GetInjectables(x => typeof(IEvent<>).IsAssignableFrom(x));

            foreach (var type in types)
            {
                services.AddInjectable(type);
            }
        }

        public static void AddRules(this IServiceCollection services)
        {
            var types = GetInjectables(x => typeof(IRule<>).IsAssignableFrom(x));

            foreach (var type in types)
            {
                services.AddInjectable(type);
            }
        }

        private static IEnumerable<Type> GetInjectables(Func<Type, bool> predicate)
        {
            return Microsoft.Extensions.DependencyInjection.AssemblyExtensions
                            .GetAllLoadedAssembliesTypes(x => x.GetCustomAttribute<InjectAttribute>() != null)
                            .Where(predicate);
        }

        private static void AddInjectable(this IServiceCollection services, Type type)
        {
            switch (type.GetCustomAttribute<InjectAttribute>().Lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(type);
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton(type);
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(type);
                    break;
                default:
                    break;
            }
        }
    }
}
