using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class LoginViewModel : ValidationViewModel
    {
        private readonly IStore _store;
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand UpdateCurrentViewModelCommand { get; }

        private string _login;
        [Required(ErrorMessage = "Не заполнено")]
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
                ValidateProperty(value, nameof(Login));
            }
        }
        
        private string _password;
        [Required(ErrorMessage = "Не заполнено")]
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                ValidateProperty(value, nameof(Password));
            }
        }
        
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public MessageViewModel ErrorMessageViewModel { get; }
        
        public ICommand LoginCommand { get; }
        
        public LoginViewModel(
            IStore store,
            IUserRepository repository,
            IMaterialRepository materialRepository,
            ITagRepository tagRepository)
        {
            _store = store;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(store, repository, tagRepository,  materialRepository);
            LoginCommand = new LoginCommand(this, repository, store);
            ErrorMessageViewModel = new MessageViewModel();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}