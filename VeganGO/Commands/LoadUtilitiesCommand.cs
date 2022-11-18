using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class LoadUtilitiesCommand : AsyncCommandBase
    {
        public LoadUtilitiesCommand(UtilitiesViewModel viewModel, IMaterialRepository materialRepository, IStore store)
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
                var utilities = await _materialRepository.FindUtilityByFilter(_viewModel.Filter);

                _viewModel.Utilities = new ObservableCollection<UtilityViewModel>(utilities
                    .Select(x => new UtilityViewModel(_store)
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
                        })),
                    }));
            }
            catch (Exception ex)
            {
                _viewModel.ErrorMessage = "Не удалось загрузить полезности";
            }
        }
    }
}