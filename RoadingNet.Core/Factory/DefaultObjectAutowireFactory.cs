using RoadingNet.Object;
using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RoadingNet.Factory
{
    public class DefaultObjectAutowireFactory : AbstractObjectAutowireFactory
    {
        protected const BindingFlags MethodFlags =
                BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

        public override object Autowire(IObjectDefination defination)
        {
            object obj = null;
            //根据定义获取构造函数
            ConstructorInfoResolver ctorResolver = new ConstructorInfoResolver();
            ConstructorInfoHolder ctorHolder = ctorResolver.Resolve(defination);
            if (ctorHolder != null)
            {
                obj = DynamicUtils.CreateObject(ctorHolder.ConstructorInfo, ctorHolder.ArgumentArray);
            }
            SetProperty(obj, defination);//属性注入
            InvokeInitMethod(obj, defination);//执行Init初始化方法
            return obj;
        }
        /// <summary>
        /// 属性注入
        /// </summary>
        public void SetProperty(object instance, IObjectDefination defination)
        {
            if (defination == null)
            {
                throw new Exception("Object定义不能为空！");
            }
            ObjectDefinationValueParser valueParser = new ObjectDefinationValueParser();
            if (defination.PropertyInfos != null && defination.PropertyInfos.Count > 0)
            {
                foreach (Property property in defination.PropertyInfos)
                {
                    PropertyInfo propertyInfo = instance.GetType().GetProperty(property.PropertyName);
                    if (property.PropertyValueType == null)
                    {
                        property.PropertyValueType = propertyInfo.PropertyType;
                    }
                    property.PropertyValue = valueParser.ParsePropertyValue(property, propertyInfo.PropertyType);

                    if (propertyInfo != null&&propertyInfo.CanWrite)
                    {
                        propertyInfo.SetValue(instance, property.PropertyValue, null); 
                    }
                }
            }
        }
        public void InvokeInitMethod(object instance, IObjectDefination defination)
        {
            try
            {
                if (defination.InitMethodName.IsNotNullOrEmpty())
                {
                    MethodInfo methodInfo = defination.ObjectType.GetMethod(defination.InitMethodName, MethodFlags, null, Type.EmptyTypes, null);
                    if (methodInfo == null)
                    {
                        throw new Exception($"类型{defination.ObjectType.Name}中不存在初始化方法{defination.InitMethodName}");
                    }
                    methodInfo.Invoke(instance, null);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }   
        }
        public override void AutowireProperty()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class AbstractObjectAutowireFactory : IObjectAutowireFactory
    {
        public virtual object Autowire(IObjectDefination defination)
        {
            return null;
        }
        public abstract void AutowireProperty();
    }

}
