using Maid.Context.Tables;
using System.Threading.Tasks;

namespace Maid.Context
{
    public class DbConfiguration
    {
        public async static Task InitData(ApplicationDbContext context)
        {
            if (context.Database != null && context.Database.EnsureCreated())
            {
                //角色
                var role = new Info_Role[] {
                    new Info_Role { Name = "超级管理员" },
                    new Info_Role { Name = "普通用户" }
                };
                context.Roles.AddRange(role);
                //用户
                var user = new Info_User[]
                {
                    new Info_User { LoginId = "admin", Email = "maid@163.com", Pwd = "000000", Status = 1 },
                    new Info_User { LoginId = "lnice", Mobile = "123456789", Email = "123456789@163.com", Pwd = "000000", Status = 1 }
                };
                context.Users.AddRange(user);
                //菜单
                var menu = new Info_Menu[]
                {
                    new Info_Menu { Fid=0, Name="首页", Href="#", Sort=0 },
                    new Info_Menu { Fid=0, Name="教师业绩管理", Href="#", Sort=1 },
                    new Info_Menu { Fid=0, Name="教师评价管理", Href="#", Sort=2 },
                    new Info_Menu { Fid=0, Name="系统设置", Href="#", Sort=3 }
                };
                context.Menus.AddRange(menu);
                context.SaveChanges();
                //角色用户关系绑定
                var userrole = new Info_UserRole[]
                {
                    new Info_UserRole { RoleId = role[0].Id, UserId = user[0].Id },
                    new Info_UserRole { RoleId = role[1].Id, UserId = user[1].Id }
                };
                context.UserRoles.AddRange(userrole);
                //2级菜单
                var menu1 = new Info_Menu[]
                {
                    new Info_Menu { Fid=menu[1].Id, Name="业绩管理", Href="#", Sort=0 },
                    new Info_Menu { Fid=menu[1].Id, Name="我的业绩", Href="#", Sort=1 },
                    new Info_Menu { Fid=menu[1].Id, Name="业绩统计", Href="#", Sort=2 }
                };
                context.Menus.AddRange(menu1);

                await context.SaveChangesAsync();
            }
        }
    }
}
