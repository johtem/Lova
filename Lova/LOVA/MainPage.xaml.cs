using LOVA.Views.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LOVA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnErrorButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainErrorPage());
        }

        async void OnAlarmButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LOVA.Views.Alarm.MainAlarmPage());
        }
    }
}
