using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class FindArticlesByNameCommand : AsyncCommandBase
    {
        public FindArticlesByNameCommand(ArticlesViewModel viewModel, IMaterialRepository materialRepository, IStore store)
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

                var vmArticles = articles.Select(x =>
                    new ArticleViewModel(_store, _materialRepository)
                    {
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
                    });

                _viewModel.Articles = new ObservableCollection<ArticleViewModel>(vmArticles);
            }
            catch(Exception ex)
            {
                _viewModel.ErrorMessage = "Не удалось загрузить статьи";
            }
        }
    }
    
    public class FindArticlesByTagsCommand : AsyncCommandBase
    {
        public FindArticlesByTagsCommand(ArticlesViewModel viewModel, IMaterialRepository materialRepository, IStore store)
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
                var articles = await _materialRepository.FindArticleByTags(
                    _viewModel.Tags
                        .Where(x=>x.IsChecked)
                        .Select(x => x.Name)
                        .ToArray());

                var vmArticles = articles.Select(x =>
                    new ArticleViewModel(_store, _materialRepository)
                    {
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
                    });

                _viewModel.Articles = new ObservableCollection<ArticleViewModel>(vmArticles);
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось загрузить статьи";
            }
        }
    }
}