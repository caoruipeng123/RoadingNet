using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Object
{
    public abstract class AbstractObjectDefination : IObjectDefination
    {
        public abstract ConstructorInfos ConstructorInfos { get; set; }
        public abstract string DestoryMethodName { get; set; }
        public abstract string FactoryMethodName { get; set; }
        public abstract string FactoryObjectName { get; set; }
        public abstract string InitMethodName { get; set; }
        public abstract bool IsSingleton { get; set; }
        public abstract string Name { get; set; }
        public abstract Type ObjectType { get; set; }
        public abstract string ParentName { get; set; }
        public abstract PropertyInfos PropertyInfos { get; set; }
    }
}
