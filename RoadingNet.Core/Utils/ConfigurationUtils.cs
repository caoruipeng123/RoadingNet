using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RoadingNet.Utils
{
    public class ConfigurationUtils
    {
        public static object GetSection(string sectionName)
        {
            try
            {
                return ConfigurationManager.GetSection(sectionName.TrimEnd('/'));
            }
            catch (ConfigurationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("无法识别配置文件节点： {0}", sectionName), ex);
            }
        }
    }
}
