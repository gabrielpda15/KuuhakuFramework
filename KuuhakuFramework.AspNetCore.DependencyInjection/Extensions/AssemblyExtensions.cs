using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AssemblyExtensions
    {
        private static readonly string NetFrameworkProductName = GetNetFrameworkProductName();

        private static IEnumerable<Type> _loadedTypes;

        public static IHostBuilder LoadAllDllsIBinFolder(this IHostBuilder builder)
        {
            LoadAllDllsIBinFolder();
            return builder;
        }

        public static void LoadAllDllsIBinFolder()
        {
            List<string> stringList = new List<string>();
            try
            {
                stringList = DependencyContext.Default.CompileLibraries
                                .SelectMany(x => GetReferencePaths(x))
                                .Distinct()
                                .Where(x => x.Contains(Directory.GetCurrentDirectory()))
                                .ToList();
            }
            catch { }

            foreach (string assemblyPath in stringList)
            {
                try
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
                }
                catch (FileLoadException)
                {
                }
                catch (BadImageFormatException)
                {
                }
                catch (Exception)
                {
                }
            }
        }

        private static IEnumerable<string> GetReferencePaths(CompilationLibrary x)
        {
            try
            {
                return x.ResolveReferencePaths();
            }
            catch
            {
                return new List<string>();
            }
        }

        public static IEnumerable<Type> GetAllLoadedAssembliesTypes(Func<Type, bool> predicate = null)
        {
            if (_loadedTypes == null)
                _loadedTypes = FromLoadedAssemblies(false, false, true);

            if (predicate == null)
                return _loadedTypes;

            return _loadedTypes.Where(predicate);
        }

        private static IEnumerable<Type> FromLoadedAssemblies(bool includeSystemAssemblies = false, bool includeDynamicAssemblies = false, bool skipOnError = true)
        {
            return FromCheckedAssemblies(GetLoadedAssemblies(includeSystemAssemblies, includeDynamicAssemblies), skipOnError);
        }

        private static IEnumerable<Type> FromCheckedAssemblies(IEnumerable<Assembly> assemblies, bool skipOnError)
        {
            return assemblies.SelectMany(a =>
            {
                IEnumerable<TypeInfo> source;
                try
                {
                    source = a.DefinedTypes;
                }
                catch (ReflectionTypeLoadException ex)
                {
                    if (!skipOnError)
                        throw;
                    else
                        source = ex.Types.TakeWhile(t => t != null).Select(t => t.GetTypeInfo());
                }
                return source.Where(ti =>
                {
                    if (ti.IsClass & !ti.IsAbstract && !ti.IsValueType)
                        return ti.IsVisible;
                    return false;
                }).Select(ti => ti.AsType());
            });
        }

        private static string GetNetFrameworkProductName()
        {
            return typeof(object).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
        }

        private static IEnumerable<Assembly> GetLoadedAssemblies(bool includeSystemAssemblies, bool includeDynamicAssemblies)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            if (includeSystemAssemblies & includeDynamicAssemblies)
                return assemblies;
            return assemblies.Where(a =>
            {
                if (!includeDynamicAssemblies && a.IsDynamic)
                    return false;
                if (!includeSystemAssemblies)
                    return !IsSystemAssembly(a);
                return true;
            });
        }

        private static bool IsSystemAssembly(Assembly a)
        {
            if (NetFrameworkProductName == null)
                return false;
            AssemblyProductAttribute customAttribute = a.GetCustomAttribute<AssemblyProductAttribute>();
            return customAttribute != null && string.Compare(NetFrameworkProductName, customAttribute.Product, StringComparison.Ordinal) == 0;
        }
    }
}
