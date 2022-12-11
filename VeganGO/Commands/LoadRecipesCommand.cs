using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class LoadRecipesCommand : AsyncCommandBase
    {
        public LoadRecipesCommand(RecipesViewModel viewModel, IMaterialRepository materialRepository, IStore store)
        {
            _viewModel = viewModel;
            _materialRepository = materialRepository;
            _store = store;
        }

        private readonly RecipesViewModel _viewModel;
        private readonly IMaterialRepository _materialRepository;
        private readonly IStore _store;

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var recipes = await _materialRepository.FindRecipeByFilter(_viewModel.Filter);

                _viewModel.Recipes = new ObservableCollection<RecipeViewModel>(recipes
                    .Select(x => new RecipeViewModel(_store, _materialRepository)
                    {
                        Id=x.Id,
                        Text = x.Text,
                        ImagePath = x.MainImagePath,
                        Name = x.Name,
                        Tags = new ObservableCollection<TagViewModel>(x.Tags.Select(t => new TagViewModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            IsChecked = true
                        })),
                        Ingridients = new ObservableCollection<IngridientViewModel>(
                            x.Ingredients.Select(i => new IngridientViewModel
                            {
                                Id = i.Id,
                                Name = i.Name
                            }))
                    }));
            }
            catch (Exception ex)
            {
                _viewModel.ErrorMessage = "Не удалось загрузить рецепты";
            }
        }
    }
}