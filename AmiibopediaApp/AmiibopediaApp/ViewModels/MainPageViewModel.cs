using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Prism.Navigation;
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
        private readonly ICharactersService charactersService;

        public MainPageViewModel(INavigationService navigationService,
            ICharactersService charactersService) : base(navigationService)
        {
            Title = "Amiibos";
            this.charactersService = charactersService;
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
    }
}
