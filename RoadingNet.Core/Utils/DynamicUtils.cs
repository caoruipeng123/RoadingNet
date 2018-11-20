using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RoadingNet.Utils
{
    public class DynamicUtils
    {
        public static object CreateObject(Type type,Type[] argumentsType, object[] arguments)
        {
            object obj = null;
            ConstructorInfo ctor= type.GetConstructor(argumentsType);
            obj= ctor.Invoke(arguments);
            return obj;
        }
        public static object CreateObject(ConstructorInfo ctor, object[] arguments)
        {
            object obj = null;
            obj = ctor.Invoke(arguments);
            return obj;
        }
        public static object ConvertType(object value,Type targetType)
        {
            if (value.GetType() == targetType)
            {
                return value;
            }
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }
                NullableConverter nullableConverter = new NullableConverter(targetType);
                targetType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, targetType);
        }
    }
}
