using System.Threading.Tasks;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsExists(string login);
        Task<bool> IsValid(string login, string password);
    }
}