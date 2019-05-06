using System;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Ejemplo050519.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            AddPin();
        }

        private void AddPin()
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(Globals.GlobalLat), Convert.ToDouble(Globals.GlobalLng)), Distance.FromKilometers(1000)));
            var pin = new Pin();

            double lat = Convert.ToDouble(Globals.GlobalLat);
            double lng = Convert.ToDouble(Globals.GlobalLng);

            pin = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(lat, lng),
                Label = Globals.GlobalNombre,
                Address = Globals.GlobalDirección,
                Icon = BitmapDescriptorFactory.DefaultMarker(Color.ForestGreen)
            };
            MyMap.Pins.Add(pin);
        }
    }
}
