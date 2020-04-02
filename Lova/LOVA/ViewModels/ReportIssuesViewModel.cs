using LOVA.Models;
using LOVA.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOVA.ViewModels
{
    class ReportIssuesViewModel : BaseViewModel
    {
        List<IssueReport> resultList;
        public List<IssueReport> ResultList
        {
            get { return resultList; }
            set
            {
                resultList = value;
                OnPropertyChanged();

            }
        }

        


        public ReportIssuesViewModel()
        {
            Title = "Åtgärdsrapport data";
            LoadDataAsync();

        }

        public async void LoadDataAsync()
        {
            IsBusy = true;
            LovaRestService api = new LovaRestService();
            var apa = await api.GetAllIssues();


            ResultList =  apa;



            
            IsBusy = false;
        }

    }
}
