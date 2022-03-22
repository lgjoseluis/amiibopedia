using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmiibopediaApp.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        private IEnumerable<Character> characters;
        public IEnumerable<Character> Characters
        {
            get => characters;
            set => SetProperty(ref characters, value);
        }

        public DelegateCommand<object> SearchAmiiboCommand { get; private set; }

        private readonly IPageDialogService pageDialog;
        private readonly ICharactersService charactersService;
        private readonly IAmiibosService amiibosService;

        public MainPageViewModel(INavigationService navigationService,
            ICharactersService charactersService,
            IAmiibosService amiibosService,
            IPageDialogService pageDialog) : base(navigationService)
        {
            Title = "Amiibos";
            this.charactersService = charactersService;
            this.amiibosService = amiibosService;
            this.pageDialog = pageDialog;
            this.SearchAmiiboCommand = new DelegateCommand<object>(SearchAmiibo);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            LoadData();
        }

        private void LoadData()
        {
            Characters = charactersService.GetAll();
        }

        void SearchAmiibo(object parameter)
        {
            string searchText = parameter.ToString();

            if (!string.IsNullOrEmpty(searchText))
            {
                var result = amiibosService.GetAllByCharacter(searchText);
            }
            else
            {
                pageDialog.DisplayAlertAsync("Información", "Información a buscar incorrecta!", "Aceptar");
            }
        }
    }
}
