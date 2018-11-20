using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace RoadingNet.Resource
{
    public  class ConfigSectionResource:AbstractResource
    {
        private XmlElement configElement;
        
       
        //public ConfigSectionResource(XmlElement element)
        //{
        //    this.configElement = element;
        //}
        public ConfigSectionResource(XmlElement element,string uriName):base(uriName)
        {
            this.configElement = element;
            //this.resourceName = uriName;
        }
        public override byte[] ResourceData
        {
            get
            {
                if (resourceData == null && configElement != null)
                {
                    resourceData= Encoding.UTF8.GetBytes(this.configElement.OuterXml);
                }
                return resourceData;
            }
        }
        public override string Description
        {
            get
            {
                return $"{configElement.Name}";
            }
        }
        public override FileInfo File
        {
            get
            {
                return null;
            }
        }
    }
}
