using ATS.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Presentation.WFA.Base
{
    public class DomainEventsContainer : IContainer
    {
        private readonly SimpleInjector.Container _container;

        public DomainEventsContainer(SimpleInjector.Container container)
        {
            _container = container;
        }

        public object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public T GetInstance<T>()
        {
            return (T)_container.GetInstance(typeof(T));
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            return (IEnumerable<T>)_container.GetAllInstances(typeof(T));
        }
    }
}
