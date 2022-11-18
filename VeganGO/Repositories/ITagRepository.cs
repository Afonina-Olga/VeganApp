using System.Collections.Generic;
using System.Threading.Tasks;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetByType(TagType type);
    }
}