using System;

namespace Maid.Context.Tables
{
    /// <summary>
    /// 用户注册日志
    /// </summary>
    public class Log_User
    {
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string Address { get; set; }
    }
}
