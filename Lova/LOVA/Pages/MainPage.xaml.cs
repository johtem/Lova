
using LOVA.Pages.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           InitializeComponent();
        }

        async void OnNewErrorButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReplaceDevicePage());
        }

        async void OnGetAlarmListButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportIssuesPage());
        }
    }
}