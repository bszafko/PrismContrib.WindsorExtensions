using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using System.Linq;

namespace PrismContrib.WindsorExtensions.Tests
{
    [TestClass]
    public class WindsorServiceLocatorAdapterFixture
    {
        [TestMethod]
        public void ShouldForwardResolveToInnerContainer()
        {
            object myInstance = new object();

            IWindsorContainer container = new MockWindsorContainer()
            {
                ResolveMethod = delegate
                {
                    return myInstance;
                }
            };

            IServiceLocator containerAdapter = new WindsorServiceLocatorAdapter(container);

            Assert.AreSame(myInstance, containerAdapter.GetInstance(typeof(object)));

        }

        [TestMethod]
        public void ShouldForwardResolveAllToInnerContainer()
        {
            object[] list = new object[] { new object(), new object() };

            IWindsorContainer container = new MockWindsorContainer()
            {
                ResolveAllMethod = delegate
                {
                    return list;
                }
            };

            IServiceLocator containerAdapter = new WindsorServiceLocatorAdapter(container);

            var ret = containerAdapter.GetAllInstances(typeof(object)).ToArray();
            Assert.AreSame(list[0], ret[0]);
            Assert.AreSame(list[1], ret[1]);
        }

        private class MockWindsorContainer : IWindsorContainer
        {
            public Func<object> ResolveMethod { get; set; }

            public Func<object[]> ResolveAllMethod { get; set; }

            #region Implementation of IDisposable

            public void Dispose()
            {

            }

            #endregion

            #region IWindsorContainer Members

            public void AddChildContainer(IWindsorContainer childContainer)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponent<I, T>(string key) where T : class
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponent<I, T>() where T : class
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponent<T>(string key)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponent<T>()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponent(string key, Type serviceType, Type classType)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponent(string key, Type classType)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentLifeStyle<I, T>(string key, Castle.Core.LifestyleType lifestyle) where T : class
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentLifeStyle<I, T>(Castle.Core.LifestyleType lifestyle) where T : class
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentLifeStyle<T>(string key, Castle.Core.LifestyleType lifestyle)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentLifeStyle<T>(Castle.Core.LifestyleType lifestyle)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentLifeStyle(string key, Type serviceType, Type classType, Castle.Core.LifestyleType lifestyle)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentLifeStyle(string key, Type classType, Castle.Core.LifestyleType lifestyle)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentProperties<I, T>(string key, System.Collections.IDictionary extendedProperties) where T : class
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentProperties<I, T>(System.Collections.IDictionary extendedProperties) where T : class
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentWithProperties<T>(string key, System.Collections.IDictionary extendedProperties)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentWithProperties<T>(System.Collections.IDictionary extendedProperties)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentWithProperties(string key, Type serviceType, Type classType, System.Collections.IDictionary extendedProperties)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddComponentWithProperties(string key, Type classType, System.Collections.IDictionary extendedProperties)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility<T>(Func<T, object> onCreate) where T : Castle.MicroKernel.IFacility, new()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility<T>(Action<T> onCreate) where T : Castle.MicroKernel.IFacility, new()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility<T>() where T : Castle.MicroKernel.IFacility, new()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility<T>(string key, Func<T, object> onCreate) where T : Castle.MicroKernel.IFacility, new()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility<T>(string key, Action<T> onCreate) where T : Castle.MicroKernel.IFacility, new()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility<T>(string key) where T : Castle.MicroKernel.IFacility, new()
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer AddFacility(string key, Castle.MicroKernel.IFacility facility)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer GetChildContainer(string name)
            {
                throw new NotImplementedException();
            }

            public IWindsorContainer Install(params IWindsorInstaller[] installers)
            {
                throw new NotImplementedException();
            }

            public Castle.MicroKernel.IKernel Kernel
            {
                get { throw new NotImplementedException(); }
            }

            public string Name
            {
                get { throw new NotImplementedException(); }
            }

            IWindsorContainer IWindsorContainer.Parent
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public IWindsorContainer Register(params Castle.MicroKernel.Registration.IRegistration[] registrations)
            {
                throw new NotImplementedException();
            }

            public void Release(object instance)
            {
                throw new NotImplementedException();
            }

            public void RemoveChildContainer(IWindsorContainer childContainer)
            {
                throw new NotImplementedException();
            }

            public object Resolve(string key, Type service, object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public object Resolve(string key, Type service, System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(string key, object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(string key, System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(string key)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>()
            {
                throw new NotImplementedException();
            }

            public object Resolve(Type service, object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public object Resolve(Type service, System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public object Resolve(Type service)
            {
                return ResolveMethod();
            }

            public object Resolve(string key, Type service)
            {
                return ResolveMethod();
            }

            public object Resolve(string key, object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public object Resolve(string key, System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public object Resolve(string key)
            {
                throw new NotImplementedException();
            }

            public T[] ResolveAll<T>(object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public T[] ResolveAll<T>(System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public Array ResolveAll(Type service, object argumentsAsAnonymousType)
            {
                throw new NotImplementedException();
            }

            public Array ResolveAll(Type service, System.Collections.IDictionary arguments)
            {
                throw new NotImplementedException();
            }

            public Array ResolveAll(Type service)
            {
                return ResolveAllMethod();
            }

            public T[] ResolveAll<T>()
            {
                throw new NotImplementedException();
            }

            public object this[Type service]
            {
                get { throw new NotImplementedException(); }
            }

            public object this[string key]
            {
                get { throw new NotImplementedException(); }
            }

            #endregion

            #region IServiceProviderEx Members

            public T GetService<T>() where T : class
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IServiceProvider Members

            public object GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}