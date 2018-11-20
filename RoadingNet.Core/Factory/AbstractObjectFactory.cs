using RoadingNet.Object;
using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RoadingNet.Factory
{
    public abstract class AbstractObjectFactory : IObjectFactory
    {
        /// <summary>
        /// 缓存单例模式的实例
        /// </summary>
        private Dictionary<string,object> singletonCache;
        /// <summary>
        /// 单例对象异步操作锁（主要用于单例类的新增、删除）
        /// </summary>
        private Dictionary<string, object> singleonLocks;
        /// <summary>
        /// Object定义
        /// </summary>
        public Dictionary<string, IObjectDefination> DefinationCache { get; set; }
        const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |BindingFlags.Instance | BindingFlags.DeclaredOnly;
        public AbstractObjectFactory()
        {
            singletonCache = new Dictionary<string, object>();
            singleonLocks = new Dictionary<string, object>();
            if (DefinationCache == null)
            {
                DefinationCache = new Dictionary<string, IObjectDefination>();
            }
        }
        public AbstractObjectFactory(Dictionary<string, IObjectDefination> defination):this()
        {
            DefinationCache = defination;
        }
        #region IObjectFactory接口成员
        public virtual object this[string objectName]
        {
            get
            {
                return GetObject(objectName);
            }
        }
        public virtual bool ContainsObject(string objectName)
        {
            bool isContain = false;
            if (DefinationCache.ContainsKey(objectName))
            {
                isContain = true;
                return isContain;
            }
            //if (singletonCache.ContainsKey(objectName))
            //{
            //    isContain = true;
            //    return isContain;
            //}
            
            return isContain;
        }
        public virtual object GetObject(string objectName)
        {
            object obj = GetSingletonInstance(objectName);
            if (obj != null)
            {
                return obj;
            }
            IObjectDefination definatoin = DefinationCache[objectName];
            if (definatoin != null)
            {
                return InstantiateType(definatoin);
            }
            return null;
        }
        public virtual object GetObject(string objectName, object[] arguments)
        {
            return GetObject(objectName);
        }
        public  T GetObject<T>(string objectName)
        {
            return (T)GetObject(objectName);
        }
        public  T GetObject<T>(string objectName, object[] arguments)
        {
            return (T)GetObject(objectName, arguments);
        }
        public virtual bool IsPrototype(string objectName)
        {
            bool isPrototype = false;
            IObjectDefination defination = DefinationCache[objectName];
            if (defination != null)
            {
                isPrototype = true;
            }
            return isPrototype;
        }
        public virtual bool IsSingleton(string objectName)
        {
            bool isSingleton = false;
            object obj = singletonCache[objectName];
            if (obj != null)
            {
                isSingleton = true;
                return isSingleton;
            }
            IObjectDefination defination = DefinationCache[objectName];
            if (defination != null)
            {
                isSingleton = true;
                return isSingleton;
            }
            return isSingleton;
        }
        public virtual Type GetType(string objectName)
        {
            Type type = null;
            if (ContainsObject(objectName))
            {
                object obj = GetObject(objectName);
                if(obj!=null)
                {
                    type = obj.GetType();
                }
            }
            return type;
        }
        #endregion
        /// <summary>
        /// 获取操作单例对象的锁
        /// </summary>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public object GetSingletonLock(string objectName)
        {
            object obj = null;
            lock (singleonLocks)
            {
                if (!singleonLocks.ContainsKey(objectName))
                {
                    obj = new object();
                    singleonLocks[objectName] = obj;
                }
            }
            return obj;
        }
        /// <summary>
        /// 根据名称获取单例类的实例
        /// </summary>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public object GetSingletonInstance(string objectName)
        {
            if (singletonCache.ContainsKey(objectName))
            {
                return singletonCache[objectName];
            }
            return null;
        }
        /// <summary>
        /// 新增一个单例对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="singleton"></param>
        public void AddSingleton(string name,object singleton)
        {
            lock (GetSingletonLock(name))
            {
                singletonCache[name] = singleton;
            }
        } 
        /// <summary>
        /// 预先实例化单例对象并缓存 
        /// </summary>
        public void InitSingleton()
        {
            List<IObjectDefination> singletonList = DefinationCache.Values.Where(u => u.IsSingleton == true).ToList();
            if(singletonList != null&& singletonList.Count() > 0)
            {
                foreach(IObjectDefination item in singletonList)
                {
                    if (item.IsSingleton)
                    {
                        object obj = GetObject(item.Name);
                        if (obj != null)
                        {
                            AddSingleton(item.Name, obj);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 根据Object定义实例化类
        /// </summary>
        /// <param name="defination"></param>
        /// <returns></returns>
        public object InstantiateType(IObjectDefination defination)
        {
            IObjectAutowireFactory factory = new DefaultObjectAutowireFactory();
            
            object obj = null;
            obj = factory.Autowire(defination);
            return obj;
        }
    }
   
}
