using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Amiibopedia.Helpers;
using Amiibopedia.Models;
using Xamarin.Forms;

namespace Amiibopedia.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private ObservableCollection<Platillo> _amiibos;
        public ObservableCollection<Character> Characters { get; set; }

        public ObservableCollection<Platillo> Amiibos
        {
            get => _amiibos;
            set
            {
                _amiibos = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
            SearchCommand =
                new Command(async (param) =>
                {
                    IsBusy = true;
                    var character = param as Character;
                    if (character != null)
                    {
                        string url = $"https://83a1f2d8.ngrok.io/platillos/?platillo={character.name}";
                        var service =
                            new HttpHelper<Platillos>();
                        var amiibos =
                            await service.GetRestServiceDataAsync(url);
                        Amiibos = new ObservableCollection<Platillo>(amiibos.food2u);
                    }
                    IsBusy = false;
                });
        }

        public async Task LoadCharacters()
        {
            IsBusy = true;
            var url = "https://83a1f2d8.ngrok.io/keys";
            var service =
                new HttpHelper<Characters>();
            var characters = await service.GetRestServiceDataAsync(url);
            Characters = new ObservableCollection<Character>(characters.food2u);
            IsBusy = false;
        }
        
    }
}
