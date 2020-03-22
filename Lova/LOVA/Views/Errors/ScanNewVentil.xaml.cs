using LOVA.Models;
using LOVA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Views.Errors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanNewVentil : ContentPage
    {
        ErrorAktivatorViewModel _description;
        public ScanNewVentil(ErrorAktivatorViewModel description)
        {
            InitializeComponent();
            BindingContext = _description = description;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _description.SerialNewVentil = "987654";

            await Navigation.PushAsync(new ReplaceDevicePage(_description));
        }

        private async void OnScanResultHandle(ZXing.Result result)
        {
            _description.SerialNewVentil = result.Text;

            await Navigation.PushAsync(new ReplaceDevicePage(_description));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _scanView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _scanView.IsScanning = false;
        }
    }
}