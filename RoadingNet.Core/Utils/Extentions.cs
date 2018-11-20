using System;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Reflection;

/// <summary>
///系统类的扩展方法
/// </summary>
public static class Extensions
{
    /// <summary>
    /// 判断字符串是否能转换为Decimal类型。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsDecimal(this string str)
    {
        decimal test;
        return decimal.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串是否能转换为Decimal类型。如果能，则返回。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="test"></param>
    /// <returns></returns>
    public static bool IsDecimal(this string str, out decimal test)
    {
        return decimal.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能否成功转换为Double类型。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsDouble(this string str)
    {
        double test;
        return double.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能否成功转换为Double类型。如果能，则返回。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="test"></param>
    /// <returns></returns>
    public static bool IsDouble(this string str, out double test)
    {
        return double.TryParse(str, out test);
    }

    /// <summary>
    /// 格式化数字，三位加逗号
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    //public static string ToFormatString(this decimal str)
    //{
    //    string str1 = str.ToString();
    //    return str1.IndexOf('.') >= 0 ? str.ToString("#,##0" + ".".PadRight(str1.Substring(str1.IndexOf('.')).Length, '0')) : str.ToString("#,##0");
    //}
    /// <summary>
    /// 相加
    /// </summary>
    /// <param name="add1"></param>
    /// <param name="add2"></param>
    /// <returns></returns>
    public static double Add(this double d1, double d2)
    {
        return (double)((decimal)d1 + (decimal)d2);
    }
    /// <summary>
    /// 相减
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static double sub(this double d1, double d2)
    {
        return (double)((decimal)d1 - (decimal)d2);
    }
    /// <summary>
    /// 相乖
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static double mul(this double d1, double d2)
    {
        return (double)((decimal)d1 * (decimal)d2);
    }
    /// <summary>
    /// 相除
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static double div(this double d1, double d2)
    {
        return d2 == 0 ? 0 : (double)((decimal)d1 / (decimal)d2);
    }
    /// <summary>
    /// 判断字符串能否转换为int类型。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsInt(this string str)
    {
        int test;
        return int.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能否转换为int类型。如果能，则返回。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="test"></param>
    /// <returns></returns>
    public static bool IsInt(this string str, out int test)
    {
        return int.TryParse(str, out test);
    }
    /// <summary>
    /// 将数组转换为符号分隔的字符串
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="split">分隔符</param>
    /// <returns></returns>
    //public static string Join1<T>(this T[] arr, string split = ",")
    //{
    //    StringBuilder sb = new StringBuilder(arr.Length * 36);
    //    for (int i = 0; i < arr.Length; i++)
    //    {
    //        sb.Append(arr[i].ToString());
    //        if (i < arr.Length - 1)
    //        {
    //            sb.Append(split);
    //        }
    //    }
    //    return sb.ToString();
    //}

    /// <summary>
    /// 去除字符串中所有空格，包括\r和\n。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string RemoveSpace(this string str)
    {
        if (str.IsNullOrEmpty()) return "";
        return str.Replace(" ", "").Replace("\r", "").Replace("\n", "");
    }
    /// <summary>
    /// 判断字符串能否转换为Long类型。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsLong(this string str)
    {
        long test;
        return long.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能够转换为Long类型。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="test"></param>
    /// <returns></returns>
    public static bool IsLong(this string str, out long test)
    {
        return long.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能够转换为DateTime类型。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsDateTime(this string str)
    {
        DateTime test;
        return DateTime.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能够转换为DateTime类型。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="test"></param>
    /// <returns></returns>
    public static bool IsDateTime(this string str, out DateTime test)
    {
        return DateTime.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串能够转换为Guid类型。
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsGuid(this string str)
    {
        Guid test;
        return Guid.TryParse(str, out test);
    }
    /// <summary>
    ///判断字符串能够转为Guid类型。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="test"></param>
    /// <returns></returns>
    public static bool IsGuid(this string str, out Guid test)
    {
        return Guid.TryParse(str, out test);
    }
    /// <summary>
    /// 判断是否为Guid.Empty
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static bool IsEmptyGuid(this Guid guid)
    {
        return guid == Guid.Empty;
    }
    /// <summary>
    /// 判断一个字符串是否为url格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsUrl(this string str)
    {
        if (str.IsNullOrEmpty())
            return false;
        string pattern = @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$";
        return Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase);
    }
    /// <summary>
    /// 判断一个字符串是否为Email格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsEmail(this string str)
    {
        return Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
    /// <summary>
    /// 判断一个整型是否包含在指定的值内
    /// </summary>
    /// <param name="i"></param>
    /// <param name="ints"></param>
    /// <returns></returns>
    public static bool In(this int i, IEnumerable<int> ints)
    {
        foreach (int k in ints)
        {
            if (i == k)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 判断字符串是够为空，为空返回"",不为空返回str
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static object StrValue(this string str)
    {
        if (str.IsNullOrEmpty())
        {
            return "";
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// 字符串转换为Decimal类型并四舍五入保留指定位数的小数
    /// </summary>
    /// <param name="str">被转换的字符串</param>
    /// <param name="decimals">小数位数，默认值为2</param>
    /// <returns></returns>
    public static decimal ToDecimal(this string str, int decimals = 2)
    {
        decimal test;
        return decimal.TryParse(str, out test) ? decimal.Round(test, decimals, MidpointRounding.AwayFromZero) : 0;
    }
    /// <summary>
    /// 字符串转换为Decimal类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static decimal ToDecimal(this string str)
    {
        decimal test;
        return decimal.TryParse(str, out test) ? test : 0;
    }
    public static decimal ToDecimal(this object obj)
    {
        if (obj == null)
        {
            throw new Exception($"无法将{obj.GetType().Name}类型数据转换成decimal");
        }
        decimal test;
        return decimal.TryParse(obj.ToString(), out test) ? test :default(decimal);
    }
    /// <summary>
    /// 四舍五入保留指定位数
    /// </summary>
    /// <param name="dec"></param>
    /// <param name="decimals">保留的小数位数默认值为2</param>
    /// <returns></returns>
    public static decimal ToRound(this decimal dec, int decimals = 2)
    {
        return decimal.Round(dec, decimals, MidpointRounding.AwayFromZero);
    }
    /// <summary>
    /// 字符串转换为double类型
    /// </summary>
    /// <param name="str"></param>
    /// <param name="digits"></param>
    /// <returns></returns>
    public static double ToDouble(this string str, int digits)
    {
        double test;
        return double.TryParse(str, out test) ? test.Round(digits) : default(double);
    }
    public static double ToDouble(this string str)
    {
        double test;
        return double.TryParse(str, out test) ? test : default(double);
    }
    public static double ToDouble(this object str)
    {
        if (str == null)
        {
            throw new Exception($"无法将{str.GetType().Name}转换为double类型");
        }
        double test;
        return double.TryParse(str.ToString(), out test) ? test : default(double);
    }
    public static double Round(this double value, int decimals)
    {
        if (value < 0)
            return Math.Round(value + 5 / Math.Pow(10, decimals + 1), decimals, MidpointRounding.AwayFromZero);
        else
            return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
    }
    /// <summary>
    /// 字符串转换为Short类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static short ToShort(this string str)
    {
        short test;
        short.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为int类型或者null
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int? ToIntOrNull(this string str)
    {
        int test;
        if (int.TryParse(str, out test))
        {
            return test;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 字符串转换为int类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int ToInt(this string str)
    {
        int test;
        int.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为int类型，如果转换失败，返回默认值
    /// </summary>
    /// <param name="str"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static int ToInt(this string str, int defaultValue)
    {
        int test;
        return int.TryParse(str, out test) ? test : defaultValue;
    }
    /// <summary>
    /// 将Int?转化为Int
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static int ToInt(this int? data)
    {
        if (data == null)
            return default(int);
        return Convert.ToInt32(data);
    }
    public static int ToInt(this object data)
    {
        if (data == null)
            return default(int);
        return Convert.ToInt32(data);
    }
    /// <summary>
    /// 字符串转换为long类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static long ToLong(this string str)
    {
        long test;
        long.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为Int16类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Int16 ToInt16(this string str)
    {
        Int16 test;
        Int16.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为Int32类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Int32 ToInt32(this string str)
    {
        Int32 test;
        Int32.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为Int64类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Int64 ToInt64(this string str)
    {
        Int64 test;
        Int64.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为DateTime类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this string str)
    {
        DateTime test;
        DateTime.TryParse(str, out test);
        return test;
    }
    /// <summary>
    /// 字符串转换为DateTime类型，如果转换失败，返回null 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static DateTime? ToDateTimeOrNull(this string str)
    {
        DateTime test;
        if (DateTime.TryParse(str, out test))
        {
            return test;//
        }
        return null;
    }
    /// <summary>
    /// 将金币转换为小数点后两位
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    public static string ToMoneyString(this decimal? money)
    {
        return decimal.Round(money ?? 0, 2, MidpointRounding.AwayFromZero).ToString("N2");
    }
    /// <summary>
    /// 将金币转化为小数点后两位数字
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    public static Decimal ToMoneyDecimal(this Decimal? money)
    {
        return decimal.Round(money ?? 0,2,MidpointRounding.AwayFromZero);
    }
    /// <summary>
    /// 计算小数点位数
    /// </summary>
    /// <param name="dec"></param>
    /// <returns></returns>
    public static int PointCount(this decimal dec)
    {
        string[] str = dec.ToString().Trim('0').TrimEnd('.').Split('.');
        if (str.Length == 1)
            return 0;
        if (str.Length == 2)
            return str[1].Length;
        return 0;
    }
    /// <summary>
    /// 计算小数点位数
    /// </summary>
    /// <param name="dec"></param>
    /// <returns></returns>
    public static int PointCount(this decimal? dec)
    {
        return PointCount(dec ?? 0);
    }
    /// <summary>
    /// 将DateTime?转化为yyyy/MM/dd HH:mm字符串 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToDateFormatString(this DateTime? date)
    {
        return date == null ? "" : (Convert.ToDateTime(date).ToString("yyyy/MM/dd HH:mm"));
    }
    public static string ToDateString(this DateTime date)
    {
        return date.ToString("yyyy/MM/dd HH:mm");
    }
    /// <summary>
    /// 将DateTime?转化为DataTime
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this DateTime? date)
    {
        if (date == null)
        {
            return DateTime.MinValue;
        }
        return Convert.ToDateTime(date);
    }
    /// <summary>  
    /// 获取时间戳  
    /// </summary>  
    /// <returns></returns>  
    public static long ToTimeStamp(this DateTime date)
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds);
    }
    /// <summary>
    /// 将DateTime?转化为字符串  返回带今天 明天等字符串的时间
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToDateString(this DateTime? date)
    {
        if (date == null)
        {
            return "";
        }
        else
        {
            DateTime dt = Convert.ToDateTime(date);
            DateTime dtNow = DateTime.Now;
            if (dt.Year == dtNow.Year && dt.Day == dtNow.Day)
            {
                return "今天 " + dt.ToString("HH:mm");
            }
            if (dt.Year == dtNow.Year && dt.Day == dtNow.AddDays(-1).Day)
            {
                return "昨天 " + dt.ToString("HH:mm");
            }
            else
            {
                return dt.ToString("yyyy/MM/dd HH:mm");
            }
        }
        //return date==null?"":(Convert.ToDateTime(date).ToString("yyyy/MM/dd HH:mm"));
    }
    /// <summary>
    /// 字符串转换为Guid类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Guid ToGuid(this string str)
    {
        Guid test;
        if (Guid.TryParse(str, out test))
        {
            return test;
        }
        else
        {
            return Guid.Empty;
        }
    }

    /// <summary>
    /// 字符串转换为bool类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool ToBoolean(this string str)
    {
        bool b;
        return Boolean.TryParse(str, out b) ? b : false;
    }

    /// <summary>
    /// 尝试格式化日期字符串
    /// </summary>
    /// <param name="date"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string DateTimeFormat(this object date, string format = "yyyy/MM/dd")
    {
        if (date == null) { return string.Empty; }
        DateTime d;
        if (!date.ToString().IsDateTime(out d))
        {
            return date.ToString();
        }
        else
        {
            return d.ToString(format);
        }
    }
    /// <summary>
    /// 判断字符串是否为空
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    /// <summary>
    /// 判断字符串是否不为空
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNotNullOrEmpty(this string str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }
    /// <summary>
    /// 集合中的字符串用指定字符拼接起来
    /// </summary>
    /// <param name="strList"></param>
    /// <param name="split"></param>
    /// <returns></returns>
    public static string ToString(this IList<string> strList, char split)
    {
        return strList.ToString(split.ToString());
    }
    /// <summary>
    /// 集合中的字符串用指定字符串拼接起来
    /// </summary>
    /// <param name="strList"></param>
    /// <param name="split"></param>
    /// <returns></returns>
    public static string ToString(this IList<string> strList, string split)
    {
        StringBuilder sb = new StringBuilder(strList.Count * 10);
        for (int i = 0; i < strList.Count; i++)
        {
            sb.Append(strList[i]);
            if (i < strList.Count - 1)
            {
                sb.Append(split);
            }
        }
        return sb.ToString();
    }
    /// <summary>
    /// 获取汉字拼音的第一个字母
    /// </summary>
    /// <param name="strText"></param>
    /// <returns></returns>
    //public static string ToChineseSpell(this string strText)
    //{
    //    int len = strText.Length;
    //    string myStr = "";
    //    for (int i = 0; i < len; i++)
    //    {
    //        myStr += getSpell(strText.Substring(i, 1));
    //    }
    //    return myStr.ToLower();
    //}
    /// <summary>
    /// 获取汉字拼音
    /// </summary>
    /// <param name="cnChar"></param>
    /// <returns></returns>
    //public static string getSpell(this string cnChar)
    //{
    //    byte[] arrCN = Encoding.Default.GetBytes(cnChar);
    //    if (arrCN.Length > 1)
    //    {
    //        int area = (short)arrCN[0];
    //        int pos = (short)arrCN[1];
    //        int code = (area << 8) + pos;
    //        int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
    //        for (int i = 0; i < 26; i++)
    //        {
    //            int max = 55290;
    //            if (i != 25) max = areacode[i + 1];
    //            if (areacode[i] <= code && code < max)
    //            {
    //                return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
    //            }
    //        }
    //        return "x";
    //    }
    //    else return cnChar;
    //}

    /// <summary>
    /// 截取字符串，汉字两个字节，字母一个字节
    /// </summary>
    /// <param name="str">字符串</param>
    /// <param name="strLength">字符串长度</param>
    /// <returns></returns>
    //public static string Interruption(this string str, int len, string show)
    //{
    //    ASCIIEncoding ascii = new ASCIIEncoding();
    //    int tempLen = 0;
    //    string tempString = "";
    //    byte[] s = ascii.GetBytes(str);
    //    for (int i = 0; i < s.Length; i++)
    //    {
    //        if ((int)s[i] == 63)
    //        { tempLen += 2; }
    //        else
    //        { tempLen += 1; }
    //        try
    //        { tempString += str.Substring(i, 1); }
    //        catch
    //        { break; }
    //        if (tempLen > len) break;
    //    }
    //    //如果截过则加上半个省略号 
    //    byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);
    //    if (mybyte.Length > len)
    //        tempString += show;
    //    tempString = tempString.Replace("&nbsp;", " ");
    //    tempString = tempString.Replace("&lt;", "<");
    //    tempString = tempString.Replace("&gt;", ">");
    //    tempString = tempString.Replace('\n'.ToString(), "<br>");
    //    return tempString;
    //}

    /// <summary>
    /// 截取字符串，汉字两个字节，字母一个字节
    /// </summary>
    /// <param name="str">字符串</param>
    /// <param name="strLength">字符串长度</param>
    /// <returns></returns>
    //public static string CutString(this string str, int len, string show = "...")
    //{
    //    return Interruption(str, len, show);
    //}

    /// <summary>
    /// 截取左边多少个字符
    /// </summary>
    /// <param name="str"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static string Left(this string str, int len)
    {
        if (str == null || len < 1) { return ""; }
        if (len < str.Length)
        { return str.Substring(0, len); }
        else
        { return str; }
    }
    /// <summary>
    /// 获取右边多少个字符
    /// </summary>
    /// <param name="str"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static string Right(this string str, int len)
    {
        if (str == null || len < 1) { return ""; }
        if (len < str.Length)
        { return str.Substring(str.Length - len); }
        else
        { return str; }
    }

    /// <summary>
    /// 得到实符串实际长度
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    //public static int Size(this string str)
    //{
    //    byte[] strArray = System.Text.Encoding.Default.GetBytes(str);
    //    int res = strArray.Length;
    //    return res;
    //}
    ///   <summary>   
    ///   去除HTML标记   
    ///   </summary>   
    ///   <param   name="NoHTML">包括HTML的源码   </param>   
    ///   <returns>已经去除后的文字</returns>   
    //public static string RemoveHTML(this string Htmlstring)
    //{
    //    //删除脚本   
    //    Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
    //    //删除HTML   
    //    Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

    //    Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
    //    Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

    //    Htmlstring.Replace("<", "");
    //    Htmlstring.Replace(">", "");
    //    Htmlstring.Replace("\r\n", "");
    //    Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

    //    return Htmlstring;
    //}
    /// <summary>
    /// 过滤js脚本
    /// </summary>
    /// <param name="strFromText"></param>
    /// <returns></returns>
    //public static string RemoveScript(this string html)
    //{
    //    if (html.IsNullOrEmpty()) return string.Empty;
    //    System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    html = regex1.Replace(html, ""); //过滤<script></script>标记
    //    html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
    //    html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
    //    html = regex4.Replace(html, ""); //过滤iframe
    //    html = regex5.Replace(html, ""); //过滤frameset
    //    return html;
    //}
    /// <summary>
    /// 替换页面标签
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    //public static string RemovePageTag(this string html)
    //{
    //    if (html.IsNullOrEmpty()) return string.Empty;
    //    System.Text.RegularExpressions.Regex regex0 = new System.Text.RegularExpressions.Regex(@"<!DOCTYPE[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<html\s*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"<head[\s\S]+</head\s*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@"<body\s*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<form\s*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"</(form|body|head|html)>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //    html = regex0.Replace(html, ""); //过滤<html>标记
    //    html = regex1.Replace(html, "<html\u3000 "); //过滤<html>标记
    //    html = regex2.Replace(html, ""); //过滤<head>属性
    //    html = regex3.Replace(html, "<body\u3000 "); //过滤<body>属性
    //    html = regex4.Replace(html, "<form\u3000 "); //过滤<form>属性
    //    html = regex5.Replace(html, "</$1\u3000>"); //过滤</html></body></head></form>属性
    //    return html;
    //}

    /// <summary>
    /// 取得html中的图片
    /// </summary>
    /// <param name="HTMLStr"></param>
    /// <returns></returns>
    //public static string GetImg(this string text)
    //{
    //    string str = string.Empty;
    //    Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>", //注意这里的(?<url>\S+)是按正则表达式中的组来处理的，下面的代码中用使用到，也可以更改成其它的HTML标签，以同样的方法获得内容！
    //    RegexOptions.Compiled);
    //    Match m = r.Match(text.ToLower());
    //    if (m.Success)
    //        str = m.Result("${url}").Replace("\"", "").Replace("'", "");
    //    return str;
    //}
    /// <summary>
    /// 取得html中的所有图片
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    //public static string[] GetImgs(this string text)
    //{
    //    List<string> imgs = new List<string>();
    //    string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>";
    //    Regex r = new Regex(pat, RegexOptions.Compiled);
    //    Match m = r.Match(text.ToLower());
    //    while (m.Success)
    //    {
    //        imgs.Add(m.Result("${url}").Replace("\"", "").Replace("'", ""));
    //        m = m.NextMatch();
    //    }
    //    return imgs.ToArray();
    //}
    /// <summary>
    /// 产生随机字符串
    /// </summary>
    /// <returns>字符串位数</returns>
    public static string GetRandom(int length)
    {
        int number;
        char code;
        string checkCode = String.Empty;
        System.Random random = new Random();

        for (int i = 0; i < length + 1; i++)
        {
            number = random.Next();
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));
            checkCode += code.ToString();
        }
        return checkCode;
    }

    /// <summary>
    /// 字符串是否包含标点符号(不包括_下画线)
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool InPunctuation(this string str)
    {
        foreach (char c in str.ToCharArray())
        {
            if (char.IsPunctuation(c) && c != '_')
                return true;
        }
        return false;

    }
    /// <summary>
    /// 去除字符串标点符号和空字符
    /// </summary>
    /// <param name="sourceString"></param>
    /// <returns></returns>
    public static string RemovePunctuationOrEmpty(this string str)
    {
        StringBuilder NewString = new StringBuilder(str.Length);
        char[] charArr = str.ToCharArray();
        foreach (char symbols in charArr)
        {
            if (!char.IsPunctuation(symbols) && !char.IsWhiteSpace(symbols))
            {
                NewString.Append(symbols);
            }
        }
        return NewString.ToString();
    }
    /// <summary>
    /// 返回带星期的日期格式
    /// </summary>
    /// <param name="date"></param>
    /// <param name="isDate">是否包含日期</param>
    /// <param name="format">日期格式（如果需要包含日期的话）</param>
    /// <returns></returns>
    public static string ToWeekString(this DateTime date, bool isDate = false, string format = "yyyy年M月d日")
    {
        string week = string.Empty;
        switch (date.DayOfWeek)
        {
            case DayOfWeek.Friday: week = "五"; break;
            case DayOfWeek.Monday: week = "一"; break;
            case DayOfWeek.Saturday: week = "六"; break;
            case DayOfWeek.Sunday: week = "日"; break;
            case DayOfWeek.Thursday: week = "四"; break;
            case DayOfWeek.Tuesday: week = "二"; break;
            case DayOfWeek.Wednesday: week = "三"; break;
        }
        if (isDate)
        {
            return date.ToString(format) + " 星期" + week;
        }
        else
        {
            return "星期" + week;
        }
    }
    /// <summary>
    /// HTML编码
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    //public static string HtmlEncode(this string str)
    //{
    //    return HttpContext.Current.Server.HtmlEncode(str);
    //}
    /// <summary>
    /// URL编码
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    //public static string UrlEncode(this string str)
    //{
    //    return str.IsNullOrEmpty() ? "" : HttpContext.Current.Server.UrlEncode(str);
    //}
    /// <summary>
    /// URL解码
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    //public static string UrlDecode(this string str)
    //{
    //    return str.IsNullOrEmpty() ? "" : HttpContext.Current.Server.UrlDecode(str);
    //}

    /// <summary>
    /// 获取与 Web 服务器上的指定虚拟路径相对应的物理文件路径。
    /// </summary>
    /// <param name="Server"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    //public static string MapPathExt(this HttpServerUtility Server, string path)
    //{
    //    if (path.StartsWith(@"\\") || path.Contains(":"))
    //    {
    //        return path;
    //    }
    //    else
    //    {
    //        return Server.MapPath(path);
    //    }
    //}

    /// <summary>
    /// 使用CDATA的方式将value保存在指定的element中
    /// </summary>
    /// <param name="element"></param>
    /// <param name="value"></param>
    //public static void SetCDataValue(this System.Xml.Linq.XElement element, string value)
    //{
    //    element.RemoveNodes();
    //    element.Add(new System.Xml.Linq.XCData(value));
    //}

    /// <summary>
    /// 返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="value">要搜寻的字符串。</param>
    /// <param name="comparisonType">指定搜索规则的枚举值之一</param>
    /// <returns>如果 value 参数出现在此字符串中，或者 value 为空字符串 ("")，则为 true；否则为 false</returns>
    //public static bool Contains(this string source, string value, StringComparison comparisonType)
    //{

    //    if (source == null || value == null) { return false; }
    //    if (value == "") { return true; }
    //    return (source.IndexOf(value, comparisonType) >= 0);
    //}

    /// <summary>
    /// 通过使用默认的相等或字符比较器确定序列是否包含指定的元素。
    /// </summary>
    /// <param name="source">要在其中定位某个值的序列。</param>
    /// <param name="value">要在序列中定位的值。</param>
    /// <param name="comparisonType">指定搜索规则的枚举值之一</param>
    /// <exception cref="System.ArgumentNullException">source 为 null</exception>
    /// <returns>如果源序列包含具有指定值的元素，则为 true；否则为 false。</returns>
    //public static bool Contains(this string[] source, string value, StringComparison comparisonType)
    //{
    //    return System.Linq.Enumerable.Contains(source, value, new CompareText(comparisonType));
    //}
    //private class CompareText : IEqualityComparer<string>
    //{
    //    private StringComparison m_comparisonType { get; set; }
    //    public int GetHashCode(string t) { return t.GetHashCode(); }
    //    public CompareText(StringComparison comparisonType) { this.m_comparisonType = comparisonType; }
    //    public bool Equals(string x, string y)
    //    {
    //        if (x == y) { return true; }
    //        if (x == null || y == null) { return false; }
    //        else { return x.Equals(y, m_comparisonType); }
    //    }
    //}

    /// <summary>
    /// 序列化对象为xml字符串
    /// </summary>
    /// <param name="obj">要序列化的对象</param>
    /// <returns>xml格式字符串</returns>
    public static string Serialize(this object obj)
    {
        if (obj == null) { return ""; }
        Type type = obj.GetType();
        if (type.IsSerializable)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(type);
                XmlWriterSettings xset = new XmlWriterSettings();
                xset.CloseOutput = true;
                xset.Encoding = Encoding.UTF8;
                xset.Indent = true;
                xset.CheckCharacters = false;
                System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(sb, xset);
                xs.Serialize(xw, obj);
                xw.Flush();
                xw.Close();
                return sb.ToString();
            }
            catch { return ""; }
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 将对象中所有字段值转换成用&连接起来的字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToQueryString<T>(this T obj)
    {
        string str = "";
        Type type = typeof(T);
        PropertyInfo[] pros = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        if (pros != null && pros.Length > 0)
        {
            for(int i = 0; i < pros.Length; i++)
            {
                object val = pros[i].GetValue(obj,null);
                string appendStr = "";
                if (val != null)
                {
                    appendStr = val.ToString();
                }
                if (i == pros.Length - 1)
                {
                    str += $"{pros[i].Name}={appendStr}";
                }
                else
                {
                    str += $"{pros[i].Name}={appendStr}&";
                }
            }
        }
        return str;
    }
    /// <summary>
    /// 将int类型转为GUID格式
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static Guid ToGuid(this int i)
    {
        return i.ToString("00000000-0000-0000-0000-000000000000").ToGuid();
    }
    /// <summary>
    /// 将guid转换为int
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static int ToInt(this Guid guid)
    {
        return guid.ToString("N").TrimStart('0').ToInt();
    }
    /// <summary>
    /// 将char[]类型转换为char?[]
    /// </summary>
    /// <param name="charArray"></param>
    /// <returns></returns>
    public static char?[] ToCharArray(this char[] charArray)
    {
        char?[] c = null;
        if (charArray == null || charArray.Length <= 0)
        {
            return c;
        }
        else
        {
            c = new char?[charArray.Length];
            for(int i = 0; i < charArray.Length; i++)
            {
                c[i] = charArray[i];
            }
            return c;
        }
    }
    /// <summary>
    /// 将char[]数组中的元素组装到string[]中
    /// </summary>
    /// <param name="charArray"></param>
    /// <returns></returns>
    public static string[] ToStringArray(this char[] charArray)
    {
        string[] strArray = null;
        if (charArray == null || charArray.Length <= 0)
        {
            return strArray;
        }
        strArray = new string[charArray.Length];
        for(int i = 0; i < charArray.Length; i++)
        {
            strArray[i] = charArray[i].ToString();
        }
        return strArray;
    }
    public static string[] ToCharStringArray(this string strArray)
    {
        string[] newArray = null;
        if (strArray == null || strArray.Length <= 0)
        {
            return newArray;
        }
        newArray = new string[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            newArray[i] = strArray[i].ToString();
        }
        return newArray;
    }
}

