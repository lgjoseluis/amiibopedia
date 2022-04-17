using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;

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

        private IEnumerable<Character> CharactersAll { get; set; }

        private readonly IPageDialogService _pageDialog;
        private readonly ICharactersService _charactersService;
        

        public MainPageViewModel(INavigationService navigationService,
            ICharactersService charactersService,
            IPageDialogService pageDialog) : base(navigationService)
        {
            Title = "Amiibopedia";
            this._charactersService = charactersService;
            this._pageDialog = pageDialog;
            this.SelectedCharacterCommand = new DelegateCommand(SelectedCharacterEvent);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode navigationMode = parameters.GetNavigationMode();

            base.OnNavigatedTo(parameters);

            if (navigationMode == NavigationMode.New)
            {
                await LoadData();
            }
        }

        private async Task LoadData()
        {
            try
            {
                CharactersAll = await _charactersService.GetAll();
            }
            catch (Exception)
            {                
                await _pageDialog.DisplayAlertAsync("Error", "Error al consultar el servicio!", "Aceptar");
            }

            if (CharactersAll != null && CharactersAll.Any())
                Characters = CharactersAll.OrderBy(x => x.key);            
        }

        private void FindAmiibo()
        {
            if(CharactersAll != null && CharactersAll.Any())
                RefreshItems(_searchText);            
        }
       
        private void SelectedCharacterEvent()
        {
            INavigationParameters parameters = new NavigationParameters
            {
                { "CharacterName", _selectedCharacter.name }
            };

            NavigationService.NavigateAsync("NavigationPage/AmiibosPage", parameters);
        }

        private void RefreshItems(string character)
        {
            if (!string.IsNullOrEmpty(character))
            {
                Characters = CharactersAll.Where(x => Regex.IsMatch(x.name, character, RegexOptions.IgnoreCase));
            }
            else
            {                
                Characters = CharactersAll.OrderBy(x => x.key);
            }
        }
    }
}
