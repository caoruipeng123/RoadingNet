using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RoadingNet.Object
{
    public class ObjectDefinationValueParser
    {
        public object ParsePropertyValue(Property property, Type requiredType)
        {
            object value = property.PropertyValue;
            Type propertyType = property.PropertyValueType;
            object newValue = null;
            if (requiredType == propertyType)
            {
                newValue = ConvertValueIfNeed(requiredType, value);
            }
            else
            {
                newValue = ConvertValueIfNeed(requiredType, value);
            }
            return newValue;
        }
        public object ConvertValueIfNeed(Type requiredType, object value)
        {
            object newValue = null;
            Type valueType = value.GetType();
            //调用者.isAssignableFrom(调用者本身或者子类的class)返回true,反之false  
            if (requiredType.IsAssignableFrom(value.GetType()))
            {
                return value;
            }
            if (requiredType.IsArray)//数组  
            {
                Type elementType = requiredType.GetElementType();
                if (valueType==typeof(string))
                {
                    string[] array = null;
                    if (requiredType.Equals(typeof(char[])) || requiredType.Equals(typeof(char?[])))
                    {
                        array = ((string)value).ToCharStringArray();
                    }
                    else
                    {
                        array = value.ToString().Split(new char[] { ',', '，' });
                    }
                    newValue = ConvertToArray(array, elementType);
                }
                else if(valueType==typeof(List<object>))
                {
                    
                    newValue = ConvertToArray((List<object>)value, elementType);
                }
                return newValue;
            }
            else if (requiredType.IsGenericType)//泛型 
            {
                
                //return newValue; 
            }
            try
            {
                TypeConverter converter = GetConverter(requiredType);
                if (converter != null && converter.CanConvertFrom(value.GetType()))
                {
                    newValue = converter.ConvertFrom(value);
                }
                else
                {
                    converter = GetConverter(value.GetType());
                    if (converter != null && converter.CanConvertTo(requiredType))
                    {
                        newValue = converter.ConvertTo(value, requiredType);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newValue;
        }
        public object ConvertToArray(string[] strArray, Type requiredType)
        {
            Array array = null;
            if (strArray == null || strArray.Length <= 0)
            {
                //array = Array.CreateInstance(requiredType, 0);
                return array;
            }
            else
            {
                array = Array.CreateInstance(requiredType, strArray.Length);
                for (int i = 0; i < strArray.Length; i++)
                {
                    object value = ConvertValueIfNeed(requiredType, strArray[i]);
                    array.SetValue(value, i);
                }
            }
            return array;
        }
        public object ConvertToArray(List<object> list, Type requiredType)
        {
            Array array = null;
            if (list==null||list.Count<=0)
            {
                //array = Array.CreateInstance(requiredType, 0);
                return array;
            }
            else
            {
                array = Array.CreateInstance(requiredType, list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    object value = ConvertValueIfNeed(requiredType, list[i]);
                    array.SetValue(value, i);
                }
            }
            return array;
        }
        public object ConvertToCollection()
        {
            return null;
        }
        public TypeConverter GetConverter(Type type)
        {
            TypeConverter converter;
            if (type.IsEnum)
            {
                converter = new EnumConverter(type);
            }
            else
            {
                converter = TypeDescriptor.GetConverter(type);
            }
            return converter;
        }
    }
}
