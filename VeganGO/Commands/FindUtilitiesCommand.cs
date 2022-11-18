using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
     public class FindUtilitiesByNameCommand : AsyncCommandBase
    {
        public FindUtilitiesByNameCommand(
            UtilitiesViewModel viewModel,
            IMaterialRepository materialRepository,
            IStore store)
        {
            _viewModel = viewModel;
            _materialRepository = materialRepository;
            _store = store;
        }

        private readonly UtilitiesViewModel _viewModel;
        private readonly IMaterialRepository _materialRepository;
        private readonly IStore _store;

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var recipes = await _materialRepository.FindUtilityByFilter(_viewModel.Filter);

                var vmUtilities = recipes.Select(x =>
                    new UtilityViewModel(_store)
                    {
                        Text = x.Text,
                        ImagePath = x.MainImagePath,
                        Name = x.Name,
                        PublishDate = x.PublishDate,
                        Author = x.Author,
                        Description = x.Description,
                        Tags = new ObservableCollection<TagViewModel>(x.Tags.Select(t => new TagViewModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            IsChecked = true
                        }))
                    });

                _viewModel.Utilities = new ObservableCollection<UtilityViewModel>(vmUtilities);
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось загрузить полезности";
            }
        }
    }

    public class FindUtilitiesByTagsCommand : AsyncCommandBase
    {
        public FindUtilitiesByTagsCommand(UtilitiesViewModel viewModel, IMaterialRepository repository, IStore store)
        {
            _viewModel = viewModel;
            _repository = repository;
            _store = store;
        }

        private readonly UtilitiesViewModel _viewModel;
        private readonly IMaterialRepository _repository;
        private readonly IStore _store;

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var recipes = await _repository.FindUtilityByTags(
                    _viewModel.Tags
                        .Where(x => x.IsChecked)
                        .Select(x => x.Name)
                        .ToArray());

                var vmUtilities = recipes.Select(x =>
                    new UtilityViewModel(_store)
                    {
                        Text = x.Text,
                        ImagePath = x.MainImagePath,
                        Name = x.Name,
                        Description = x.Description,
                        PublishDate = x.PublishDate,
                        Author = x.Author,
                        Tags = new ObservableCollection<TagViewModel>(x.Tags.Select(t => new TagViewModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            IsChecked = true
                        })),
                    });

                _viewModel.Utilities = new ObservableCollection<UtilityViewModel>(vmUtilities);
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось загрузить полезности";
            }
        }
    }
}