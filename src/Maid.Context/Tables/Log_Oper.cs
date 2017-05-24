using System;
namespace Maid.Context.Tables
{
    /// <summary>
    /// 用户操作日志
    /// </summary>
    public class Log_Oper
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 请求
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// 请求结果
        /// </summary>
        public string Result { get; set; }
    }
}
