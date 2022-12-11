using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class RecipeViewModel : ViewModelBase
    {
        public int Id { get; set; }
        private readonly IStore _store;
        public bool IsAdmin { get; set; } 
        
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _imagePath;

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public ObservableCollection<TagViewModel> Tags { get; set; }
        public ObservableCollection<IngridientViewModel> Ingridients { get; set; }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand ShowCommand { get; }
        public ICommand DeleteCommand { get; }

        public RecipeViewModel(IStore store, IMaterialRepository materialRepository)
        {
            _store = store;
            ShowCommand = new ShowCommand(this, store);
            DeleteCommand = new DeleteRecipeCommand(this, materialRepository, store);
            IsAdmin = store.IsAdminMode;
        }
    }

    public class RecipesViewModel : MaterialBaseViewModel
    {
        private readonly IStore _store;
        private ObservableCollection<RecipeViewModel> _recipes;

        // ReSharper disable once MemberCanBePrivate.Global
        public ObservableCollection<RecipeViewModel> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand LoadRecipesCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand LoadTagsCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand FindRecipesByFilterCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand FindRecipesByTagsCommand { get; }

        public RecipesViewModel(IMaterialRepository repository, ITagRepository tagRepository, IStore store)
            : base(repository, tagRepository, store)
        {
            _store = store;
            _store.RecipesChanged += OnRecipesChanged;
            LoadRecipesCommand = new LoadRecipesCommand(this, repository, store);
            LoadRecipesCommand.Execute(null);
            LoadTagsCommand = new LoadTagsCommand(this, tagRepository, TagType.Recipe);
            LoadTagsCommand.Execute(null);
            FindRecipesByFilterCommand = new FindRecipesByNameCommand(this, repository, store);
            FindRecipesByTagsCommand = new FindRecipesByTagsCommand(this, repository, store);
        }

        private void OnRecipesChanged()
        {
            LoadRecipesCommand.Execute(null);
        }
    }
}