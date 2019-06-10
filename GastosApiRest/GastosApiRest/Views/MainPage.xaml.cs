using System;
using GastosApiRest.Views;
using Xamarin.Forms;

namespace GastosApiRest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGastoPage());
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var gasto = e.Item as Gasto;

            Navigation.PushAsync(new EditGastoPage(gasto));
        }
    }
}