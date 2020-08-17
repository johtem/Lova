using LOVA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using LOVA.Services;

namespace LOVA.Pages.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
           
            BindingContext = new LoginPageViewModel();

            var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            statusbar.SetStatusBarColor(Color.FromHex("5514B4"));

            LabelAppInfo.Text =  String.IsNullOrEmpty(AppInfo.Name) ? "Löva" : $"{AppInfo.Name}";
            LabelVersionInfo.Text = $"{AppInfo.VersionString} {AppInfo.BuildString}";

        }
    }
}