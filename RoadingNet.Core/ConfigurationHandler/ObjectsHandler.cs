using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace RoadingNet.ConfigurationHandler
{
    public class ObjectsHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            return section as XmlElement;
        }
    }
}
