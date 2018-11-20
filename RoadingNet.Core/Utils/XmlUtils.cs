using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RoadingNet.Utils
{
    public class XmlUtils
    {
        public static string GetAttributeValue(XmlElement element,string attributeName)
        {
            string value = null;
            value = element.GetAttribute(attributeName);
            //if (!string.IsNullOrWhiteSpace(value))
            //{
            //    value = value.Trim();
            //}
            //else
            //{
            //    value = "";
            //}
            return value;
        }

        public XmlNodeList GetXmlNodeList(XmlElement element,string xpath)
        {
            XmlNodeList nodeList= element.SelectNodes(xpath);
            return nodeList;
        }
    }
}
