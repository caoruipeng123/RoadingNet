using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Object
{
    public interface IObjectDefination
    {
        PropertyInfos PropertyInfos { get; set; }
        ConstructorInfos ConstructorInfos { get; set; }
        bool IsSingleton { get; set; }
        string Name { get; set; }
        string ParentName { get; set; }
        Type ObjectType { get; set; }
        string InitMethodName { get; set; }
        string DestoryMethodName { get; set; }
        string FactoryMethodName { get; set; }
        string FactoryObjectName { get; set; }
    }
}
