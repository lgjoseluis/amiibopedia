using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AmiibopediaApp.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {                        
        private Character _selectedCharacter;
        public Character SelectedCharacter 
        { 
            get => _selectedCharacter; 
            set => SetProperty(ref _selectedCharacter, value); 
        }        

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value, () => FindAmiibo() );
        }

        private IEnumerable<Character> _characters;
        public IEnumerable<Character> Characters
        {
            get => _characters;
            private set => SetProperty(ref _characters, value);
        }

        public DelegateCommand SelectedCharacterCommand { get; private set; }
        public DelegateCommand<object> SearchAmiiboCommand { get; private set; }

        private IEnumerable<Character> CharactersAll { get; set; }

        private readonly IPageDialogService _pageDialog;
        private readonly ICharactersService _charactersService;
        

        public MainPageViewModel(INavigationService navigationService,
            ICharactersService charactersService,
            IPageDialogService pageDialog) : base(navigationService)
        {
            Title = "Amiibos";
            this._charactersService = charactersService;
            this._pageDialog = pageDialog;
            this.SearchAmiiboCommand = new DelegateCommand<object>(SearchAmiibo);
            this.SelectedCharacterCommand = new DelegateCommand(SelectedCharacterEvent);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode navigationMode = parameters.GetNavigationMode();

            base.OnNavigatedTo(parameters);

            if (navigationMode == NavigationMode.New)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            CharactersAll = _charactersService.GetAll();

            if (CharactersAll.Any())
                Characters = CharactersAll.OrderBy(x => x.key);
            else
                _pageDialog.DisplayAlertAsync("Información", "No existe información a mostrar!", "Aceptar");
        }

        private void FindAmiibo()
        {
            if(CharactersAll.Any())
                RefreshItems(_searchText);            
        }

        private void SearchAmiibo(object parameter)
        {
            RefreshItems(parameter.ToString());
        }

        private void SelectedCharacterEvent()
        {
            INavigationParameters parameters = new NavigationParameters();

            parameters.Add("CharacterName", _selectedCharacter.name);

            NavigationService.NavigateAsync("NavigationPage/AmiibosPage", parameters);
        }

        private void RefreshItems(string character)
        {
            if (!string.IsNullOrEmpty(character))
            {
                //Characters = charactersAll.Where(x => x.name.StartsWith(character, System.StringComparison.InvariantCultureIgnoreCase));
                Characters = CharactersAll.Where(x => Regex.IsMatch(x.name, character, RegexOptions.IgnoreCase));
            }
            else
            {                
                Characters = CharactersAll.OrderBy(x => x.key);
            }
        }
    }
}
