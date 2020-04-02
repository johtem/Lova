using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Errors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainErrorPage : ContentPage
    {
        public MainErrorPage()
        {
            InitializeComponent();
        }

        async void OnAktivatorButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReplaceDevicePage());
        }

        async void OnPumphusetButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PumphusetPage());
        }
    }
}