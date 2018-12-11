using RoadingNet.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Collections
{
    public class DefinationList:ArrayList
    {
        ///// <summary>
        ///// 集合中元素的类型
        ///// </summary>
        //public Type ConfigElementType { get; set; }
        public IObjectDefination Defination { get; set; }
        public string PropertyName { get; set; }
        //public DefinationList() 
        //{
            
        //}
        //public DefinationList(Type configElementType,IObjectDefination defination,string propertyName)
        //{
        //    ConfigElementType = configElementType;
        //    Defination = defination;
        //    PropertyName = propertyName;
        //}
        
        public ICollection Resolve()//IObjectDefination defination,string propertyName
        {
            IList list = null;
            Property property = Defination.PropertyInfos[PropertyName];
            if (property == null)
            {
                throw new Exception("");
            }
            if (property.PropertyValueType != null)
            {

            } 
            else
            {
                list = new ArrayList();
            }
            return list;
        }
    }
}
