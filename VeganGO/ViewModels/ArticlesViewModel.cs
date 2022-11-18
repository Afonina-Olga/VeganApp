using System.Collections.ObjectModel;
using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
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

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand ShowCommand { get; }

        public ArticleViewModel(IStore store)
        {
            ShowCommand = new ShowCommand(this, store);
        }
    }

    public class ArticlesViewModel : MaterialBaseViewModel
    {
        private ObservableCollection<ArticleViewModel> _articles;

        // ReSharper disable once MemberCanBePrivate.Global
        public ObservableCollection<ArticleViewModel> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand LoadArticlesCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand LoadTagsCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand FindArticlesByFilterCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand FindArticlesByTagsCommand { get; }

        public ArticlesViewModel(
            IMaterialRepository repository,
            ITagRepository tagRepository,
            IStore store)
            : base(repository, tagRepository, store)
        {
            LoadArticlesCommand = new LoadArticlesCommand(this, repository, store);
            LoadArticlesCommand.Execute(null);
            LoadTagsCommand = new LoadTagsCommand(this, tagRepository, TagType.Article);
            LoadTagsCommand.Execute(null);
            FindArticlesByFilterCommand = new FindArticlesByNameCommand(this, repository, store);
            FindArticlesByTagsCommand = new FindArticlesByTagsCommand(this, repository, store);
        }
    }
}