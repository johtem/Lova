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
        public ReportIssuesPage()
        {
            InitializeComponent();
            BindingContext = new ReportIssuesViewModel();
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IssueReport selectedItem = e.SelectedItem as IssueReport;

            DisplayAlert("Selected", selectedItem.ProblemDescription, "OK");

        }
    }
}