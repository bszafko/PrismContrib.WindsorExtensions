using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.ServiceLocation;
using Castle.Windsor;
using System.Collections.Generic;

namespace CommonServiceLocator.WindsorAdapter
{
    /// <summary>
    /// Defines a <seealso cref="IWindsorContainer"/> adapter for the <see cref="IServiceLocator"/> interface to be used by the Composite Application Library.
    /// </summary>
    public class WindsorServiceLocator : ServiceLocatorImplBase
    {
        private readonly IWindsorContainer _windsorContainer;

        /// <summary>
        /// Initializes a new instance of <see cref="WindsorServiceLocatorAdapter"/>.
        /// </summary>
        /// <param name="windsorContainer">The <seealso cref="IWindsorContainer"/> that will be used
        /// by the <see cref="DoGetInstance"/> and <see cref="DoGetAllInstances"/> methods.</param>
        [CLSCompliant(false)]
        public WindsorServiceLocator(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        /// <summary>
        /// Resolves the instance of the requested service.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>The requested service instance.</returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                return _windsorContainer.Resolve(key, serviceType);
            }
            return _windsorContainer.Resolve(serviceType);
        }

        /// <summary>
        /// Resolves all the instances of the requested service.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Sequence of service instance objects.</returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return (object[])_windsorContainer.ResolveAll(serviceType);
        }
    }
}
