using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Object
{
    public class RootObjectDefination : AbstractObjectDefination
    {
        public override ConstructorInfos ConstructorInfos
        {
            get; set;
        }
        public override PropertyInfos PropertyInfos
        {
            get; set;
        }
        public override bool IsSingleton
        {
            get; set;
        }
        public override string DestoryMethodName
        {
            get; set;
        }
        public override string FactoryMethodName
        {
            get; set;
        }
        public override string FactoryObjectName
        {
            get; set;
        }
        public override string InitMethodName
        {
            get; set;
        }
        public override Type ObjectType
        {
            get; set;
        }
        public override string ParentName
        {
            get; set;
        }
        public override string Name
        {
            get; set;
        }
    }



}
