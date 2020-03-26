using LOVA.Views.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new MainPage());
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
