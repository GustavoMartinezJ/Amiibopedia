using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amiibopedia.Models;
using Amiibopedia.ViewModels;
using Amiibopedia.Views;
using Syncfusion.SfAutoComplete.XForms;
using Xamarin.Forms;

namespace Amiibopedia
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MainPageViewModel();
            await ViewModel.LoadCharacters();
            this.BindingContext = ViewModel;            
        }

        private async void Cell_OnAppearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;


            view.TranslationX = -100;
            view.Opacity = 0;

            await Task.WhenAny<bool>
                (
                    view.TranslateTo(0, 0, 250, Easing.SinIn),
                    view.FadeTo(1,500,Easing.BounceIn)
                );

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Platillo selectedItem = e.SelectedItem as Platillo;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Platillo tappedItem = e.Item as Platillo;
            //DisplayAlert("More Context Action", tappedItem.nombre + " more context action", "OK");
            Navigation.PushModalAsync(new DetailPage(tappedItem));
        }
    }
}
