using System;

namespace RoadingNet.Utils
{
    public class ArgumentCheck
    {
        /// <summary>
        /// 检验参数不能为空，如果为空抛出异常
        /// </summary>
        /// <param name="argumentName"></param>
        public static void NotNull(string argumentName)
        {
            if (argumentName == null)
            {
                throw new ArgumentException($"参数{argumentName}不能为空！",argumentName);
            }
        }
    }
}
