using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Object
{
    public class PropertyInfos : List<Property>
    {
        public PropertyInfos()
        {

        }
        public PropertyInfos(ICollection<Property> propertyDic)
        {
            if(propertyDic!=null&& propertyDic.Count > 0)
            {
                foreach(Property property in propertyDic)
                {
                    Add(property);
                }
            }
        }
        public Property this[string propertyName]
        {
            get
            {
                List<Property> propertyList = this.Where(u => u.PropertyName == propertyName).ToList();
                if (propertyList != null && propertyList.Count==1)
                {
                    return propertyList[0];
                }
                return null;
            }
        }
    }
    public class Property
    {
        private  string propertyName;
        private  object propertyValue;
        private Type propertyValueType;
        public Property() { }
        public Property(string propertyName,object propertyValue)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.propertyValueType = null;
        }
        public Property(string propertyName, object propertyValue,Type propertyValueType)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.propertyValueType = propertyValueType;
        }
        public Property(string propertyName, object propertyValue, Type propertyValueType,Type applicationValueType)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.propertyValueType = propertyValueType;
            this.ApplicationValueType = applicationValueType;
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName
        {
            get
            {
                return propertyName;
            }
            set
            {
                propertyName = value;
            }
        }
        /// <summary>
        /// 从配置文件中解析出来的属性值，注意：该值不能直接赋给程序中的属性
        /// </summary>
        public object PropertyValue
        {
            get
            {
                return propertyValue;
            }
            set
            {
                propertyValue = value;
            }
        }
        /// <summary>
        /// 配置文件中对该节点定义的类型
        /// </summary>
        public Type PropertyValueType
        {
            get
            {
                return propertyValueType;
            }
            set
            {
                propertyValueType = value;
            }
        }
        /// <summary>
        /// 应用程序中对该属性节点定义的类型
        /// </summary>
        public Type ApplicationValueType{get;set;}
    }
}
