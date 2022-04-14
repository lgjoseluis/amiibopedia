﻿using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Prism.Commands;
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

            Title = $"Amiibopedia - {_characterName}";

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Amiibos = _amiibosService.GetAllByCharacter(_characterName);
            }
            catch (Exception)
            {
                _pageDialog.DisplayAlertAsync("Error", "Error al consultar el servicio!", "Aceptar");
            }
        }
    }
}
