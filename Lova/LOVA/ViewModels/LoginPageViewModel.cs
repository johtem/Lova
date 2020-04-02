using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LOVA.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public LoginPageViewModel()
        {
            LoginButton = new Command(LoginCheck);
        }


        public string LoginName { get; set; }
        public string Password { get; set; }

        


        public event PropertyChangedEventHandler PropertyChanged;

        public Command LoginButton { get; }

       async void LoginCheck()
        {
            if (LoginName != "Löva" && Password != "Pumphus")
            {
                await App.Current.MainPage.DisplayAlert("Incorrect", "Lösenordet är fel ", "OK");
            }
            
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}
