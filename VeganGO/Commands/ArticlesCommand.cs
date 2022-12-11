using System;
using System.Threading.Tasks;
using System.Windows;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class DeleteArticleCommand : AsyncCommandBase
    {
        private readonly ArticleViewModel _viewModel;
        private readonly IMaterialRepository _materialRepository;
        private readonly IStore _store;

        public DeleteArticleCommand(
            ArticleViewModel viewModel,
            IMaterialRepository materialRepository,
            IStore store)
        {
            _viewModel = viewModel;
            _materialRepository = materialRepository;
            _store = store;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (!(parameter is int id))
            {
                return;
            }

            try
            {
                await _materialRepository.DeleteArticle(id);
                _store.UpdateArticles();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось удалить статью");
            }
        }
    }

    public class UpdateArticleCommand : AsyncCommandBase
    {
        public override Task ExecuteAsync(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }

    public class CreateArticleCommand : AsyncCommandBase
    {
        public override Task ExecuteAsync(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}