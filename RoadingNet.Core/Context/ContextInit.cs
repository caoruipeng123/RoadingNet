using RoadingNet.Cache;
using RoadingNet.Factory;
using RoadingNet.Object;
using RoadingNet.Resource;
using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RoadingNet.Context
{
    /// <summary>
    /// 单个上下文初始化器
    /// </summary>
    public class ContextInit
    {
        public XmlElement ContextElement { get; set; }
        public ICoreContext CoreContext { get; set; }
        private Type CoreType { get; set; }
        private string ContextName { get; set; }
        private List<IResource> Resources { get; set; }
        private Dictionary<string,IObjectDefination> ObjectDefinations { get; set; }

        public ContextInit(XmlElement element)
        {
            ContextElement = element;
            Resources = new List<IResource>();
            ObjectDefinations = new Dictionary<string, IObjectDefination>();
        }
        public ICoreContext Init()
        {
            InitContextName();
            InitContextType();
            InitResource();
            ParseElement();
            InitContext();
            InitSingletonAndCache();//初始化单例类的实例  并缓存单例实例
            return CoreContext;
        }
        void InitContextName()
        {
            ContextName = XmlUtils.GetAttributeValue(ContextElement, ConfigConst.NameAttribute);
            if (string.IsNullOrWhiteSpace(ContextName))
            {
                ContextName = AbstractCoreContext.defaultContextName;
            }
        }
        void InitContextType()
        {
            string type = XmlUtils.GetAttributeValue(ContextElement, ConfigConst.TypeAttribute);
            if (string.IsNullOrWhiteSpace(type))
            {
                CoreType = typeof(XmlCoreContext);
            }
            else
            {

            }
        }
        void InitResource()
        {
            if (ContextElement != null && ContextElement.ChildNodes.Count > 0)
            {
                foreach (XmlNode node in ContextElement.ChildNodes)
                {
                    if (node != null && node.LocalName == ConfigConst.ResourceElement)
                    {
                        IResource resource = null;
                        string resourceName = ((XmlElement)node).GetAttribute(ConfigConst.URIAttribute);
                        if (!string.IsNullOrWhiteSpace(resourceName))
                        {
                            resource = CreateResource(resourceName);
                            if (resource != null)
                            {
                                Resources.Add(resource);
                            }       
                        }

                    }
                }
            }
        }
        void ParseElement()
        {
            ObjectDefinationParser parser = new ObjectDefinationParser();
            if(Resources!=null&& Resources.Count > 0)
            {
                List<IObjectDefination> ObjectDefinationList = parser.ParseElement(Resources);
                if(ObjectDefinationList!=null&& ObjectDefinationList.Count > 0)
                {
                    foreach(IObjectDefination item in ObjectDefinationList)
                    {
                        ObjectDefinations.Add(item.Name, item);
                    }
                }
            }
        }
        IResource CreateResource(string resourceName)
        {
            string protocol = AbstractResource.GetResourceProtocol(resourceName);
            IResource resource = null;
            switch (protocol)
            {
                case ProtocolConst.config:
                    resource = new ConfigSectionResource(ContextElement, resourceName);
                    break;
            }
            return resource;
        }
        void InitSingletonAndCache()
        {
            
        }
        void InitContext()
        {
            Type[] argumrntsType = null;
            object[] arguments = null;
            AbstractObjectFactory objectFactory = new DefaultObjectFactory(ObjectDefinations);
            if (CoreType == typeof(XmlCoreContext))
            {
                argumrntsType = new Type[] { typeof(IObjectFactory),typeof(string) };
                arguments = new object[] { objectFactory,ContextName};
            }
            CoreContext = DynamicUtils.CreateObject(CoreType, argumrntsType, arguments) as ICoreContext;
        }
        void RegisteContext()
        {
            ContextManager.RegisterContext(CoreContext);
        }
    }
}
