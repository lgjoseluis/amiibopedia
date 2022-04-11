using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmiibopediaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AmiibosPage : ContentPage
    {
        public AmiibosPage()
        {
            InitializeComponent();
        }

        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            ViewCell cell = (ViewCell)sender;
            View view = cell.View;

            view.TranslationX = -100;
            view.Opacity = 0;

            await Task.WhenAny<bool>(
                    view.TranslateTo(0, 0, 250, Easing.SinIn),
                    view.FadeTo(1, 500, Easing.BounceIn)
                );            
        }
    }
}