using RoadingNet.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Factory
{
    /// <summary>
    /// 类型装配根接口
    /// </summary>
    public interface IObjectAutowireFactory
    {
        object Autowire(IObjectDefination defination);
        void AutowireProperty();
    }
}
