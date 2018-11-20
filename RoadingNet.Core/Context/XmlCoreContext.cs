using RoadingNet.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Context
{
    public  class XmlCoreContext:AbstractCoreContext
    {
        DefaultObjectFactory ObjectFactory { get; set; }
        public XmlCoreContext(IObjectFactory factory,string contextName):base(factory,contextName)
        {
            ObjectFactory = (DefaultObjectFactory)factory;
            Init();
        }
        protected override void InitObjectFactory()
        {
            if (ObjectFactory != null)
            {
                ObjectFactory.InitSingleton();//初始化单例对象
            } 
        }
        #region IObjectFactory成员
        public override object GetObject(string objectName)
        {
            return ObjectFactory.GetObject(objectName);
        }
        public override object GetObject(string objectName, object[] arguments)
        {
            return ObjectFactory.GetObject(objectName, arguments);
        }
        public override bool ContainsObject(string objectName)
        {
            return ObjectFactory.ContainsObject(objectName);
        } 
        #endregion
    }
}
