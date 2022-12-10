﻿using System;
using VeganGO.Infrastructure;
using VeganGO.ViewModels;

namespace VeganGO.State
{
    public interface IStore
    {
        event Action<ViewModelBase> CurrentViewModelUpdated;
        event Action<string> UserAuthorized;
        event Action UserLogout;
        void UpdateCurrentViewModel(ViewModelBase currentViewModel);
        void Login(string login);
        void Logout();
    }
}