using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IStore _store;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMaterialRepository _materialRepository;

        public bool IsLoggedIn => !string.IsNullOrEmpty(Login);

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            } 
        }

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(
            IStore store,
            IUserRepository userRepository,
            IMaterialRepository materialRepository,
            ITagRepository tagRepository)
        {
            _store = store;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _materialRepository = materialRepository;
            CurrentViewModel = new LoginViewModel(store, userRepository, materialRepository, tagRepository);
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(store, userRepository, tagRepository, materialRepository);
            _store.CurrentViewModelUpdated += OnCurrentViewModelUpdated;
            _store.UserAuthorized += OnUserAuthorized;
            _store.UserLogout += OnUserLogout;
        }

        private void OnUserLogout()
        {
            Login = null;
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void OnUserAuthorized(string login)
        {
            Login = login;
            CurrentViewModel = new RecipesViewModel(_materialRepository, _tagRepository, _store);
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void OnCurrentViewModelUpdated(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;
        }

        public override void Dispose()
        {
            _store.CurrentViewModelUpdated -= OnCurrentViewModelUpdated;
            _store.UserAuthorized -= OnUserAuthorized;
            base.Dispose();
        }
    }
}