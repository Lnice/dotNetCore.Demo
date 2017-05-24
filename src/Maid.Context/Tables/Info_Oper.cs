namespace Maid.Context.Tables
{
    /// <summary>
    /// 操作
    /// </summary>
    public class Info_Oper
    {
        public int Id { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public int MenuId { get; set; }
        public virtual Info_Menu Menu { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 一个操作的多个角色
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Info_OperRole> Roles { get; set; }
    }
}
