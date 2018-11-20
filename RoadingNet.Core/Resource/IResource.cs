using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RoadingNet.Resource
{
    public interface IResource
    {
        byte[] ResourceData { get; }
        string Description { get; }
        bool Exists { get; }
        FileInfo File { get; }
        Uri Uri { get; }
        string Protocol { get; }
        string ResourceName { get;  }
    }
}
