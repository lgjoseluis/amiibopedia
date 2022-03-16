using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmiibopediaApp.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
