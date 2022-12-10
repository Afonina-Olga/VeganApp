using System.ComponentModel;
using System.Threading.Tasks;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly IUserRepository _repository;
        private readonly LoginViewModel _viewModel;
        private readonly IStore _store;

        public LoginCommand(
            LoginViewModel viewModel,
            IUserRepository repository,
            IStore store)
        {
            _repository = repository;
            _viewModel = viewModel;
            _store = store;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var user = await _repository.Get(_viewModel.Login.Trim(), _viewModel.Password.Trim());
                if (user == null)
                {
                    _viewModel.ErrorMessage = "Неверный логин или пароль";
                }
                else
                {
                    _store.Login(_viewModel.Login, user.Role == Role.Admin);
                }
            }
            catch
            {
                _viewModel.ErrorMessage = "Не удалось авторизироваться";
            }
        }

        public override bool CanExecute(object parameter) => _viewModel.CanExecute;

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanExecute))
            {
                OnCanExecuteChanged();
            }
        }
    }
}