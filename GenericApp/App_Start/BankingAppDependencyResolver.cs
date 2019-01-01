using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace GenericApp
{
    internal class GenericAppDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public GenericAppDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return new List<object>();
            } 
        }
    }
}