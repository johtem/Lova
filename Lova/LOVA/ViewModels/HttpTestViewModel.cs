using LOVA.Services;
using LOVA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LOVA.ViewModels
{
    public class HttpTestViewModel : BaseViewModel
    { 

        List<Result> resultList;
        public List<Result> ResultList 
        { 
            get { return resultList; }
            set { 
                resultList = value;
                OnPropertyChanged();
                
            }
        }


        public HttpTestViewModel()
        {
            Title = "Starswars data";
            LoadDataAsync();
            
        }

        public async void LoadDataAsync()
        {
            IsBusy = true;
            RestService api = new RestService();
            var apa = await api.GetStarwars();

            ResultList = apa.results;
            IsBusy = false;
        }


    }
}
