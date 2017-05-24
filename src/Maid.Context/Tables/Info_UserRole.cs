namespace Maid.Context.Tables
{
    /// <summary>
    /// 用户与角色的关系
    /// </summary>
    public class Info_UserRole
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public int UserId { get; set; }
        public virtual Info_User User { set; get; }
        /// <summary>
        /// 角色
        /// </summary>
        public int RoleId { get; set; }
        public virtual Info_Role Role { set; get; }
    }
}
