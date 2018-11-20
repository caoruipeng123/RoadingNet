using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Factory
{
    public interface IObjectFactory
    {
        object GetObject(string objectName);
        object GetObject(string objectName, object[] arguments);
        T GetObject<T>(string objectName);
        T GetObject<T>(string objectName, object[] arguments);
        object this[string objectName] { get; }
        bool IsSingleton(string objectName);
        bool IsPrototype(string objectName);
        bool ContainsObject(string objectName);
        //IList<string> GetAliases(string name);
        //bool IsTypeMatch(string objectName, Type targetType);
        //bool IsTypeMatch<T>(string objectName);
        //object CreateObject(string objectName, Type requiredType, object[] arguments);
        //T CreateObject<T>(string objectName, object[] arguments);
        Type GetType(string objectName);
    }
}
