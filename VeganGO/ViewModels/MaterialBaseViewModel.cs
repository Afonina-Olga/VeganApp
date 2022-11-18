using System.Collections.ObjectModel;
using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class MaterialBaseViewModel : ViewModelBase
    {
        protected MaterialBaseViewModel(
            IMaterialRepository repository,
            ITagRepository tagRepository,
            IStore store)
        {
            ErrorMessageViewModel = new MessageViewModel();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public ObservableCollection<TagViewModel> Tags { get; set; }
        
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        // ReSharper disable once MemberCanBeProtected.Global
        public MessageViewModel ErrorMessageViewModel { get; }
        
        private string _filter;

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }
    }
}