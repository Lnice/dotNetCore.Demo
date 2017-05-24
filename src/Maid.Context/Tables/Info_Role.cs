using System.Collections.Generic;

namespace Maid.Context.Tables
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Info_Role
    {
        public int Id { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限级别
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 一个角色的多个用户
        /// </summary>
        public virtual ICollection<Info_UserRole> Users { get; set; }
        /// <summary>
        /// 一个角色的多个菜单
        /// </summary>
        public virtual ICollection<Info_MenuRole> Menus { get; set; }
        /// <summary>
        /// 一个角色的多个操作
        /// </summary>
        public virtual ICollection<Info_OperRole> Opers { get; set; }
    }
}
