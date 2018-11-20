using RoadingNet.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Factory
{
    public class DefaultObjectFactory:AbstractObjectFactory
    {
        public DefaultObjectFactory(Dictionary<string, IObjectDefination> defination):base(defination)
        {

        }
    }
}
