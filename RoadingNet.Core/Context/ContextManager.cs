using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RoadingNet.Context
{
    public sealed class ContextManager
    {
        private static Dictionary<string, ICoreContext> contextCache { get; set; }
        private static object syncRoot = new object();
        private static string DefaultContextName { get; set; }
        private ContextManager()
        {

        }
        static ContextManager()
        {
            contextCache = new Dictionary<string, ICoreContext>();
            
        }
        public static ICoreContext GetContext()
        {
            return GetContext(DefaultContextName);
        }
        public static ICoreContext GetContext(string contextName)
        {
            InitDefaultContextIfNeed();
            ICoreContext context = null;
            if (string.IsNullOrWhiteSpace(contextName))
            {
                contextName = DefaultContextName;
            }
            if (contextCache.ContainsKey(contextName))
            {
                context = contextCache[contextName];
            }
            return context;
        }
        private static void InitDefaultContextIfNeed()
        {
            if (string.IsNullOrWhiteSpace(DefaultContextName))
            {
                lock (syncRoot)
                {
                    if (string.IsNullOrWhiteSpace(DefaultContextName))
                    {
                        XmlElement element = ConfigurationUtils.GetSection(AbstractCoreContext.contextSectionName) as XmlElement;
                        ContextInit init = new ContextInit(element);
                        ICoreContext context = init.Init();
                        if (context != null)
                        {
                            EnSureDefaultName(context.ContextName);
                            contextCache[DefaultContextName] = context;
                            
                        }
                    }
                }
            }

        }
        public static void RegisterContext(ICoreContext context)
        {
            if (context!=null&& context.ContextName != null)
            {
                lock (syncRoot)
                {
                    if (context != null && context.ContextName != null)
                    {
                        contextCache[context.ContextName] = context;
                        EnSureDefaultName(context.ContextName);
                    }
                }
            }
        }
        public static void UnRegisterContext(string contextName)
        {
            if (contextCache.ContainsKey(contextName))
            {
                lock (syncRoot)
                {
                    if (contextCache.ContainsKey(contextName))
                    {
                        contextCache.Remove(contextName);
                        if (DefaultContextName == contextName)
                        {
                            DefaultContextName = null;
                        }
                    }
                }
            }
        }
        public static void Clear()
        {

        }
        public static void EnSureDefaultName(string contextName)
        {
            if (string.IsNullOrWhiteSpace(DefaultContextName))
            {
                DefaultContextName = contextName;
            }
        }
    }
}
