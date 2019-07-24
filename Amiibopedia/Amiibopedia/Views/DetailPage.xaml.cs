using Amiibopedia.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Amiibopedia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public DetailPage(Platillo Detail)
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                Detail.nombre,
                Detail.descripcion,
                Detail.imagen_1,
                Detail.imagen_2,
                Detail.imagen_3,
                Detail.ingredientes[0].nombre,
                Detail.receta.pasos
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
