using GenericApp.BusinessLogic.IService;
using GenericApp.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace GenericApp
{
    public static class IocConfigurator
    {
        public static void ConfigureIocUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            registerServices(container);
            DependencyResolver.SetResolver(new GenericAppDependencyResolver(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterTypes("GenericApp.BusinessLogic", "Service", (itype, type) => container.RegisterType(itype, type));
        }
    }


    /// <summary>
    /// The assembly registration helper
    /// </summary>
    public static class AssemblyRegistrationHelper
    {
        /// <summary>
        /// Adds the scoped from assembly.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeSuffix">The type suffix.</param>
        /// <param name="scopeRegistration">The scope registration.</param>
        public static void RegisterTypes(this IUnityContainer services, string assemblyName, string typeSuffix,
            Action<Type, Type> registerType)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => string.Equals(x.GetName().Name.ToUpperInvariant(), assemblyName));

            if (assembly == null)
            {
                assembly = AppDomain.CurrentDomain.Load(assemblyName);
            }

            var allServices = assembly.GetTypes().Where(p => p.GetTypeInfo().IsClass && !p.GetTypeInfo().IsAbstract && p.FullName.EndsWith(typeSuffix));

            foreach (var type in allServices)
            {
                var allInterfaces = type.GetInterfaces();

                var mainInterfaces = allInterfaces.Except(allInterfaces.SelectMany(t => t.GetInterfaces()));

                foreach (var itype in mainInterfaces)
                {
                    registerType(itype, type);
                }
            }
        }
    }
}