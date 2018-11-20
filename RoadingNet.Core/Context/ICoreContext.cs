using RoadingNet.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Context
{
    public interface ICoreContext:IObjectFactory
    {
        string ContextName { get; set; }
    }
}
