using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeganGO.Commands;
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

            var result = await context
                .Articles
                .Include(x => x.Tags)
                .ToListAsync();

            if (filter != null)
            {
                result = result.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
            }

            return result;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            context.Articles.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<Article> UpdateArticle(int id, Article article)
        {
            throw new NotImplementedException();
        }

        public Task<Article> CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Recipe

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context
                .Recipes
                .Include(x => x.Tags)
                .Include(x => x.Ingredients)
                .ToListAsync();
        }

        public async Task<List<Recipe>> FindRecipeByTags(string[] tags = null)
        {
            await using var context = _contextFactory.CreateDbContext();

            var result = context
                .Recipes
                .Include(x => x.Tags)
                .Include(x => x.Ingredients)
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

            var result = await context
                .Recipes
                .Include(x => x.Ingredients)
                .Include(x => x.Tags)
                .ToListAsync();

            if (filter != null)
            {
                result = result.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
            }

            return result;
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            context.Recipes.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<Recipe> UpdateRecipe(int id, Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
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

            var result = await context
                .Utilities
                .Include(x => x.Tags)
                .ToListAsync();

            if (filter != null)
            {
                result = result.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
            }

            return result;
        }

        public async Task<bool> DeleteUtility(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Utilities.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            context.Utilities.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<Utility> UpdateUtility(int id, Utility utility)
        {
            throw new NotImplementedException();
        }

        public Task<Utility> CreateUtility(Utility utility)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}