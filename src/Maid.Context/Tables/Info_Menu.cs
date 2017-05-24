using System.Collections.Generic;

namespace Maid.Context.Tables
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Info_Menu
    {
        public int Id { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 一个菜单的多个子操作
        /// </summary>
        public virtual ICollection<Info_Oper> Opers { get; set; }
        /// <summary>
        /// 一个菜单的多个角色
        /// </summary>
        public virtual ICollection<Info_MenuRole> Roles { get; set; }
    }
}
