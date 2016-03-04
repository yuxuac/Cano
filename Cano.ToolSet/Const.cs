using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cano
{
    /// <summary>
    /// Consts
    /// </summary>
    public static class Const
    {
        /// <summary>
        /// 得到当前时间格式化字符串
        /// </summary>
        public static DT DateTime = new DT();

        /// <summary>
        /// 得到当前路径
        /// </summary>
        public static string BaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// GiveMeATxtFile
        /// </summary>
        public static string GiveMeATxtFile = Path.Combine(BaseDirectory, DateTime.Format1 + ".txt");
    }

    /// <summary>
    /// 当前时间格式化字符串
    /// </summary>
    public class DT
    {
        /// <summary>
        /// 返回日期格式: yyyyMMddHHmmss
        /// </summary>
        public string Format1
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            private set { }
        }

        /// <summary>
        /// 返回日期格式: yyyyMMdd-HHmmss
        /// </summary>
        public string Format2
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMdd-HHmmss");
            }
            private set { }
        }

        /// <summary>
        /// 返回日期格式: yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string Format3
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            private set { }
        }

        /// <summary>
        /// 返回日期格式: yyyy-MM-dd HH:mm:ss ffff
        /// </summary>
        public string Format4
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            }
            private set { }
        }
    }
}
