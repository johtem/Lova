using LOVA.Exceptions;
using LOVA.Helpers;
using LOVA.Models;
using LOVA.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOVA.ViewModels
{
    class ReportIssuesViewModel : BaseViewModel
    {
        List<IssueReport> _resultList;
        public List<IssueReport> ResultList
        {
            get { return _resultList; }
            set
            {
                SetProperty(ref _resultList, value);
                //_resultList = value;
                //OnPropertyChanged();

            }
        }

        
        public ReportIssuesViewModel()
        {
            Title = "Åtgärdsrapport data";
           
            

        }

        public async Task LoadDataAsync()
        {
            IsBusy = true;
            LoadingText = "Förbereder Data";
            DataLoaded = false;
            IsErrorState = false;


            
            // LovaRestService api = new LovaRestService();
            // var apa = await api.GetAllIssues();

            try
            {

                // Get data from API
                ResultList = await RestHelper.GetAsync<List<IssueReport>>(AppSession.AllVACasesUrl);

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

            }
            
  
        }

    }
}
