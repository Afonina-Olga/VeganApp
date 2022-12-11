using System;
using System.Threading.Tasks;
using System.Windows;
using VeganGO.Repositories;
using VeganGO.State;
using VeganGO.ViewModels;

namespace VeganGO.Commands
{
    public class DeleteRecipeCommand : AsyncCommandBase
    {
        private readonly RecipeViewModel _viewModel;
        private readonly IMaterialRepository _materialRepository;
        private readonly IStore _store;

        public DeleteRecipeCommand(
            RecipeViewModel viewModel,
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
                await _materialRepository.DeleteRecipe(id);
                _store.UpdateRecipes();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось удалить статью");
            }
        }
    }
}