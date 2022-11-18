using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class FindRecipesByNameCommand : AsyncCommandBase
    {
        public FindRecipesByNameCommand(RecipesViewModel viewModel, IMaterialRepository materialRepository,
            IStore store)
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

                var vmRecipes = recipes.Select(x =>
                    new RecipeViewModel(_store)
                    {
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
                    });

                _viewModel.Recipes = new ObservableCollection<RecipeViewModel>(vmRecipes);
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось загрузить рецепты";
            }
        }
    }

    public class FindRecipesByTagsCommand : AsyncCommandBase
    {
        public FindRecipesByTagsCommand(RecipesViewModel viewModel, IMaterialRepository repository, IStore store)
        {
            _viewModel = viewModel;
            _repository = repository;
            _store = store;
        }

        private readonly RecipesViewModel _viewModel;
        private readonly IMaterialRepository _repository;
        private readonly IStore _store;

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var recipes = await _repository.FindRecipeByTags(
                    _viewModel.Tags
                        .Where(x => x.IsChecked)
                        .Select(x => x.Name)
                        .ToArray());

                var vmRecipes = recipes.Select(x =>
                    new RecipeViewModel(_store)
                    {
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
                    });

                _viewModel.Recipes = new ObservableCollection<RecipeViewModel>(vmRecipes);
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось загрузить рецепты";
            }
        }
    }
}