using LOVA.Data;
using LOVA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LOVA.ViewModels
{
    public class HttpTestViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



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

        bool isBusy;
        public bool IsBusy 
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        


    }
}
