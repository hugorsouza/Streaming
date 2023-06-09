using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Business.DependencyResolvers.Autofac;

namespace Streaming.Business.DependencyResolvers
{
    public static class InstanceFactory
    {
        private static readonly IInstanceFactory Factory = new AutofacInstanceFactory();

        public static T GetInstance<T>() =>
            Factory.GetInstance<T>();

        public static object GetInstance(Type type) =>
            Factory.GetInstance(type);
    }
}
