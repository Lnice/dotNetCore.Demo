namespace Maid.Context.Tables
{
    /// <summary>
    /// 用户验证
    /// </summary>
    public class Info_User
    {
        public int Id { get; set; }
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 一个用户的多个角色
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Info_UserRole> Roles { get; set; }
    }
}
