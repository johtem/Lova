using LOVA.Models;
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
    public partial class ReportIssueDetailPage : ContentPage
    {
        public ReportIssueDetailPage(IssueReport detail )
        {
            InitializeComponent();
            ProblemDescription.Text = detail.ProblemDescription;
            SolultionDescription.Text = detail.SolutionDescription;
            Well.Text = detail.WellName;
            NewActivator.Text = detail.NewActivatorSerialNumber;
            NewValve.Text = detail.NewValveSerialNumber;
            CreatedAt.Text = detail.CreatedAt.ToShortDateString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}