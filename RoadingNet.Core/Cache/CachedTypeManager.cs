using RoadingNet.Object;
using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Cache
{
    public sealed class CachedTypeManager
    {
        private static  Dictionary<string, Type> typeCache;
        private static readonly object syncRoot = new object();
        static CachedTypeManager()
        {
            typeCache = new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);
            #region 注册基础类型
            lock (syncRoot)
            {
                typeCache.Add("int", typeof(Int32));
                typeCache.Add("Int32", typeof(Int32));
                typeCache.Add("int[]", typeof(Int32[]));
                typeCache.Add("Int32[]", typeof(Int32));
                typeCache.Add("UInt32", typeof(UInt32));
                typeCache.Add("uint", typeof(UInt32));
                typeCache.Add("uint[]", typeof(UInt32[]));
                typeCache.Add("UInt32[]", typeof(UInt32[]));

                typeCache.Add("Int16", typeof(Int16));
                typeCache.Add("short", typeof(Int16));
                typeCache.Add("short[]", typeof(Int16[]));
                typeCache.Add("Int16[]", typeof(Int16[]));
                typeCache.Add("UInt16", typeof(UInt16));
                typeCache.Add("ushort", typeof(UInt16));
                typeCache.Add("UInt16[]", typeof(UInt16[]));
                typeCache.Add("ushort[]", typeof(UInt16[]));

                typeCache.Add("Int64", typeof(Int64));
                typeCache.Add("long", typeof(Int64));
                typeCache.Add("long[]", typeof(Int64[]));
                typeCache.Add("Int64[]", typeof(Int64[]));
                typeCache.Add("UInt64", typeof(UInt64));
                typeCache.Add("ulong", typeof(UInt64));
                typeCache.Add("UInt64[]", typeof(UInt64[]));
                typeCache.Add("ulong[]", typeof(UInt64[]));

                typeCache.Add("byte", typeof(byte));//8位无符号
                typeCache.Add("byte[]", typeof(byte[]));
                typeCache.Add("sbyte", typeof(sbyte));
                typeCache.Add("sbyte[]", typeof(sbyte[]));
                

                typeCache.Add("double", typeof(double));
                typeCache.Add("double[]", typeof(double[]));

                typeCache.Add("float", typeof(float));
                typeCache.Add("float[]", typeof(float[]));
                typeCache.Add("Single", typeof(Single));
                typeCache.Add("Single[]", typeof(Single[]));

                typeCache.Add("DateTime", typeof(DateTime));
                typeCache.Add("date", typeof(DateTime));
                typeCache.Add("DateTime[]", typeof(DateTime[]));

                typeCache.Add("bool", typeof(bool));
                typeCache.Add("Boolean", typeof(bool));
                typeCache.Add("bool[]", typeof(bool[]));

                typeCache.Add("decimal", typeof(decimal));
                typeCache.Add("decimal[]", typeof(decimal[]));

                typeCache.Add("char", typeof(char));
                typeCache.Add("char[]", typeof(char[]));

                typeCache.Add("string", typeof(string));
                typeCache.Add("string[]", typeof(string[]));

                typeCache.Add("object", typeof(object));
                typeCache.Add("object[]", typeof(object[]));

                typeCache.Add("byte?", typeof(byte?));
                typeCache.Add("byte?[]", typeof(byte?[]));
                typeCache.Add("sbyte?", typeof(sbyte?));
                typeCache.Add("sbyte?[]", typeof(sbyte?[]));

                typeCache["decimal?"] = typeof(decimal?);
                typeCache["decimal?[]"] = typeof(decimal?[]);

                typeCache["char?"] = typeof(char?);
                typeCache["char?[]"] = typeof(char?[]);

                typeCache["long?"] = typeof(long?);
                typeCache["long?[]"] = typeof(long?[]);

                typeCache["Int16?"] = typeof(Int16?);
                typeCache["Int16?[]"] = typeof(Int16?[]);
                typeCache["short?"] = typeof(Int16?);
                typeCache["short?[]"] = typeof(Int16?[]);

                typeCache["UInt16?"] = typeof(UInt16?);
                typeCache["UInt16?[]"] = typeof(UInt16?[]);
                typeCache["ushort?"] = typeof(UInt16?);
                typeCache["ushort?[]"] = typeof(UInt16?[]);

                typeCache["int?"]=typeof(int?);
                typeCache["int?[]"]=typeof(int?[]);

                typeCache["uint?"] = typeof(uint?);
                typeCache["uint?[]"] = typeof(uint?[]);

                typeCache["Int64?"] = typeof(Int64?);
                typeCache["Int64?[]"] = typeof(Int64?[]);
                typeCache["long?"] = typeof(Int64?);
                typeCache["long?[]"] = typeof(Int64?[]);

                typeCache["UInt64?"] = typeof(UInt64?);
                typeCache["UInt64?[]"] = typeof(UInt64?[]);
                typeCache["ulong?"] = typeof(UInt64?);
                typeCache["ulong?[]"] = typeof(UInt64?[]);

                typeCache["double?"] = typeof(double?);
                typeCache["double?[]"] = typeof(double?[]);

                typeCache["float?"] = typeof(Single?);
                typeCache["float?[]"] = typeof(Single?[]);
                typeCache["Single?"] = typeof(Single?);
                typeCache["Single?[]"] = typeof(Single?[]);

                typeCache["bool?"] = typeof(bool?);
                typeCache["bool?[]"] = typeof(bool?[]);

                typeCache["DateTime?"] = typeof(DateTime?);
                typeCache["DateTime?[]"] = typeof(DateTime?[]);


            } 
            #endregion
        }
        public static  Type GetType(string typeName)
        {
            Type type = null;
            typeCache.TryGetValue(typeName.Trim(), out type);
            return type;
        }
        public static  void RegisterType(string typeName,Type type)
        {
            lock (syncRoot)
            {
                if (typeName.IsNotNullOrEmpty()&&type != null)
                {
                    typeCache[typeName] = type;
                }
            }
        }
        public static bool ContainType(string typeName)
        {
            if (typeCache.ContainsKey(typeName))
            {
                return true;
            }
            return false;
        }
    }
}
