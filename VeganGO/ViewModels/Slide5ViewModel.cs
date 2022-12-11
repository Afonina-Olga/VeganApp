using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class Slide5ViewModel
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand UpdateCurrentViewModelCommand { get; }

        public Slide5ViewModel(IStore store,
            IUserRepository repository,
            IMaterialRepository materialRepository,
            ITagRepository tagRepository)
        {
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(store);
        }
    }
}