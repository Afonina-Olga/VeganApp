using System;
using System.Windows.Input;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class ShowCommand : ICommand
    {
        public ShowCommand(ViewModelBase viewModel,IStore store)
        {
            _viewModel = viewModel;
            _store = store;
        }

        private readonly IStore _store;
        private readonly ViewModelBase _viewModel;
        
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _store.UpdateCurrentViewModel(_viewModel);
        }

        public event EventHandler CanExecuteChanged;
    }
}