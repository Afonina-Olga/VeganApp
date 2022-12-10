using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class AboutViewModel: ViewModelBase
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public Slide5ViewModel Slide5ViewModel { get; }

        public AboutViewModel(IStore store,
            IUserRepository repository,
            IMaterialRepository materialRepository,
            ITagRepository tagRepository)
        {
            Slide5ViewModel = new Slide5ViewModel(store, repository, materialRepository, tagRepository);
        }
    }
}