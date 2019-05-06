using Ejemplo050519.Interfaces;
using Ejemplo050519.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Ejemplo050519.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        List<double> rtnlist = new List<double>();
        List<double> rtnprom = new List<double>();

        protected ILocalDBService localDbService = null;

        private ObservableCollection<UsuariosLista> _usuariosListas;
        public ObservableCollection<UsuariosLista> _UsuariosLista
        {
            get
            {
                return _usuariosListas;
            }

            set
            {
                if (_usuariosListas == value)
                {
                    return;
                }
                _usuariosListas = value;
                RaisePropertyChanged();
            }
        }

        private UsuariosLista selectedUsuariosList;
        public UsuariosLista SelectedUsuariosList
        {
            get
            {
                return selectedUsuariosList;
            }

            set
            {
                if (selectedUsuariosList == value)
                {
                    return;
                }
                selectedUsuariosList = value;
                RaisePropertyChanged();
            }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            localDbService = Xamarin.Forms.DependencyService.Get<ILocalDBService>();
            NumberGenerator();
            LoadDoctorList();

            PropertyChanged += MainPageViewModel_PropertyChanged;
        }

        private void MainPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedUsuariosList))
            {
                var parameters = new NavigationParameters { { "s", SelectedUsuariosList } };
                Globals.GlobalLat = SelectedUsuariosList.Lat;
                Globals.GlobalLng = SelectedUsuariosList.Lng;
                Globals.GlobalNombre = SelectedUsuariosList.NombreCompleto;
                Globals.GlobalDirección = SelectedUsuariosList.Calle;

                NavigationService.NavigateAsync(PageNames.DetailPage, parameters);
            }
            selectedUsuariosList = null;
        }

        private void NumberGenerator()
        {
            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                rtnlist.Add(rand.Next(10));
            }

            double suma = 0;
            foreach (double nota in rtnlist)
            {
                suma += nota;
                double prom = suma / rtnlist.Count;
                rtnprom.Add(prom);
            }
        }

        private async void LoadDoctorList()
        {
            _usuariosListas = new ObservableCollection<UsuariosLista>();
            HttpClient client = new HttpClient();
            int index = 0;

            HttpResponseMessage response = await client.GetAsync(Settings.WebServiceUriDefault);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                RootObject root = JsonConvert.DeserializeObject<RootObject>(str);

                foreach (var item in root.results)
                {
                    UsuariosLista UL = new UsuariosLista();
                    UL.Imagen = item.picture.large;
                    UL.NombreCompleto = item.name.title + ' ' + item.name.first + ' ' + item.name.last;
                    UL.Rating = rtnprom[index];
                    UL.Correo = item.email;
                    UL.Calle = item.location.street;
                    UL.Ciudad = item.location.city;
                    UL.Estado = item.location.state;
                    UL.CP = item.location.postcode;
                    UL.Telefono = item.phone;
                    UL.Lat = item.location.coordinates.latitude;
                    UL.Lng = item.location.coordinates.longitude;
                    index++;
                    _usuariosListas.Add(UL);
                }
                await localDbService.SaveAsync(_usuariosListas);

                var allUserList = await localDbService.GetUsuarioList();

                _UsuariosLista = new ObservableCollection<UsuariosLista>(allUserList);
                
            }
        }
    }
}
