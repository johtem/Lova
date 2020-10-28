using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Errors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Location : ContentPage
    {
        bool isGettingLocation;

        public Location()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            isGettingLocation = true;

            while (isGettingLocation)
            {
                var result = await Geolocation.GetLocationAsync(new
                GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));

                resultLocation.Text += $"lat: {result.Latitude}, lng: {result.Longitude} {Environment.NewLine}";

                await Task.Delay(1000);
            }
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            isGettingLocation = false;
        }
    }
}