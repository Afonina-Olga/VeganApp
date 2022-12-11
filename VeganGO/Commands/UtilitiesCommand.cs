using System;
using System.Threading.Tasks;
using System.Windows;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class DeleteUtilityCommand : AsyncCommandBase
    {
        private readonly UtilityViewModel _viewModel;
        private readonly IMaterialRepository _materialRepository;
        private readonly IStore _store;

        public DeleteUtilityCommand(
            UtilityViewModel viewModel,
            IMaterialRepository materialRepository,
            IStore store)
        {
            _viewModel = viewModel;
            _materialRepository = materialRepository;
            _store = store;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (!(parameter is int id))
            {
                return;
            }

            try
            {
                await _materialRepository.DeleteUtility(id);
                _store.UpdateUtilities();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось удалить статью");
            }
        }
    }
}