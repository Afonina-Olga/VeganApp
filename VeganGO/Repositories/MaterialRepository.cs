using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly IDbContextFactory<EfContext> _contextFactory;

        public MaterialRepository(IDbContextFactory<EfContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        #region Article

        public async Task<List<Article>> FindArticleByTags(string[] tags = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Articles
                .Include(x => x.Tags)
                .AsQueryable();

            if (tags != null && tags.Any())
            {
                return await result
                    .Where(x => x.Tags.Select(y => y.Name).Any(z => tags.Contains(z)))
                    .ToListAsync();
            }

            return new List<Article>();
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Articles.Include(x => x.Tags).ToListAsync();
        }

        public async Task<List<Article>> FindArticleByFilter(string filter = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Articles
                .Include(x => x.Tags)
                .AsQueryable();

            if (filter != null)
            {
                result = result.Where(x => x.Name.Contains(filter));
            }

            return await result.ToListAsync();
        }

        #endregion

        #region Recipe

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context
                .Recipes
                .Include(x => x.Tags)
                .Include(x=>x.Ingredients)
                .ToListAsync();
        }

        public async Task<List<Recipe>> FindRecipeByTags(string[] tags = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Recipes
                .Include(x => x.Tags)
                .Include(x=>x.Ingredients)
                .AsQueryable();

            if (tags != null && tags.Any())
            {
                return await result
                    .Where(x => x.Tags.Select(y => y.Name).Any(z => tags.Contains(z)))
                    .ToListAsync();
            }

            return new List<Recipe>();
        }

        public async Task<List<Recipe>> FindRecipeByFilter(string filter = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Recipes
                .Include(x=>x.Ingredients)
                .Include(x => x.Tags)
                .AsQueryable();

            if (filter != null)
            {
                result = result.Where(x => x.Name.Contains(filter));
            }

            return await result.ToListAsync();
        }

        #endregion

        #region Utility

        public async Task<IEnumerable<Utility>> GetUtilities()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Utilities.Include(x => x.Tags).ToListAsync();
        }

        public async Task<List<Utility>> FindUtilityByTags(string[] tags = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Utilities
                .Include(x => x.Tags)
                .AsQueryable();

            if (tags != null && tags.Any())
            {
                return await result
                    .Where(x => x.Tags.Select(y => y.Name).Any(z => tags.Contains(z)))
                    .ToListAsync();
            }

            return new List<Utility>();
        }

        public async Task<List<Utility>> FindUtilityByFilter(string filter = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Utilities
                .Include(x => x.Tags)
                .AsQueryable();

            if (filter != null)
            {
                result = result.Where(x => x.Name.Contains(filter));
            }

            return await result.ToListAsync();
        }

        #endregion
    }
}