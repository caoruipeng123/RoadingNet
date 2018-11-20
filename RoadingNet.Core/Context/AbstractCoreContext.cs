using RoadingNet.Factory;
using RoadingNet.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RoadingNet.Context
{
    public abstract class AbstractCoreContext : ICoreContext, IObjectFactory
    {
        protected IObjectFactory objectFactory;
        internal readonly static string contextSectionName = "roadingNet/context";
        internal readonly static string defaultContextName = "roadingNet.Root";//默认的ioc容器名称
        private object syncRoot = new object();
        public AbstractCoreContext(IObjectFactory factory,string contextName)
        {
            objectFactory = factory;
            ContextName = string.IsNullOrWhiteSpace(contextName)?defaultContextName:contextName;
        }
        protected void Init()
        {
            lock (syncRoot)
            {
                InitObjectFactory();//加载工厂对象
            }
        }
        protected abstract void InitObjectFactory();
        #region ICoreContext接口实现
        public virtual string ContextName { get; set; } 
        #endregion

        #region IObjectFactory接口实现
        public virtual bool ContainsObject(string objectName) { return objectFactory.ContainsObject(objectName); }
        public virtual object GetObject(string objectName) { return objectFactory.GetObject(objectName); }
        public virtual object GetObject(string objectName, object[] arguments) { return objectFactory.GetObject(objectName, arguments); }
        public virtual T GetObject<T>(string objectName) { return objectFactory.GetObject<T>(objectName); }
        public virtual T GetObject<T>(string objectName, object[] arguments) { return objectFactory.GetObject<T>(objectName, arguments); }
        public virtual bool IsPrototype(string objectName) { return objectFactory.IsPrototype(objectName); }
        public virtual bool IsSingleton(string objectName) { return objectFactory.IsSingleton(objectName); }
        public virtual Type GetType(string objectName) { return objectFactory.GetType(objectName); }
        public object this[string objectName]
        {
            get
            {
                return objectFactory[objectName];
            }
        }
        #endregion
    }
}
