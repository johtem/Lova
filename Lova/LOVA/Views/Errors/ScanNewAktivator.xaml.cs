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
    public partial class ScanNewAktivator : ContentPage
    {
        ErrorAktivatorViewModel _description;
        public ScanNewAktivator(ErrorAktivatorViewModel description)
        {
            InitializeComponent();
            BindingContext = _description = description;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _description.SerialNewAktivator = "123456";

            await Navigation.PushAsync(new ReplaceDevicePage(_description));
        }

        private async void OnScanResultHandle(ZXing.Result result)
        {
            _description.SerialNewAktivator = result.Text;

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