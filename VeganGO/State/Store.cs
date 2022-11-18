using System;
using VeganGO.ViewModels;

namespace VeganGO.State
{
    public class Store : IStore
    {
        public event Action<ViewModelBase> CurrentViewModelUpdated;
        public event Action<string> UserAuthorized;
        public event Action UserLogout;

        private ViewModelBase _currentViewModel;
        private string _login;
        public void UpdateCurrentViewModel(ViewModelBase currentViewModel)
        {
            _currentViewModel = currentViewModel;
            CurrentViewModelUpdated?.Invoke(currentViewModel);
        }

        public void Login(string login)
        {
            _login = login;
            UserAuthorized?.Invoke(login);
        }

        public void Logout()
        {
            _login = null;
            UserLogout?.Invoke();
        }
    }
}