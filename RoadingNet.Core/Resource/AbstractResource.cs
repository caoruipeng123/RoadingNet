using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RoadingNet.Resource
{
    public abstract class AbstractResource : IResource
    {
        protected string resourceProtocol;
        protected string resourceName;
        protected Uri uri;
        protected byte[] resourceData;
        private object syncRoot = new object();
        protected AbstractResource() { }
        protected AbstractResource(string resourceName)
        {
            this.resourceName = resourceName;
            this.resourceProtocol = GetResourceProtocol(resourceName);
        }
        public abstract string Description { get; }
        public virtual bool Exists { get { return false; } }
        public abstract FileInfo File { get; }
        public abstract byte[] ResourceData { get; }
        public virtual Uri Uri
        {
            get
            {
                if (uri != null)
                {
                    if (!string.IsNullOrWhiteSpace(resourceName))
                    {
                        uri = new Uri(resourceName);
                    }
                }
                return uri;
            }
        }
        public virtual string Protocol
        {
            get
            {
                return resourceProtocol;
            }
        }
        public virtual string ResourceName
        {
            get
            {
                return resourceName;
            }
        }
        public static string GetResourceProtocol(string resourceName)
        {
            string protocol = "";
            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                int index = resourceName.IndexOf("://");
                if (index >= 0)
                {
                    protocol = resourceName.Substring(0, index);
                }
            }
            return protocol;
        }
        public static string GetResourceNameWithoutProtocol(string resourceName)
        {
            string resourceNameWithoutProtocol = "";
            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                int index = resourceName.IndexOf("://");
                if (index >= 0)
                {
                    resourceNameWithoutProtocol = resourceName.Substring(index+3).TrimStart(new char[] { '/' }).TrimEnd(new char[] {'/' });
                }
            }
            return resourceNameWithoutProtocol;
        }
    }
    public struct ProtocolConst
    {
        public const string config = "config";
        public const string ftp = "ftp";
        public const string http = "http";
        public const string https = "https";
        public const string assembly = "assembly";
    }
}
