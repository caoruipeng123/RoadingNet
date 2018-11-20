using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Object
{
    public class ObjectReference
    {
        public string ObjectName { get; set; }
        public ObjectReference(string objectName)
        {
            ObjectName = objectName;
        }
    }
}
