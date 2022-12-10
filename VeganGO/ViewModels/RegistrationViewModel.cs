using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class RegistrationViewModel : ValidationViewModel
    {
        private readonly IStore _store;
        
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
        
        private string _firstname;
        [Required(ErrorMessage = "Не заполнено")]
        [RegularExpression(@"^\p{IsCyrillic}+$", ErrorMessage = "Допустимы только кириллические символы без пробелов")]
        public string FirstName
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(FirstName));
                ValidateProperty(value, nameof(FirstName));
            }
        }
        
        private string _lastName;
        [Required(ErrorMessage = "Не заполнено")]
        [RegularExpression(@"^\p{IsCyrillic}+$", ErrorMessage = "Допустимы только кириллические символы без пробелов")]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                ValidateProperty(value, nameof(LastName));
            }
        }
        
        private string _middleName;
        [Required(ErrorMessage = "Не заполнено")]
        [RegularExpression(@"^\p{IsCyrillic}+$", ErrorMessage = "Допустимы только кириллические символы без пробелов")]
        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
                ValidateProperty(value, nameof(MiddleName));
            }
        }
        
        private string _phone;
        [Required(ErrorMessage = "Не заполнено")]
        [RegularExpression("\\+7\\d{10}", ErrorMessage = "Неверный формат номера")]
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
                ValidateProperty(value, nameof(Phone));
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
        
        private string _confirmPassword;
        [Required(ErrorMessage = "Не заполнено")]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                ValidateProperty(value, nameof(ConfirmPassword));
            }
        }
        
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public MessageViewModel ErrorMessageViewModel { get; }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand UpdateCurrentViewModelCommand { get; }
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand RegistrationCommand { get; }
        
        public RegistrationViewModel(
            IStore store,
            IUserRepository repository,
            IMaterialRepository materialRepository,
            ITagRepository tagRepository)
        {
            _store = store;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(store, repository, tagRepository, materialRepository);
            RegistrationCommand = new RegistrationCommand(this, repository, materialRepository, tagRepository, store);
            ErrorMessageViewModel = new MessageViewModel();
        }
    }
}