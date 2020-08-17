using LOVA.Models;
using LOVA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOVA.Pages.Alarm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportIssuesPage : ContentPage
    {
        ReportIssuesViewModel viewModel;

        public ReportIssuesPage()
        {
            InitializeComponent();
            viewModel = new ReportIssuesViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadDataAsync();
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IssueReport detail = e.SelectedItem as IssueReport;

            // DisplayAlert("Selected", detail.ProblemDescription, "OK");

            await Navigation.PushAsync(new ReportIssueDetailPage(detail));

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}