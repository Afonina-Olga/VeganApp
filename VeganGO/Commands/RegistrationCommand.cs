using System;
using System.ComponentModel;
using System.Threading.Tasks;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;
using VeganGO.Views;

namespace VeganGO.Commands
{
    public class RegistrationCommand : AsyncCommandBase
    {
        private readonly RegistrationViewModel _viewModel;
        private readonly IUserRepository _userRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IStore _store;

        public RegistrationCommand(
            RegistrationViewModel viewModel,
            IUserRepository userRepository,
            IMaterialRepository materialRepository,
            ITagRepository tagRepository,
            IStore store)
        {
            _viewModel = viewModel;
            _userRepository = userRepository;
            _store = store;
            _materialRepository = materialRepository;
            _tagRepository = tagRepository;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegistrationViewModel.CanExecute))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var login = _viewModel.Login.Trim();
                var isExists = await _userRepository.IsExists(login);
                if (isExists)
                {
                    _viewModel.ErrorMessage = "Пользователь уже зарегистрирован";
                    return;
                }

                await _userRepository.Create(new User()
                {
                    Login = login,
                    FirstName = _viewModel.FirstName.Trim(),
                    MiddleName = _viewModel.LastName.Trim(),
                    LastName = _viewModel.LastName.Trim(),
                    Password = _viewModel.Password.Trim(),
                    PhoneNumber = _viewModel.Phone.Trim()
                });

                _store.UpdateCurrentViewModel(new LoginViewModel(
                    _store,
                    _userRepository,
                    _materialRepository,
                    _tagRepository));
            }
            catch (Exception ex)
            {
                _viewModel.ErrorMessage = "Не удалось зарегистрироваться";
            }
        }

        public override bool CanExecute(object parameter) => _viewModel.CanExecute;

    }
}