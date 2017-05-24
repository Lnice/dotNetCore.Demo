using Maid.Context;
using Maid.Context.Repository;
using Maid.Context.Tables;

namespace Maid.Respositories
{
    public class UserRepository: BaseRepository<Info_User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
