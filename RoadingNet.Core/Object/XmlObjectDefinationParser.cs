using RoadingNet.Cache;
using RoadingNet.Context;
using RoadingNet.Resource;
using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace RoadingNet.Object
{
    /// <summary>
    /// 解析xml中object的定义
    /// </summary>
    public class ObjectDefinationParser
    {
        IList<IResource> Resources;
        public ObjectDefinationParser(IList<IResource> resources)
        {
            Resources = resources;
        }
        public ObjectDefinationParser() { }
        public List<IObjectDefination> ParseElement()
        {
            if(Resources!=null&& Resources.Count > 0)
            {
                return ParseElement(Resources);
            }
            return null;
        }
        public List<IObjectDefination> ParseElement(IList<IResource> resource)
        {
            List<IObjectDefination> list = new List<IObjectDefination>();
            if (resource != null && resource.Count > 0)
            {
                foreach (IResource resourceItem in resource)
                {
                    IObjectDefinationReader reader = GetObjectDefinationReader(resourceItem);
                    List<IObjectDefination> definationList = reader.LoadObjectDefination(resourceItem);
                    if (definationList != null && definationList.Count > 0)
                    {
                        list.AddRange(definationList);
                    }
                }
            }
            return list;
        }
        public IObjectDefinationReader GetObjectDefinationReader(IResource resource)
        {
            IObjectDefinationReader reader = null;
            if (resource.Protocol == ProtocolConst.config)
            {
                reader = new XmlObjectDefinationReader();
            }
            return reader;
        }
    }
    public class XmlObjectDefinationReader : IObjectDefinationReader
    {
        public List<IObjectDefination> LoadObjectDefination(IResource resource)
        {
            List<IObjectDefination> list = new List<IObjectDefination>();
            XmlElement element = ConfigurationUtils.GetSection(AbstractResource.GetResourceNameWithoutProtocol(resource.ResourceName)) as XmlElement;
            if (element != null && element.ChildNodes.Count > 0)
            {
                foreach (XmlNode objectNode in element.ChildNodes)
                {
                    if(objectNode is XmlComment)
                    {
                        continue;
                    }
                    IObjectDefination defination = LoadObjectDefination((XmlElement)objectNode);
                    if (defination != null)
                    {
                        list.Add(defination);
                    }
                }
            }
            return list;
        }
        IObjectDefination LoadObjectDefination(XmlElement element)
        {
            IObjectDefination defination = new RootObjectDefination();
            if (element != null)
            {
                LoadObjectDefault(defination, element);
                defination.PropertyInfos = LoadPropertyInfos(element);
                defination.ConstructorInfos = LoadConstructorInfos(element);
            }
            return defination;
        }
        void LoadObjectDefault(IObjectDefination defination, XmlElement element)
        {
            bool isSingleton = true;
            string singletonStr = XmlUtils.GetAttributeValue(element, ConfigConst.SingletonAttribute);
            if (string.IsNullOrWhiteSpace(singletonStr)||singletonStr=="false")
            {
                isSingleton = false;
            }
            defination.IsSingleton = isSingleton;

            defination.InitMethodName = XmlUtils.GetAttributeValue(element, ConfigConst.InitMethodNameAttribute);
            defination.DestoryMethodName = XmlUtils.GetAttributeValue(element, ConfigConst.DestoryNameAttribute);
            defination.FactoryMethodName = XmlUtils.GetAttributeValue(element, ConfigConst.FactoryMethodNameAttribute);
            defination.FactoryObjectName = XmlUtils.GetAttributeValue(element, ConfigConst.FactoryObjectNameAttribute);

            string typeStr = XmlUtils.GetAttributeValue(element, ConfigConst.TypeAttribute);
            defination.ObjectType = TypeParser.Parse(typeStr);

            defination.Name = XmlUtils.GetAttributeValue(element, ConfigConst.NameAttribute);
            defination.ParentName = XmlUtils.GetAttributeValue(element, ConfigConst.ParentNameAttribute);
        }
        PropertyInfos LoadPropertyInfos(XmlElement element)
        {
            PropertyInfos propertyInfos = null;
            if (element != null)
            {
                propertyInfos = new PropertyInfos();
                XmlNodeList nodeList = element.SelectNodes("property");
                if (nodeList != null && nodeList.Count > 0)
                {
                    foreach (XmlElement propertyNode in nodeList)
                    {
                        Property property = LoadProperty(propertyNode);
                        if (property != null)
                        {
                            propertyInfos.Add(property);
                        }
                    }
                }
            }
            return propertyInfos;
        }
        Property LoadProperty(XmlElement propertyNode)
        {
            Property property = null;
            string name = XmlUtils.GetAttributeValue(propertyNode, ConfigConst.NameAttribute);
            string type= XmlUtils.GetAttributeValue(propertyNode, ConfigConst.TypeAttribute);
            string inlineValue = XmlUtils.GetAttributeValue(propertyNode, ConfigConst.ValueAttribute);

            Type propertyType = null;
            if (type.IsNotNullOrEmpty())
            {
                propertyType=TypeParser.Parse(type);
            }
            if (propertyNode.HasAttribute(ConfigConst.ValueAttribute))//行内值 &&!string.IsNullOrWhiteSpace(inlineValue)
            {
                property = new Property(name, inlineValue, propertyType);
                return property;
            }
            string refName = XmlUtils.GetAttributeValue(propertyNode, ConfigConst.RefAttribute);
            if (!string.IsNullOrWhiteSpace(refName))//引用类型
            {
                property = new Property(name, new ObjectReference(refName),propertyType);
                return property;
            }
            string expressionValue = XmlUtils.GetAttributeValue(propertyNode, ConfigConst.ExpressionAttribute);
            if (!string.IsNullOrWhiteSpace(expressionValue))
            {
                return property;
            }
            
            XmlNodeList childNodes = propertyNode.ChildNodes;
            if (childNodes != null && childNodes.Count > 0)
            {
                //XmlElement parsedElement = childNodes[0] as XmlElement;
                property=(Property)LoadSubProperty((XmlElement)(propertyNode.ChildNodes[0]));//property
                property.PropertyName = name;
            }
            else
            {
                throw new Exception("属性在没有value值、ref值和expression值胡情况下，其子节点不能为空！");
            }
            return property;
        }
        
        
        object LoadSubProperty(XmlElement element)
        {
            object obj = null;
            switch (element.LocalName.ToLower())
            {
                case ConfigConst.ObjectElement:
                    //property = LoadReferenceProperty(parsedElement,name);
                    break;
                case ConfigConst.ListElement://解析集合类型
                    obj = LoadListProperty(element);
                    break;
                case ConfigConst.ArrayElement://解析数组类型
                    obj = LoadArrayProperty(element);
                    break;
                case ConfigConst.DictionaryElement://解析字典类型 ParseDictionaryType
                    obj = LoadDictionaryProperty(element);
                    break;
                case ConfigConst.ValueElement:
                    obj = LoadValueNode(element);
                    break;
            }
            return obj;
        }
        Property LoadReferenceProperty(XmlElement element, string propertyName)
        {
            Property property = null;
            //string refName = XmlUtils.GetAttributeValue(element, ConfigConst.NameAttribute);
            //string type = XmlUtils.GetAttributeValue(element, ConfigConst.TypeAttribute);
            //Type propertyType= DynamicUtils.GetType(type);
            //if (refName.IsNotNullOrEmpty())
            //{
            //    property = new Property(propertyName, new ObjectReference(refName));
            //}
            return property;
        }
        Property LoadListProperty(XmlElement element)
        {
            Property property = null;
            if (element != null && element.ChildNodes != null && element.ChildNodes.Count > 0)
            {
                
            }
            return property;
        }
        Property LoadArrayProperty(XmlElement element)
        {
            Property property = null;
            //string name = XmlUtils.GetAttributeValue(element, ConfigConst.NameAttribute);
            //string typeStr = XmlUtils.GetAttributeValue(element, ConfigConst.ElementTypeAttribute);
            //Type type = null;
            //if (typeStr.IsNotNullOrEmpty())
            //{
            //    type= TypeParser.Parse(typeStr);
            //}
            
            List<object> list = new List<object>();
            if (element != null && element.ChildNodes.Count > 0)
            {
                foreach(XmlElement item in element.ChildNodes)
                {
                    list.Add(LoadSubProperty(item));
                }
            }
            property = new Property("", list,null);
            return property;
        } 
        Property LoadDictionaryProperty(XmlElement element)
        {
            Property property = null;
            return property;
        }
        object LoadValueNode(XmlElement element)
        {
            string valueText = element.InnerText;
            return valueText;
        }
        //Property LoadSet
        ConstructorInfos LoadConstructorInfos(XmlElement element)
        {
            ConstructorInfos constructorInfos = null;
            XmlNodeList nodeList = element.SelectNodes("constructor");
            if (nodeList != null && nodeList.Count > 0)
            {
                foreach (XmlElement constructorNode in nodeList)
                {
                    ConstructorArgument argument = LoadConstructorArgument(constructorNode);
                    if (argument != null)
                    {
                        constructorInfos.Add(argument);
                    }
                }
            }
            return constructorInfos;
        }
        ConstructorArgument LoadConstructorArgument(XmlElement element)
        {
            ConstructorArgument constructorArgument = null;
            string typeValue = XmlUtils.GetAttributeValue(element, ConfigConst.TypeAttribute);
            string nameValue = XmlUtils.GetAttributeValue(element, ConfigConst.NameAttribute);
            string indexValue = XmlUtils.GetAttributeValue(element, ConfigConst.IndexAttribute);
            string value = XmlUtils.GetAttributeValue(element, ConfigConst.ValueAttribute);
            if (string.IsNullOrWhiteSpace(nameValue) && string.IsNullOrWhiteSpace(indexValue))
            {
                throw new Exception("name属性和index属性至少得有一个！");
            }
            if (!string.IsNullOrWhiteSpace(nameValue))
            {
                constructorArgument = new ConstructorArgument(nameValue, value, typeValue);
            }
            else
            {
                int index = -1;
                if (Int32.TryParse(indexValue, out index))
                {
                    constructorArgument = new ConstructorArgument(index, value, typeValue);
                }

            }
            return constructorArgument;
        }
    }
    public interface IObjectDefinationReader
    {
        List<IObjectDefination> LoadObjectDefination(IResource resource);
    }
}
