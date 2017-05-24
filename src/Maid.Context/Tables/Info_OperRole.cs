namespace Maid.Context.Tables
{
    /// <summary>
    /// 角色与操作的关系
    /// </summary>
    public class Info_OperRole
    {
        public int Id { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public int OperId { get; set; }
        public virtual Info_Oper Oper { set; get; }
        /// <summary>
        /// 角色
        /// </summary>
        public int RoleId { get; set; }
        public virtual Info_Role Role { set; get; }
    }
}
