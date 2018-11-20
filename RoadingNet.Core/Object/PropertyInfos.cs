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
    }
}
