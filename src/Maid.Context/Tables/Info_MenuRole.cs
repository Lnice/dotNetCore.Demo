namespace Maid.Context.Tables
{
    /// <summary>
    /// 角色与菜单关系
    /// </summary>
    public class Info_MenuRole
    {
        public int Id { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public int MenuId { get; set; }
        public virtual Info_Menu Menu { set; get; }
        /// <summary>
        /// 角色
        /// </summary>
        public int RoleId { get; set; }
        public virtual Info_Role Role { set; get; }
    }
}
