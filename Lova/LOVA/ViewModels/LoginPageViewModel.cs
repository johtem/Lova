using LOVA.Exceptions;
using LOVA.Helpers;
using LOVA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LOVA.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            LoginButton = new Command(LoginCheck);
        }

        public Action DisplayInvalidLoginPrompt;

        public string LoginName { get; set; }
        public string Password { get; set; }

     


        // public event PropertyChangedEventHandler PropertyChanged;

        public Command LoginButton { get; }

       async void LoginCheck()
        {


            //if (LoginName == "Löva" && Password == "Pumphus")
            //{
            //    await Application.Current.MainPage.Navigation.PushAsync(new Pages.MainPage());
            //    // await App.Current.MainPage.DisplayAlert("Incorrect", "Lösenordet är fel ", "OK");
            //}

            HttpResponseMessage result = null;
            bool IsOK = false;

            try
            {

                // Get data from API
                // var ResultList = await RestHelper.GetAsync<List<IssueReport>>(AppSession.AllVACasesUrl);

                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(new { UserName = LoginName, Password = Password });
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                
                result = await client.PostAsync(new Uri(AppSession.LoginUrl), content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var tokenJson = await result.Content.ReadAsStringAsync();
                    if (tokenJson.Contains("User logged in"))
                    {
                        IsOK = true;
                    }
                    
                    
                }


                DataLoaded = true;

            }
            catch (InternetConnectionException iex)
            {

                IsErrorState = true;
                ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check your connection and try again.";
                ErrorImage = "nointernet.png";
            }
            catch (Exception ex)
            {
                IsErrorState = true;
                ErrorMessage = "Something went wrong. Please try again. If the error persists, contact support team with error message: " + ex.Message;
                ErrorImage = "error.png";
            }
            finally
            {
                IsBusy = false;
                LoadingText = "";


                ErrorMessage = "";
            }

            if (IsOK)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _navigation.PushAsync(new Pages.MainPage());
                });
                
            }
            else
            {
                ErrorMessage = "Lösenord eller login är fel.";
            }
            
        }
    }
}
