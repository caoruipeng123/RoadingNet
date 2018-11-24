using RoadingNet.Collections;
using RoadingNet.Utils;
using System;
using System.Collections;
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
        /// <summary>
        /// 将value转换为指定类型requiredType
        /// </summary>
        /// <param name="requiredType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ConvertValueIfNeed(Type requiredType, object value)
        {
            object newValue = null;
            Type valueType = value.GetType();
            //调用者.isAssignableFrom(调用者本身或者子类的class)返回true,反之false  
            if (requiredType.IsAssignableFrom(valueType))
            {
                return value;
            }
            if (requiredType.IsArray)//数组  
            {
                Type elementType = requiredType.GetElementType();
                if (valueType==typeof(string))
                {
                    string[] array = ConvertToStringArray(requiredType,value.ToString());
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
                Type elementType = requiredType.GetElementType();
                if (valueType == typeof(string))
                {
                    ///requiredType为：<see cref="List<char>"/>或者<see cref="List<char?>"/>
                    string[] array = ConvertToStringArray(requiredType, value.ToString());
                }
                else if (valueType == typeof(DefinationList))
                {
                    newValue = ((DefinationList)value).Resolve();
                }
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
        public string[] ConvertToStringArray(Type requiredType,string str)
        {
            string[] array = null;
            if (str.IsNotNullOrEmpty())
            {
                return array;
            }
            if (requiredType.Equals(typeof(char[])) || requiredType.Equals(typeof(char?[]))||requiredType.Equals(typeof(List<char>))||requiredType.Equals(typeof(List<char?>)))
            {
                array = str.ToCharStringArray();
            }
            else
            {
                array = str.ToString().Split(new char[] { ',', '，' });
            }
            return array;
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
            IList list = null;

            return list;
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
