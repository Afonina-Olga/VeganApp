using System;
using System.Windows.Input;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly IStore _store;
        private readonly IUserRepository _userRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ITagRepository _tagRepository;

        public UpdateCurrentViewModelCommand(
            IStore store,
            IUserRepository userRepository,
            ITagRepository tagRepository,
            IMaterialRepository materialRepository)
        {
            _store = store;
            _userRepository = userRepository;
            _materialRepository = materialRepository;
            _tagRepository = tagRepository;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (!(parameter is ViewType viewType)) return;
            ViewModelBase currentViewModel = viewType switch
            {
                ViewType.Articles => new ArticlesViewModel(_materialRepository, _tagRepository, _store),
                ViewType.Recipes => new RecipesViewModel(_materialRepository, _tagRepository, _store),
                ViewType.Utilities => new UtilitiesViewModel(_materialRepository, _tagRepository, _store),
                ViewType.About => new AboutViewModel(),
                ViewType.Registration => new RegistrationViewModel(_store, _userRepository, _materialRepository,
                    _tagRepository),
                ViewType.Login => new LoginViewModel(_store, _userRepository, _materialRepository, _tagRepository),
                _ => throw new ArgumentException()
            };

            if (viewType == ViewType.Login)
            {
                _store.Login(null);
            }

            _store.UpdateCurrentViewModel(currentViewModel);
        }

        public event EventHandler CanExecuteChanged;
    }
}