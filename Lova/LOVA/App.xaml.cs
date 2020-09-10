using LOVA.Models;
using LOVA.Pages.Login;
using LOVA.Styles;
using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA
{
    public partial class App : Application
    {
        const int smallWightResolution = 768;
        const int smallHeightResolution = 1280;
        public App()
        {

            Device.SetFlags(new string[] { "Shapes_Experimental" });

            InitializeComponent();

            if (AppSession.FirstRun)
            {
                // TODO
                // Add here what should happens when FirstRun

                AppSession.FirstRun = false;
            }

            // LoadStyles();

            // MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new AppShell());
            MainPage = new AppShell();
            //MainPage = new LoginPage();
        }

        void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDeviceStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDeviceStyle.SharedInstance);
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
