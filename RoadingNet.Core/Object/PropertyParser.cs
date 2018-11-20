using RoadingNet.Context;
using RoadingNet.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RoadingNet.Object
{
    public interface PropertyParser
    {
        //object ParseProperty(o)
    }
    public class ListPropertyParser
    {
        /// <summary>
        /// 解析List集合
        /// </summary>
        /// <param name="element">list节点元素</param>
        /// <returns></returns>
        public Property ParseProperty(XmlElement element)
        {
            Property property = null;
            string elementType = XmlUtils.GetAttributeValue(element, ConfigConst.ElementTypeAttribute);//list集合中元素的类型字符串
            IList list = null;
            Type type = null;
            if (elementType.IsNotNullOrEmpty())
            {
                type = typeof(List<>);
                //Type[] types = new Type[1] { elementType};
            }
            else
            {
                list = new ArrayList();
            }
            return property;
        }
    }
}
