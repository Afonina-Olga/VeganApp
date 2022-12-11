using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class LoadArticlesCommand : AsyncCommandBase
    {
        public LoadArticlesCommand(ArticlesViewModel viewModel, IMaterialRepository materialRepository, IStore store)
        {
            _viewModel = viewModel;
            _materialRepository = materialRepository;
            _store = store;
        }

        private readonly ArticlesViewModel _viewModel;
        private readonly IMaterialRepository _materialRepository;
        private readonly IStore _store;

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var articles = await _materialRepository.FindArticleByFilter(_viewModel.Filter);

                _viewModel.Articles = new ObservableCollection<ArticleViewModel>(articles
                    .Select(x => new ArticleViewModel(_store, _materialRepository)
                    {
                        Id=x.Id,
                        Description = x.Description,
                        Text = x.Text,
                        ImagePath = x.MainImagePath,
                        Name = x.Name,
                        Tags = new ObservableCollection<TagViewModel>(x.Tags.Select(t=>new TagViewModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            IsChecked = true
                        }))
                    }));
            }
            catch(Exception ex)
            {
                _viewModel.ErrorMessage = "Не удалось загрузить статьи";
            }
        }
    }
}