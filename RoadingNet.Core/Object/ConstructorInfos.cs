using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RoadingNet.Object
{
    public class ConstructorInfos : List<ConstructorArgument>
    {
        public void Add(int argumentIndex, object argumentValue,string argumentType)
        {
            base.Add(new ConstructorArgument(argumentIndex, argumentValue, argumentType));
        }
        public void Add(string argumentName, object argumentValue,string argumentType)
        {
            base.Add(new ConstructorArgument(argumentName, argumentValue,argumentType));
        }
        public new ConstructorArgument this[int index]
        {
            get
            {
                return Find(u => u.Index == index);
            }
        }
        public ConstructorArgument this[string name]
        {
            get
            {
                //ConstructorArgument value = Find(u => u.Name == name);
                return Find(u => u.Name == name);
            }
        }
    }
    public class ConstructorArgument
    {
        public ConstructorArgument(int argumentIndex,object argumentValue,string type)
        {
            this.index = argumentIndex;
            this.value = argumentValue;
            this.type = type;
            this.name = "";
        }
        public ConstructorArgument(string argumentName, object argumentValue,string type)
        {
            this.name = argumentName;
            this.value = argumentValue;
            this.type = type;
            this.index = -1;
        }
        public ConstructorArgument(int argumentIndex,string argumentName, object argumentValue, string type)
        {
            this.index = argumentIndex;
            this.name = argumentName;
            this.value = argumentValue;
            this.type = type;
        }
        private readonly int index;
        private readonly string name;
        private readonly object value;
        private readonly string type;//参数类型 
        //private readonly int argumentType;//参数表示类型 1：name表示  2：索引表示
        public int Index
        {
            get
            {
                return index;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public object Value
        {
            get
            {
                return value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
    }
}
