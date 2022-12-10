using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDbContextFactory<EfContext> _contextFactory;

        public UserRepository(IDbContextFactory<EfContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> IsExists(string login)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Users.AnyAsync(x => x.Login == login);
        }

        public async Task<bool> IsValid(string login, string password)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Users.AnyAsync(x => x.Login == login && x.Password == password);
        }

        public async Task<User> Get(string login, string password)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
        }
    }
}