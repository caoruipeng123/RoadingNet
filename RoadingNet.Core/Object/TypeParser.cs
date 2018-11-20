using RoadingNet.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RoadingNet.Object
{
    /// <summary>
    /// 类型解析器，从用户配置的类型字符串中解析出指定的<see cref="System.Type"/>
    /// </summary>
    public class TypeParser
    {
        /// <summary>
        /// 从类型字符串中解析出指定的类型
        /// </summary>
        /// <param name="typeName">类型字符串</param>
        /// <returns></returns>
        public  static Type Parse(string typeName)
        {
            Type type = null;
            if (typeName.IsNullOrEmpty())
            {
                throw new ArgumentException($"类型名称不能为空！");
            }
            string[] strArray = typeName.Split(new char[] { ',', '，' });
            if (strArray == null||strArray.Length<=0)
            {
                throw new ArgumentException($"未能从{typeName}中解析出类型名称！");
            }
            type = LoadType(strArray);
            return type;
        }
        /// <summary>
        /// 从单个程序集中加载指定类型
        /// </summary>
        /// <param name="typeName">类型全名称</param>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns></returns>
        public static Type LoadTypeFromSingleAssembly(string typeName,string assemblyName)
        {
            Type type = null;
            Assembly assembly = Assembly.Load(assemblyName);
            if (assembly != null)
            {
                type = assembly.GetType(typeName,true,false);
                CachedTypeManager.RegisterType(typeName, type);
            }
            return type;
        }
        /// <summary>
        /// 从所有程序集中加载指定类型
        /// </summary>
        /// <param name="typeName">类型全名称</param>
        /// <returns></returns>
        public static Type LoadTypeFromAllAssembly(string typeName)
        {
            Type type = null;
            Assembly[] assemblys = AppDomain.CurrentDomain.GetAssemblies();
            if (assemblys != null && assemblys.Length > 0)
            {
                foreach (Assembly assembly in assemblys)
                {
                    type = assembly.GetType(typeName, false, false);
                    if (type != null)
                    {
                        CachedTypeManager.RegisterType(typeName, type);
                        break;
                    }
                }
            }
            if (type == null)
            {
                throw new TypeLoadException($"未能从字符串{typeName}中加载指定类型");
            }
            return type;
        }
        public static Type LoadType(string[] typeArray)
        {
            Type type = null;
            type=CachedTypeManager.GetType(typeArray[0]);
            if (type != null)
            {
                return type;
            }
            if (typeArray.Length == 2)
            {
                type = LoadTypeFromSingleAssembly(typeArray[0], typeArray[1]);
            }
            else if(typeArray.Length==1)
            {
                type = LoadTypeFromAllAssembly(typeArray[0]);
            }
            return type;
        }
    }
}
