using System;
using VeganGO.ViewModels;

namespace VeganGO.State
{
    public interface IStore
    {
        bool IsAdminMode { get; set; }
        event Action<ViewModelBase> CurrentViewModelUpdated;
        event Action<string> UserAuthorized;
        event Action UserLogout;
        event Action ArticlesChanged;
        event Action UtilitiesChanged;
        event Action RecipesChanged;
        
        void UpdateCurrentViewModel(ViewModelBase currentViewModel);
        void Login(string login, bool isAdmin);
        void Logout();
        void UpdateArticles();
        void UpdateRecipes();
        void UpdateUtilities();
    }
}