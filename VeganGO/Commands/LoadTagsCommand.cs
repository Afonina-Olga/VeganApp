using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class LoadTagsCommand : AsyncCommandBase
    {
        public LoadTagsCommand(MaterialBaseViewModel viewModel, ITagRepository repository, TagType type)
        {
            _viewModel = viewModel;
            _repository = repository;
            _type = type;
        }

        private readonly MaterialBaseViewModel _viewModel;
        private readonly ITagRepository _repository;
        private readonly TagType _type;

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var articles = await _repository.GetByType(_type);
                _viewModel.Tags = new ObservableCollection<TagViewModel>(
                    articles.Select(x => new TagViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        IsChecked = true
                    }));
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось загрузить теги";
            }
        }
    }
}