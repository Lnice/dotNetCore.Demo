using Maid.Context;
using Maid.Context.Repository;
using Maid.Context.Tables;

namespace Maid.Respositories
{
    public class UserRoleRepository : BaseRepository<Info_UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
