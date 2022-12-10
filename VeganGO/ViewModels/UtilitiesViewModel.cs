using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VeganGO.Commands;
using VeganGO.Infrastructure;
using VeganGO.Repositories;
using VeganGO.State;

namespace VeganGO.ViewModels
{
    public class UtilityViewModel : ViewModelBase
    {
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _imagePath;

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        
        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _author;
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        
        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get => _publishDate;
            set
            {
                _publishDate = value;
                OnPropertyChanged(nameof(PublishDate));
            }
        }

        public ObservableCollection<TagViewModel> Tags { get; set; }
        
        public ICommand ShowCommand { get; }

        public UtilityViewModel(IStore store)
        {
            ShowCommand = new ShowCommand(this, store);
        }
    }

    public class UtilitiesViewModel : MaterialBaseViewModel
    {
        public bool IsAdmin { get; set; }
        
        private ObservableCollection<UtilityViewModel> _utilities;

        // ReSharper disable once MemberCanBePrivate.Global
        public ObservableCollection<UtilityViewModel> Utilities
        {
            get => _utilities;
            set
            {
                _utilities = value;
                OnPropertyChanged(nameof(Utilities));
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand LoadUtilitiesCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand LoadTagsCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand FindUtilitiesByFilterCommand { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ICommand FindUtilitiesByTagsCommand { get; }

        public UtilitiesViewModel(
            IMaterialRepository repository,
            ITagRepository tagRepository,
            IStore store)
            : base(repository, tagRepository, store)
        {
            IsAdmin = store.IsAdminMode;
            LoadUtilitiesCommand = new LoadUtilitiesCommand(this, repository, store);
            LoadUtilitiesCommand.Execute(null);
            LoadTagsCommand = new LoadTagsCommand(this, tagRepository, TagType.Utility);
            LoadTagsCommand.Execute(null);
            FindUtilitiesByFilterCommand = new FindUtilitiesByNameCommand(this, repository, store);
            FindUtilitiesByTagsCommand = new FindUtilitiesByTagsCommand(this, repository, store);
        }
    }
}