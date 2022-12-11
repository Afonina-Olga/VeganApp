using System.Collections.Generic;
using System.Threading.Tasks;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<List<Article>> FindArticleByTags(string[] tags = null);
        Task<List<Article>> FindArticleByFilter(string filter = null);

        Task<IEnumerable<Recipe>> GetRecipes();
        Task<List<Recipe>> FindRecipeByTags(string[] tags = null);
        Task<List<Recipe>> FindRecipeByFilter(string filter = null);

        Task<IEnumerable<Utility>> GetUtilities();
        Task<List<Utility>> FindUtilityByTags(string[] tags = null);
        Task<List<Utility>> FindUtilityByFilter(string filter = null);

        Task<bool> DeleteArticle(int id);
        Task<Article> UpdateArticle(int id, Article article);
        Task<Article> CreateArticle(Article article);
        
        Task<bool> DeleteUtility(int id);
        Task<Utility> UpdateUtility(int id, Utility utility);
        Task<Utility> CreateUtility(Utility utility);
        
        Task<bool> DeleteRecipe(int id);
        Task<Recipe> UpdateRecipe(int id, Recipe recipe);
        Task<Recipe> CreateRecipe(Recipe recipe);
    }
}