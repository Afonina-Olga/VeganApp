using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly IDbContextFactory<EfContext> _contextFactory;

        public TagRepository(IDbContextFactory<EfContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Tag>> GetByType(TagType type)
        {
            await using var context = _contextFactory.CreateDbContext();
            var result = type switch
            {
                TagType.Article => context.Tags.Where(x => x.ArticleRelative),
                TagType.Recipe => context.Tags.Where(x => x.RecipeRelative),
                TagType.Utility => context.Tags.Where(x => x.UtilityRelative),
                _ => throw new ArgumentException()
            };
            return await result.ToListAsync();
        }
    }
}