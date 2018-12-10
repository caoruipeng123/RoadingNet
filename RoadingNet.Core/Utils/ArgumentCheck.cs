using System;

namespace RoadingNet.Utils
{
    public class ArgumentCheck
    {
        /// <summary>
        /// 检验参数不能为空，如果为空抛出异常
        /// </summary>
        /// <param name="argument">被校验的参数</param>
        /// <param name="argumentName">参数名称</param>
        public static void NotNull(object argument,string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException($"参数{argumentName}不能为空！",argumentName);
            }
        }
        /// <summary>
        /// 检验参数不能为空，如果为空抛出异常
        /// </summary>
        /// <param name="argument">被校验的参数</param>
        /// <param name="argumentName">参数名称</param>
        /// <param name="message">如果参数为空，抛出的异常信息</param>
        public static void NotNull(object argument, string argumentName, string message)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
        /// <summary>
        /// 检验参数为true，如果为false，抛出异常
        /// </summary>
        /// <param name="argument">被校验的参数</param>
        /// <param name="argumentName">参数名称</param>
        /// <param name="message">参数为false，抛出的异常信息</param>
        public static void IsTrue(bool argument, string argumentName, string message)
        {
            if (!argument)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
        /// <summary>
        /// 检验参数为true，如果为false，抛出异常
        /// </summary>
        /// <param name="argument">被校验的参数</param>
        /// <param name="argumentName">参数为false，抛出的异常信息</param>
        public static void IsTrue(bool argument, string argumentName)
        {
            if (!argument)
            {
                throw new ArgumentException($"参数{argumentName}不能为false",argumentName);
            }
        }
        /// <summary>
        /// 检验参数为false，如果为true，抛出异常
        /// </summary>
        /// <param name="argument">被校验的参数</param>
        /// <param name="message">参数为true，抛出的异常信息</param>
        public static void IsFalse(bool argument, string argumentName)
        {
            if (argument)
            {
                throw new ArgumentException($"参数{argumentName}不能为false", argumentName);
            }
        }
        /// <summary>
        /// 检验参数为false，如果为true，抛出异常
        /// </summary>
        /// <param name="argument">被校验的参数</param>
        /// <param name="argumentName">参数名称</param>
        /// <param name="message">参数为true，抛出的异常信息</param>
        public static void IsFalse(bool argument, string argumentName, string message)
        {
            if (argument)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}
