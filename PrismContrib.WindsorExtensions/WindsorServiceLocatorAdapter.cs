using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Castle.Windsor;

namespace PrismContrib.WindsorExtensions
{
    /// <summary>
    /// Defines a <seealso cref="IWindsorContainer"/> adapter for the <see cref="IServiceLocator"/> interface to be used by the Composite Application Library.
    /// </summary>
    public class WindsorServiceLocatorAdapter : ServiceLocatorImplBase
    {
        private readonly IWindsorContainer _windsorContainer;

        /// <summary>
        /// Initializes a new instance of <see cref="WindsorServiceLocatorAdapter"/>.
        /// </summary>
        /// <param name="unityContainer">The <seealso cref="IWindsorContainer"/> that will be used
        /// by the <see cref="DoGetInstance"/> and <see cref="DoGetAllInstances"/> methods.</param>
        [CLSCompliant(false)]
        public WindsorServiceLocatorAdapter(IWindsorContainer unityContainer)
        {
            _windsorContainer = unityContainer;
        }

        /// <summary>
        /// Resolves the instance of the requested service.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>The requested service instance.</returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (String.IsNullOrEmpty(key))
                return _windsorContainer.Resolve(serviceType);
            return _windsorContainer.Resolve(key, serviceType);
        }

        /// <summary>
        /// Resolves all the instances of the requested service.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Sequence of service instance objects.</returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _windsorContainer.ResolveAll(serviceType).OfType<object>();
        }
    }
}
