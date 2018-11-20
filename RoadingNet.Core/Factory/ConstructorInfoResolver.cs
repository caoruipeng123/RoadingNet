using RoadingNet.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RoadingNet.Factory
{
    public class ConstructorInfoResolver
    {
        const BindingFlags flags =
          BindingFlags.Public | BindingFlags.NonPublic
          | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        public ConstructorInfoHolder Resolve(IObjectDefination defination)
        {
            return Resolve(defination.ObjectType,defination.ConstructorInfos);
        }
        public ConstructorInfoHolder Resolve(Type type,IObjectDefination defination)
        {
            return Resolve(type, defination.ConstructorInfos);
        }
        public ConstructorInfoHolder Resolve(Type type, ConstructorInfos constructorInfo)
        {
            ConstructorInfoHolder ctorHolder = null;
            ConstructorInfo ctor = null;
            ConstructorInfo[] ctors = type.GetConstructors(flags);
            if (constructorInfo == null || constructorInfo.Count <= 0)
            {
                ctor = type.GetConstructor(Type.EmptyTypes);
                ctorHolder = new ConstructorInfoHolder(ctor, null);
                return ctorHolder;
            }
            for(int i = 0; i < ctors.Length; i++)
            {
                ParameterInfo[] parameterInfo = ctors[i].GetParameters();
                if(parameterInfo==null|| parameterInfo.Length!= constructorInfo.Count)
                {
                    continue;
                }
                //Type[] argumentsTypes = GetParameterType(parameterInfo);
                object[] argumentArray = CreateArguments(parameterInfo, constructorInfo);
                if (argumentArray == null)
                {
                    continue;
                }
                else
                {
                    ctorHolder = new ConstructorInfoHolder(ctors[i], argumentArray);
                    return ctorHolder;
                }
            }
            return ctorHolder;
        }
        private Type[] GetParameterType(ParameterInfo[] parameterInfo)
        {
            List<Type> typeList = new List<Type>();
            if(parameterInfo!=null&& parameterInfo.Length > 0)
            {
                foreach(ParameterInfo item in parameterInfo)
                {
                    typeList.Add(item.ParameterType);
                }
            }
            return typeList.ToArray();
        }
        private object[] CreateArguments(ParameterInfo[] parameterInfo,ConstructorInfos constructorInfo)
        {
            List<object> arrgumentsList = new List<object>();
            for (int i= 0; i < parameterInfo.Length; i++)
            {
                ConstructorArgument value = constructorInfo[i];
                if (value == null)
                {
                    value = constructorInfo[parameterInfo[i].Name];
                }
                if (value != null)
                {
                    arrgumentsList.Add(value.Value);
                }
                else
                {
                    return null;
                }
            }
            return arrgumentsList.ToArray();
        }
    }
    public class ConstructorInfoHolder
    {
        public ConstructorInfoHolder(ConstructorInfo constructorInfo, object[] argumentArray)
        {
            ConstructorInfo = constructorInfo;
            ArgumentArray = argumentArray;
        }
        public ConstructorInfo ConstructorInfo { get; set; }
        public object[] ArgumentArray { get; set; }
    }
}
