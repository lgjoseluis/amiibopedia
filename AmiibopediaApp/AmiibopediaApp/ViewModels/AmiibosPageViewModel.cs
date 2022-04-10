using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmiibopediaApp.ViewModels
{
    public class AmiibosPageViewModel : ViewModelBase
    {
        private IEnumerable<Amiibo> amiibos;
        public IEnumerable<Amiibo> Amiibos
        {
            get => amiibos;
            set => SetProperty(ref amiibos, value);
        }

        private string _characterName;
        //public string CharacterName
        //{
        //    get => _characterName;
        //    set => SetProperty(ref _characterName, value);
        //}

        private readonly IPageDialogService _pageDialog;
        private readonly IAmiibosService _amiibosService;

        public AmiibosPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialog,
            IAmiibosService amiibosService) : base(navigationService)
        {
            _pageDialog = pageDialog;
            _amiibosService = amiibosService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _characterName = parameters.GetValue<string>("CharacterName");

            Title = $"Amiibos - {_characterName}";

            LoadData();
        }

        private void LoadData()
        {

            Amiibos = _amiibosService.GetAllByCharacter(_characterName);

            //characters = Enumerable.Empty<Character>();

            //if (charactersAll.Any())
            //    characters = charactersAll.OrderBy(x => x.key);
            //else
            //_pageDialog.DisplayAlertAsync("Información", _characterName, "Aceptar");
        }
    }
}
