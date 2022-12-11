using System;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly IStore _store;

        public UpdateCurrentViewModelCommand(IStore store)
        {
            _store = store;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (!(parameter is ViewType viewType)) return;
            ViewModelBase currentViewModel = viewType switch
            {
                ViewType.Articles => App.Services.GetRequiredService<ArticlesViewModel>(),
                ViewType.Recipes => App.Services.GetRequiredService<RecipesViewModel>(),
                ViewType.Utilities => App.Services.GetRequiredService<UtilitiesViewModel>(),
                ViewType.Registration => App.Services.GetRequiredService<RegistrationViewModel>(),
                ViewType.Login => App.Services.GetRequiredService<LoginViewModel>(),
                ViewType.About => App.Services.GetRequiredService<AboutViewModel>(),
                ViewType.ArticleFull => App.Services.GetRequiredService<ArticleViewModel>(),
                ViewType.RecipeFull => App.Services.GetRequiredService<RecipeViewModel>(),
                ViewType.UtilityFull => App.Services.GetRequiredService<UtilityViewModel>(),
                _ => throw new ArgumentException()
            };

            if (viewType == ViewType.Login)
            {
                _store.Login(null, false);
            }

            _store.UpdateCurrentViewModel(currentViewModel);
        }

        public event EventHandler CanExecuteChanged;
    }
}