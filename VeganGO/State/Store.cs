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
        public bool IsAdminMode { get; set; }
        
        public void UpdateCurrentViewModel(ViewModelBase currentViewModel)
        {
            _currentViewModel = currentViewModel;
            CurrentViewModelUpdated?.Invoke(currentViewModel);
        }

        public void Login(string login, bool isAdmin)
        {
            _login = login;
            IsAdminMode = isAdmin;
            UserAuthorized?.Invoke(login);
        }

        public void Logout()
        {
            _login = null;
            UserLogout?.Invoke();
        }
    }
}