using RoadingNet.Context;
using RoadingNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Roading.Net.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentCheck.NotNull(null, "name","错误信息");
            ICoreContext context = ContextManager.GetContext();
            object baseObj = context.GetObject("BaseTypePropertyTest");//基础类型注入
            object arrayObj = context.GetObject("ArrayPropertyTest");//基础类型数据注入
            Console.ReadLine();
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 构造函数注入
    /// </summary>
    public class ConstructerTest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ConstructerTest(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }
    /// <summary>
    /// 属性注入：基础类型注入
    /// </summary>
    public class BaseTypePropertyTest
    {
        #region 常用类型注入
        public int IntTest { get; set; }
        public string StringTest { get; set; }
        public double DoubleTest { get; set; }
        public float FloatTest { get; set; }
        public Single SingleTest { get; set; }
        public decimal DecimalTest { get; set; }
        public DateTime DateTimeTest { get; set; }
        public DateTime DateTest { get; set; }
        public bool BoolTest { get; set; }
        public char CharTest { get; set; }
        #endregion
        #region 8位、16位、32位、64位有符号，无符号值类型注入
        public byte ByteTest { get; set; }
        public sbyte SbyteTest { get; set; }
        public Int16 Int16Test { get; set; }
        public short ShortTest { get; set; }
        public Int64 Int64Test { get; set; }
        public long LongTest { get; set; }
        public uint UintTest { get; set; }
        public UInt16 UInt16Test { get; set; }
        public UInt64 UIint64Test { get; set; }
        #endregion
        #region 常用可空类型注入
        public int? IntNullableTest { get; set; }
        public double? DoubleNullableTest { get; set; }
        public float? FloatNullableTest { get; set; }
        public Single? SingleNullableTest { get; set; }
        public decimal? DecimalNullableTest { get; set; }
        public DateTime? DateTimeNullableTest { get; set; }
        public bool? BoolNullableTest { get; set; }
        public char? CharNullableTest { get; set; }
        #endregion
        #region 8位、16位、32位、64位有符号，无符号值类型（可空）注入
        public sbyte? SByteNullableTest { get; set; }//8位有符号
        public Int16? Int16NullableTest { get; set; }//16位有符号
        public short? ShortNullableTest { get; set; }//16位有符号
        public Int64? Int64NullableTest { get; set; }//64位有符号
        public long? LongNullableTest { get; set; }//64位有符号
        public byte? ByteNullableTest { get; set; }//8位无符号
        public UInt16? UInt16NullableTest { get; set; }//16位无符号
        public uint? UIntNullableTest { get; set; }//32位无符号
        public UInt64? UInt64NullableTest { get; set; }//64位无符号 
        #endregion
    }
    /// <summary>
    /// 属性注入：数组类型注入
    /// </summary>
    public class ArrayPropertyTest
    {
        #region 常用类型注入
        public int[] IntTest { get; set; }
        public string[] StringTest { get; set; }
        public double[] DoubleTest { get; set; }
        public float[] FloatTest { get; set; }
        public Single[] SingleTest { get; set; }
        public decimal[] DecimalTest { get; set; }
        public DateTime[] DateTimeTest { get; set; }
        public bool[] BoolTest { get; set; }
        public char[] CharTest { get; set; }
        #endregion
        #region 常用可空类型注入
        public int?[] IntNullableTest { get; set; }
        public double?[] DoubleNullableTest { get; set; }
        public float?[] FloatNullableTest { get; set; }
        public Single?[] SingleNullableTest { get; set; }
        public decimal?[] DecimalNullableTest { get; set; }
        public DateTime?[] DateTimeNullableTest { get; set; }
        public bool?[] BoolNullableTest { get; set; }
        public char?[] CharNullableTest { get; set; }
        #endregion
        #region 8位、16位、32位、64位有符号，无符号值类型注入
        public byte[] ByteTest { get; set; }
        public sbyte[] SbyteTest { get; set; }
        public Int16[] Int16Test { get; set; }
        public short[] ShortTest { get; set; }
        public Int64[] Int64Test { get; set; }
        public long[] LongTest { get; set; }
        public uint[] UintTest { get; set; }
        public UInt16[] UInt16Test { get; set; }
        public UInt64[] UIint64Test { get; set; }
        #endregion
        #region 8位、16位、32位、64位有符号，无符号值类型（可空）注入
        public sbyte?[] SByteNullableTest { get; set; }//8位有符号
        public Int16?[] Int16NullableTest { get; set; }//16位有符号
        public short?[] ShortNullableTest { get; set; }//16位有符号
        public Int64?[] Int64NullableTest { get; set; }//64位有符号
        public long?[] LongNullableTest { get; set; }//64位有符号
        public byte?[] ByteNullableTest { get; set; }//8位无符号
        public UInt16?[] UInt16NullableTest { get; set; }//16位无符号
        public uint?[] UIntNullableTest { get; set; }//32位无符号
        public UInt64?[] UInt64NullableTest { get; set; }//64位无符号 
        #endregion
        public string[] StrArrayTestTwo { get; set; }
        public double[] DoubleArrayTestTwo { get; set; }
    }
    /// <summary>
    /// 属性注入：集合类型注入
    /// </summary>
    public class ListPropertyTest
    {
        public List<string> ListStringTest { get; set; }
    }
}
