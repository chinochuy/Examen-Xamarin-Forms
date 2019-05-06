using Ejemplo050519.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejemplo050519.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{

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

        private string username;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                if (username == value)
                {
                    return;
                }
                username = value;
                RaisePropertyChanged();
            }
        }

        private string email;

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (email == value)
                {
                    return;
                }
                email = value;
                RaisePropertyChanged();
            }
        }

        private double rating;

        public double Rating
        {
            get
            {
                return rating;
            }

            set
            {
                if (rating == value)
                {
                    return;
                }
                rating = value;
                RaisePropertyChanged();
            }
        }

        private string street;

        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                if (street == value)
                {
                    return;
                }
                street = value;
                RaisePropertyChanged();
            }
        }

        private string city;

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (city == value)
                {
                    return;
                }
                city = value;
                RaisePropertyChanged();
            }
        }

        private string state;

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (state == value)
                {
                    return;
                }
                state = value;
                RaisePropertyChanged();
            }
        }

        private string statecode;

        public string StateCode
        {
            get
            {
                return statecode;
            }

            set
            {
                if (statecode == value)
                {
                    return;
                }
                statecode = value;
                RaisePropertyChanged();
            }
        }

        private string phone;

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                if (phone == value)
                {
                    return;
                }
                phone = value;
                RaisePropertyChanged();
            }
        }

        private string latitude;

        public string Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                if (latitude == value)
                {
                    return;
                }
                latitude = value;
                RaisePropertyChanged();
            }
        }

        private string longitude;

        public string Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                if (longitude == value)
                {
                    return;
                }
                longitude = value;
                RaisePropertyChanged();
            }
        }

        private string imagen;

        public string Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                if (imagen == value)
                {
                    return;
                }
                imagen = value;
                RaisePropertyChanged();
            }
        }

        public DetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters != null && parameters.ContainsKey("s"))
            {
                SelectedUsuariosList = parameters["s"] as UsuariosLista;
            }
            DetailInfo();
        }

        private void DetailInfo()
        {
            Imagen = SelectedUsuariosList.Imagen;
            Username = SelectedUsuariosList.NombreCompleto;
            Email = SelectedUsuariosList.Correo;
            Rating = SelectedUsuariosList.Rating;
            Street = SelectedUsuariosList.Calle;
            City = SelectedUsuariosList.Ciudad;
            State = SelectedUsuariosList.Estado;
            StateCode = SelectedUsuariosList.CP;
            Phone = SelectedUsuariosList.Telefono;
            Latitude = SelectedUsuariosList.Lat;
            Longitude = SelectedUsuariosList.Lng;
        }
    }
}
